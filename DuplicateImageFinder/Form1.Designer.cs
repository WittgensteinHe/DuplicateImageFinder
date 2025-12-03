namespace DuplicateImageFinder
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            panelTop = new Panel();
            chkBmp = new CheckBox();
            chkJpg = new CheckBox();
            chkPng = new CheckBox();
            btnScan = new Button();
            btnSelectFolder = new Button();
            txtPath = new TextBox();
            panelBottom = new Panel();
            lblStatus = new Label();
            progressBar1 = new ProgressBar();
            splitContainer1 = new SplitContainer();
            listViewResults = new ListView();
            pbPreview = new PictureBox();
            btnDelete = new Button();
            panelTop.SuspendLayout();
            panelBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPreview).BeginInit();
            SuspendLayout();
            // 
            // panelTop
            // 
            panelTop.Controls.Add(chkBmp);
            panelTop.Controls.Add(chkJpg);
            panelTop.Controls.Add(chkPng);
            panelTop.Controls.Add(btnScan);
            panelTop.Controls.Add(btnSelectFolder);
            panelTop.Controls.Add(txtPath);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 0);
            panelTop.Margin = new Padding(4);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(12, 14, 12, 14);
            panelTop.Size = new Size(1148, 113);
            panelTop.TabIndex = 0;
            // 
            // chkBmp
            // 
            chkBmp.AutoSize = true;
            chkBmp.Location = new Point(210, 71);
            chkBmp.Margin = new Padding(4);
            chkBmp.Name = "chkBmp";
            chkBmp.Size = new Size(57, 21);
            chkBmp.TabIndex = 5;
            chkBmp.Text = ".BMP";
            chkBmp.UseVisualStyleBackColor = true;
            // 
            // chkJpg
            // 
            chkJpg.AutoSize = true;
            chkJpg.Checked = true;
            chkJpg.CheckState = CheckState.Checked;
            chkJpg.Location = new Point(93, 71);
            chkJpg.Margin = new Padding(4);
            chkJpg.Name = "chkJpg";
            chkJpg.Size = new Size(84, 21);
            chkJpg.TabIndex = 4;
            chkJpg.Text = ".JPG/JPEG";
            chkJpg.UseVisualStyleBackColor = true;
            // 
            // chkPng
            // 
            chkPng.AutoSize = true;
            chkPng.Checked = true;
            chkPng.CheckState = CheckState.Checked;
            chkPng.Location = new Point(18, 71);
            chkPng.Margin = new Padding(4);
            chkPng.Name = "chkPng";
            chkPng.Size = new Size(56, 21);
            chkPng.TabIndex = 3;
            chkPng.Text = ".PNG";
            chkPng.UseVisualStyleBackColor = true;
            // 
            // btnScan
            // 
            btnScan.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnScan.BackColor = SystemColors.ActiveCaption;
            btnScan.FlatStyle = FlatStyle.Flat;
            btnScan.Font = new Font("微软雅黑", 9F, FontStyle.Bold, GraphicsUnit.Point);
            btnScan.Location = new Point(1003, 18);
            btnScan.Margin = new Padding(4);
            btnScan.Name = "btnScan";
            btnScan.Size = new Size(131, 75);
            btnScan.TabIndex = 2;
            btnScan.Text = "开始扫描";
            btnScan.UseVisualStyleBackColor = false;
            btnScan.Click += btnScan_Click;
            // 
            // btnSelectFolder
            // 
            btnSelectFolder.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSelectFolder.Location = new Point(887, 18);
            btnSelectFolder.Margin = new Padding(4);
            btnSelectFolder.Name = "btnSelectFolder";
            btnSelectFolder.Size = new Size(110, 35);
            btnSelectFolder.TabIndex = 1;
            btnSelectFolder.Text = "选择文件夹...";
            btnSelectFolder.UseVisualStyleBackColor = true;
            btnSelectFolder.Click += btnSelectFolder_Click;
            // 
            // txtPath
            // 
            txtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPath.Location = new Point(15, 21);
            txtPath.Margin = new Padding(4);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(864, 23);
            txtPath.TabIndex = 0;
            // 
            // panelBottom
            // 
            panelBottom.Controls.Add(lblStatus);
            panelBottom.Controls.Add(progressBar1);
            panelBottom.Dock = DockStyle.Bottom;
            panelBottom.Location = new Point(0, 738);
            panelBottom.Margin = new Padding(4);
            panelBottom.Name = "panelBottom";
            panelBottom.Size = new Size(1148, 57);
            panelBottom.TabIndex = 1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Dock = DockStyle.Fill;
            lblStatus.Location = new Point(0, 0);
            lblStatus.Margin = new Padding(4, 0, 4, 0);
            lblStatus.Name = "lblStatus";
            lblStatus.Padding = new Padding(6, 7, 0, 0);
            lblStatus.Size = new Size(38, 24);
            lblStatus.TabIndex = 1;
            lblStatus.Text = "就绪";
            // 
            // progressBar1
            // 
            progressBar1.Dock = DockStyle.Bottom;
            progressBar1.Location = new Point(0, 36);
            progressBar1.Margin = new Padding(4);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(1148, 21);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 0;
            progressBar1.Visible = false;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 113);
            splitContainer1.Margin = new Padding(4);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(listViewResults);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(pbPreview);
            splitContainer1.Panel2.Controls.Add(btnDelete);
            splitContainer1.Size = new Size(1148, 625);
            splitContainer1.SplitterDistance = 700;
            splitContainer1.SplitterWidth = 5;
            splitContainer1.TabIndex = 2;
            // 
            // listViewResults
            // 
            listViewResults.CheckBoxes = true;
            listViewResults.Dock = DockStyle.Fill;
            listViewResults.FullRowSelect = true;
            listViewResults.GridLines = true;
            listViewResults.Location = new Point(0, 0);
            listViewResults.Margin = new Padding(4);
            listViewResults.Name = "listViewResults";
            listViewResults.Size = new Size(700, 625);
            listViewResults.TabIndex = 0;
            listViewResults.UseCompatibleStateImageBehavior = false;
            listViewResults.View = View.Details;
            // 
            // pbPreview
            // 
            pbPreview.BackColor = Color.WhiteSmoke;
            pbPreview.BorderStyle = BorderStyle.FixedSingle;
            pbPreview.Dock = DockStyle.Fill;
            pbPreview.Location = new Point(0, 0);
            pbPreview.Margin = new Padding(4);
            pbPreview.Name = "pbPreview";
            pbPreview.Size = new Size(443, 554);
            pbPreview.SizeMode = PictureBoxSizeMode.Zoom;
            pbPreview.TabIndex = 1;
            pbPreview.TabStop = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.MistyRose;
            btnDelete.Dock = DockStyle.Bottom;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.DarkRed;
            btnDelete.Location = new Point(0, 554);
            btnDelete.Margin = new Padding(4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(443, 71);
            btnDelete.TabIndex = 0;
            btnDelete.Text = "删除选中项 (到回收站)";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1148, 795);
            Controls.Add(splitContainer1);
            Controls.Add(panelBottom);
            Controls.Add(panelTop);
            Margin = new Padding(4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "重复图片扫描工具";
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            panelBottom.ResumeLayout(false);
            panelBottom.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pbPreview).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button btnSelectFolder;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Panel panelBottom;
        private System.Windows.Forms.CheckBox chkBmp;
        private System.Windows.Forms.CheckBox chkJpg;
        private System.Windows.Forms.CheckBox chkPng;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listViewResults;
        private System.Windows.Forms.PictureBox pbPreview;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label lblStatus;
    }
}