namespace VKAudio
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.UserId = new System.Windows.Forms.TextBox();
            this.Get = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Count = new System.Windows.Forms.Label();
            this.Data = new System.Windows.Forms.DataGridView();
            this.Artist = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Duration = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.Directory = new System.Windows.Forms.TextBox();
            this.Browse = new System.Windows.Forms.Button();
            this.browser = new System.Windows.Forms.FolderBrowserDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.Status = new System.Windows.Forms.ToolStripStatusLabel();
            this.Download = new System.Windows.Forms.Button();
            this.DownloadAll = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.Data)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID/Short name";
            // 
            // UserId
            // 
            this.UserId.Location = new System.Drawing.Point(87, 6);
            this.UserId.Name = "UserId";
            this.UserId.Size = new System.Drawing.Size(100, 20);
            this.UserId.TabIndex = 1;
            this.UserId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UserId_KeyPress);
            // 
            // Get
            // 
            this.Get.Location = new System.Drawing.Point(193, 4);
            this.Get.Name = "Get";
            this.Get.Size = new System.Drawing.Size(85, 23);
            this.Get.TabIndex = 2;
            this.Get.Text = "Retrieve audio";
            this.Get.UseVisualStyleBackColor = true;
            this.Get.Click += new System.EventHandler(this.Get_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(281, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Count:";
            this.label2.Visible = false;
            // 
            // Count
            // 
            this.Count.AutoSize = true;
            this.Count.Location = new System.Drawing.Point(319, 9);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(0, 13);
            this.Count.TabIndex = 5;
            this.Count.Visible = false;
            // 
            // Data
            // 
            this.Data.AllowUserToAddRows = false;
            this.Data.AllowUserToDeleteRows = false;
            this.Data.AllowUserToResizeRows = false;
            this.Data.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.Data.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Artist,
            this.Title,
            this.Duration});
            this.Data.Location = new System.Drawing.Point(15, 43);
            this.Data.Name = "Data";
            this.Data.ReadOnly = true;
            this.Data.RowHeadersVisible = false;
            this.Data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Data.Size = new System.Drawing.Size(632, 374);
            this.Data.TabIndex = 6;
            // 
            // Artist
            // 
            this.Artist.FillWeight = 127.1574F;
            this.Artist.HeaderText = "Artist";
            this.Artist.Name = "Artist";
            this.Artist.ReadOnly = true;
            // 
            // Title
            // 
            this.Title.FillWeight = 127.1574F;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Duration
            // 
            this.Duration.FillWeight = 45.68528F;
            this.Duration.HeaderText = "Duration";
            this.Duration.Name = "Duration";
            this.Duration.ReadOnly = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(354, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "DL directory";
            // 
            // Directory
            // 
            this.Directory.Location = new System.Drawing.Point(424, 7);
            this.Directory.Name = "Directory";
            this.Directory.Size = new System.Drawing.Size(375, 20);
            this.Directory.TabIndex = 8;
            // 
            // Browse
            // 
            this.Browse.Location = new System.Drawing.Point(805, 6);
            this.Browse.Name = "Browse";
            this.Browse.Size = new System.Drawing.Size(75, 22);
            this.Browse.TabIndex = 9;
            this.Browse.Text = "Browse...";
            this.Browse.UseVisualStyleBackColor = true;
            this.Browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.AliceBlue;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Progress,
            this.Status});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(888, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Progress
            // 
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(100, 16);
            // 
            // Status
            // 
            this.Status.Name = "Status";
            this.Status.Size = new System.Drawing.Size(26, 17);
            this.Status.Text = "Idle";
            // 
            // Download
            // 
            this.Download.Enabled = false;
            this.Download.Location = new System.Drawing.Point(653, 365);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(223, 23);
            this.Download.TabIndex = 11;
            this.Download.Text = "Download Selected";
            this.Download.UseVisualStyleBackColor = true;
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // DownloadAll
            // 
            this.DownloadAll.Enabled = false;
            this.DownloadAll.Location = new System.Drawing.Point(653, 394);
            this.DownloadAll.Name = "DownloadAll";
            this.DownloadAll.Size = new System.Drawing.Size(223, 23);
            this.DownloadAll.TabIndex = 12;
            this.DownloadAll.Text = "Download All";
            this.DownloadAll.UseVisualStyleBackColor = true;
            this.DownloadAll.Click += new System.EventHandler(this.DownloadAll_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(653, 43);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(223, 316);
            this.richTextBox1.TabIndex = 13;
            this.richTextBox1.Text = "";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(888, 450);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.DownloadAll);
            this.Controls.Add(this.Download);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.Browse);
            this.Controls.Add(this.Directory);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Data);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Get);
            this.Controls.Add(this.UserId);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VKAudioManager";
            ((System.ComponentModel.ISupportInitialize)(this.Data)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserId;
        private System.Windows.Forms.Button Get;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label Count;
        private System.Windows.Forms.DataGridView Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Artist;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Duration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Directory;
        private System.Windows.Forms.Button Browse;
        private System.Windows.Forms.FolderBrowserDialog browser;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar Progress;
        private System.Windows.Forms.ToolStripStatusLabel Status;
        private System.Windows.Forms.Button Download;
        private System.Windows.Forms.Button DownloadAll;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

