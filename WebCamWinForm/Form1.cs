using Azure.Storage.Blobs;
using BasicAudio;
using DirectShowLib;
using FFMpegCore;
using OpenCvSharp;
using OpenCvSharp.Extensions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCamWinForm2020
{
    public partial class Form1 : Form
    {
        bool isCameraRunning = false;
        bool isMicrophoneJustStarted = false;
        VideoCapture capture;
        VideoWriter outputVideo;
        Recording audioRecorder;

        Mat frame;
        Bitmap imageAlternate;
        Bitmap image;
        bool isUsingImageAlternate = false;

        Stopwatch sw = new Stopwatch();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblStatus.Text = "";

            var videoDevices = new List<DsDevice>(DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice));
            foreach (var device in videoDevices)
            {
                ddlVideoDevices.Items.Add(device.Name);
            }
        }

        private async void btnRecord_Click(object sender, EventArgs e)
        {
            if (ddlVideoDevices.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a video device as the Video Source.", "Video Source Not Defined", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isCameraRunning)
            {
                lblStatus.Text = "Starting camera...";
                StartCamera();
                btnRecord.Text = "Stop";
                lblStatus.Text = "Starting microphone...";
                Application.DoEvents();
                StartMicrophone();

                frameCount = 0;
                sw.Restart();

                recordingTimer.Enabled = true;
                recordingTimer.Start();

                lblStatus.Text = "Recording...";

            }
            else
            {
                StopCamera();
                StopMicrophone();

                lblStatus.Text = "Recording ended.";

                await OutputRecordingAsync();
            }
        }

        private void StartCamera()
        {
            DisposeCameraResources();

            isCameraRunning = true;

            int deviceIndex = ddlVideoDevices.SelectedIndex;
            capture = new VideoCapture(deviceIndex, VideoCaptureAPIs.DSHOW);

            capture.Set(VideoCaptureProperties.FrameHeight, 480);
            capture.Set(VideoCaptureProperties.FrameWidth, 640);

            lblStatus.Text = "Starting camera - opening capture device...";
            Application.DoEvents();
            capture.Open(deviceIndex, VideoCaptureAPIs.DSHOW);

            outputVideo = new VideoWriter("video.mp4", FourCC.AVC, 59, new OpenCvSharp.Size(640, 480));
        }

        private void StopCamera()
        {
            isCameraRunning = false;

            btnRecord.Text = "Start";

            recordingTimer.Stop();
            recordingTimer.Enabled = false;

            DisposeCaptureResources();
        }

        private void StartMicrophone()
        {
            audioRecorder = new Recording();
            audioRecorder.Filename = "sound.wav";
            isMicrophoneJustStarted = true;
        }

        private void StopMicrophone()
        {
            audioRecorder.StopRecording();
        }

        private async Task OutputRecordingAsync()
        {
            string outputPath = $"output_{DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")}.mp4";

            try
            {
                FFMpeg.ReplaceAudio("video.mp4", "sound.wav", outputPath, true);

                lblStatus.Text = $"Recording saved to local disk with the file name {outputPath}.";

                string azureStorageConnectionString = txtAzureStorageConnectionString.Text;
                if (!string.IsNullOrWhiteSpace(azureStorageConnectionString))
                {
                    try
                    {
                        BlobServiceClient blobServiceClient = new BlobServiceClient(azureStorageConnectionString);
                        BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("webcam-videos");
                        BlobClient blobClient = containerClient.GetBlobClient(outputPath);

                        using FileStream uploadFileStream = File.OpenRead(outputPath);
                        await blobClient.UploadAsync(uploadFileStream, true);
                        uploadFileStream.Close();

                        lblStatus.Text = $"Recording saved to both local disk and Azure Blob Storage with the file name {outputPath}.";
                    }
                    catch (Exception ex)
                    {
                        lblStatus.Text = $"Recording saved to both local disk with the file name {outputPath} but cannot be saved on Azure Blob Storage.";
                        MessageBox.Show(ex.Message, "Error on Saving to Azure Blob Storage", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Recording cannot be saved.";

                MessageBox.Show($"Recording cannot be saved because {ex.Message}", "Error on Recording Saving", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisposeCameraResources()
        {
            if (frame != null)
            {
                frame.Dispose();
            }

            if (image != null)
            {
                image.Dispose();
            }

            if (imageAlternate != null)
            {
                imageAlternate.Dispose();
            }
        }

        private void DisposeCaptureResources()
        {
            if (capture != null)
            {
                capture.Release();
                capture.Dispose();
            }

            if (outputVideo != null)
            {
                outputVideo.Release();
                outputVideo.Dispose();
            }
        }

        int frameCount = 0;

        private void recordingTimer_Tick(object sender, EventArgs e)
        {
            if (capture.IsOpened())
            {
                try
                {
                    frame = new Mat();
                    capture.Read(frame);
                    if (frame != null)
                    {
                        if (imageAlternate == null)
                        {
                            isUsingImageAlternate = true;
                            imageAlternate = BitmapConverter.ToBitmap(frame);
                        }
                        else if (image == null)
                        {
                            isUsingImageAlternate = false;
                            image = BitmapConverter.ToBitmap(frame);
                        }

                        pictureBox1.Image = isUsingImageAlternate ? imageAlternate : image;

                        outputVideo.Write(frame);

                        frameCount++;
                        double frameRate = frameCount / sw.Elapsed.TotalSeconds;
                        lblStatus.Text = "Frames: " + frameCount + ", elapsed time: " + sw.Elapsed.TotalSeconds + ", frame rate: " + frameRate.ToString("0.##");
                    }
                }
                catch (Exception)
                {
                    pictureBox1.Image = null;
                }
                finally
                {
                    if (frame != null)
                    {
                        frame.Dispose();
                    }

                    if (isUsingImageAlternate && image != null)
                    {
                        image.Dispose();
                        image = null;
                    }
                    else if (!isUsingImageAlternate && imageAlternate != null)
                    {
                        imageAlternate.Dispose();
                        imageAlternate = null;
                    }
                }

                if (isMicrophoneJustStarted)
                {
                    audioRecorder.StartRecording();
                    isMicrophoneJustStarted = false;
                }
            }
        }

        private async void buttonFrames_Click(object sender, EventArgs e)
        {
            if (ddlVideoDevices.SelectedIndex < 0)
            {
                MessageBox.Show("Please choose a video device as the Video Source.", "Video Source Not Defined", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!isCameraRunning)
            {
                lblStatus.Text = "Starting frame capture...";
                StartCamera();
                buttonFrames.Text = "Stop";
                Application.DoEvents();

                recordingTimer.Enabled = true;
                recordingTimer.Start();

                lblStatus.Text = "Recording...";
            }
            else
            {
                StopCamera();
                StopMicrophone();

                lblStatus.Text = "Recording ended.";

                await OutputRecordingAsync();
            }
        }
    }
}
