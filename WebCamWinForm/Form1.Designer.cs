
namespace WebCamWinForm2020
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblVideoDevices = new System.Windows.Forms.Label();
            ddlVideoDevices = new System.Windows.Forms.ComboBox();
            lblAzureStorageConnectionString = new System.Windows.Forms.Label();
            txtAzureStorageConnectionString = new System.Windows.Forms.TextBox();
            btnRecord = new System.Windows.Forms.Button();
            statusStrip = new System.Windows.Forms.StatusStrip();
            lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            recordingTimer = new System.Windows.Forms.Timer(components);
            buttonFrames = new System.Windows.Forms.Button();
            statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // lblVideoDevices
            // 
            lblVideoDevices.AutoSize = true;
            lblVideoDevices.Location = new System.Drawing.Point(10, 7);
            lblVideoDevices.Name = "lblVideoDevices";
            lblVideoDevices.Size = new System.Drawing.Size(79, 15);
            lblVideoDevices.TabIndex = 0;
            lblVideoDevices.Text = "Video Source:";
            // 
            // ddlVideoDevices
            // 
            ddlVideoDevices.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            ddlVideoDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            ddlVideoDevices.FormattingEnabled = true;
            ddlVideoDevices.Location = new System.Drawing.Point(10, 24);
            ddlVideoDevices.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            ddlVideoDevices.Name = "ddlVideoDevices";
            ddlVideoDevices.Size = new System.Drawing.Size(826, 23);
            ddlVideoDevices.TabIndex = 1;
            // 
            // lblAzureStorageConnectionString
            // 
            lblAzureStorageConnectionString.AutoSize = true;
            lblAzureStorageConnectionString.Location = new System.Drawing.Point(10, 47);
            lblAzureStorageConnectionString.Name = "lblAzureStorageConnectionString";
            lblAzureStorageConnectionString.Size = new System.Drawing.Size(209, 15);
            lblAzureStorageConnectionString.TabIndex = 6;
            lblAzureStorageConnectionString.Text = "Azure Blob Storage Connection String:";
            // 
            // txtAzureStorageConnectionString
            // 
            txtAzureStorageConnectionString.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            txtAzureStorageConnectionString.Location = new System.Drawing.Point(10, 64);
            txtAzureStorageConnectionString.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            txtAzureStorageConnectionString.Name = "txtAzureStorageConnectionString";
            txtAzureStorageConnectionString.Size = new System.Drawing.Size(826, 23);
            txtAzureStorageConnectionString.TabIndex = 7;
            // 
            // btnRecord
            // 
            btnRecord.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRecord.Location = new System.Drawing.Point(728, 89);
            btnRecord.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            btnRecord.Name = "btnRecord";
            btnRecord.Size = new System.Drawing.Size(108, 31);
            btnRecord.TabIndex = 8;
            btnRecord.Text = "Record";
            btnRecord.UseVisualStyleBackColor = true;
            btnRecord.Click += btnRecord_Click;
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { lblStatus });
            statusStrip.Location = new System.Drawing.Point(0, 415);
            statusStrip.Name = "statusStrip";
            statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 12, 0);
            statusStrip.Size = new System.Drawing.Size(846, 22);
            statusStrip.TabIndex = 9;
            statusStrip.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new System.Drawing.Size(97, 17);
            lblStatus.Text = "Strip Status Label";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            pictureBox1.Location = new System.Drawing.Point(10, 89);
            pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(712, 326);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // recordingTimer
            // 
            recordingTimer.Interval = 8;
            recordingTimer.Tick += recordingTimer_Tick;
            // 
            // buttonFrames
            // 
            buttonFrames.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            buttonFrames.Location = new System.Drawing.Point(728, 124);
            buttonFrames.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            buttonFrames.Name = "buttonFrames";
            buttonFrames.Size = new System.Drawing.Size(108, 31);
            buttonFrames.TabIndex = 11;
            buttonFrames.Text = "Frames";
            buttonFrames.UseVisualStyleBackColor = true;
            buttonFrames.Click += buttonFrames_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(846, 437);
            Controls.Add(buttonFrames);
            Controls.Add(pictureBox1);
            Controls.Add(statusStrip);
            Controls.Add(btnRecord);
            Controls.Add(txtAzureStorageConnectionString);
            Controls.Add(lblAzureStorageConnectionString);
            Controls.Add(ddlVideoDevices);
            Controls.Add(lblVideoDevices);
            Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            Name = "Form1";
            Text = "Webcam App (Demo)";
            Load += Form1_Load;
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblVideoDevices;
        private System.Windows.Forms.ComboBox ddlVideoDevices;
        private System.Windows.Forms.Label lblAzureStorageConnectionString;
        private System.Windows.Forms.TextBox txtAzureStorageConnectionString;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer recordingTimer;
        private System.Windows.Forms.Button buttonFrames;
    }
}

