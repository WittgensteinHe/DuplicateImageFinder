using Microsoft.VisualBasic.FileIO; // 必须添加 Microsoft.VisualBasic 引用
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace DuplicateImageFinder
{
    public partial class Form1 : Form
    {
        // 缓存当前加载的图片路径，防止重复加载
        private string _currentPreviewPath = "";

        public Form1()
        {
            InitializeComponent();
            SetupListView();
        }

        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            // 使用 FolderBrowserDialog 供用户选择路径
            using (var fbd = new FolderBrowserDialog())
            {
                // 设置对话框提示
                fbd.Description = "请选择要扫描的根目录：";

                // 尝试设置初始路径为当前路径（可选）
                if (System.IO.Directory.Exists(txtPath.Text))
                {
                    fbd.SelectedPath = txtPath.Text;
                }

                if (fbd.ShowDialog() == DialogResult.OK)
                {
                    // 将选中的路径设置到文本框
                    txtPath.Text = fbd.SelectedPath;
                }
            }
        }

        private void SetupListView()
        {
            listViewResults.View = View.Details;
            listViewResults.CheckBoxes = true; // 开启复选框
            listViewResults.Columns.Add("文件名", 200);
            listViewResults.Columns.Add("路径", 400);
            listViewResults.Columns.Add("大小", 100);

            // 绑定事件
            listViewResults.SelectedIndexChanged += ListViewResults_SelectedIndexChanged;
        }

        private async void btnScan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPath.Text) || !Directory.Exists(txtPath.Text))
            {
                MessageBox.Show("请选择有效文件夹");
                return;
            }

            var exts = new List<string>();
            if (chkPng.Checked) exts.Add(".png");
            if (chkJpg.Checked) { exts.Add(".jpg"); exts.Add(".jpeg"); }
            if (chkBmp.Checked) exts.Add(".bmp");

            listViewResults.Items.Clear();
            pbPreview.Image = null; // 清空预览
            btnScan.Enabled = false;
            progressBar1.Visible = true;

            var scanner = new FileScanner(exts);
            var progress = new Progress<string>(s => lblStatus.Text = s);

            try
            {
                var results = await scanner.ScanForDuplicatesAsync(txtPath.Text, progress);
                DisplayResults(results);
                lblStatus.Text = $"扫描完成，发现 {results.Count} 组重复。";
            }
            finally
            {
                btnScan.Enabled = true;
                progressBar1.Visible = false;
            }
        }

        private void DisplayResults(Dictionary<string, List<string>> groups)
        {
            listViewResults.BeginUpdate();
            foreach (var group in groups)
            {
                ListViewGroup lvGroup = new ListViewGroup($"MD5: {group.Key} (重复数: {group.Value.Count})");
                listViewResults.Groups.Add(lvGroup);

                foreach (var path in group.Value)
                {
                    var fi = new FileInfo(path);
                    var item = new ListViewItem(fi.Name);
                    item.SubItems.Add(fi.DirectoryName);
                    item.SubItems.Add($"{fi.Length / 1024.0:F2} KB");
                    item.Tag = path; // 存储完整路径
                    item.Group = lvGroup;
                    listViewResults.Items.Add(item);
                }
            }
            listViewResults.EndUpdate();
        }

        // 核心功能1：预览图片 (无锁加载)
        private void ListViewResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewResults.SelectedItems.Count == 0) return;

            string path = listViewResults.SelectedItems[0].Tag.ToString();

            // 如果已经在预览这张图，就不重新加载
            if (path == _currentPreviewPath) return;

            try
            {
                if (pbPreview.Image != null)
                {
                    pbPreview.Image.Dispose(); // 释放旧图片内存
                    pbPreview.Image = null;
                }

                if (File.Exists(path))
                {
                    // 使用 MemoryStream 加载，避免文件被锁死导致无法删除
                    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
                    {
                        var ms = new MemoryStream();
                        fs.CopyTo(ms);
                        ms.Position = 0; // 重置流位置
                        pbPreview.Image = Image.FromStream(ms);
                        _currentPreviewPath = path;
                    }
                }
            }
            catch (Exception)
            {
                // 图片可能损坏，忽略错误
            }
        }

        // 核心功能2：删除到回收站
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (listViewResults.CheckedItems.Count == 0)
            {
                MessageBox.Show("请先勾选要删除的图片。");
                return;
            }

            if (MessageBox.Show($"确定要将选中的 {listViewResults.CheckedItems.Count} 张图片移入回收站吗？",
                "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            int successCount = 0;

            // 倒序遍历，方便删除列表项
            for (int i = listViewResults.CheckedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem item = listViewResults.CheckedItems[i];
                string path = item.Tag.ToString();

                // 如果要删除的图片正在被预览，先清空预览
                if (path == _currentPreviewPath)
                {
                    if (pbPreview.Image != null) pbPreview.Image.Dispose();
                    pbPreview.Image = null;
                    _currentPreviewPath = "";
                }

                try
                {
                    // 使用 VB.NET 的 FileSystem 实现删除到回收站
                    FileSystem.DeleteFile(path,
                        UIOption.OnlyErrorDialogs,
                        RecycleOption.SendToRecycleBin);

                    listViewResults.Items.Remove(item); // 从界面移除
                    successCount++;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"删除 {Path.GetFileName(path)} 失败: {ex.Message}");
                }
            }

            MessageBox.Show($"成功移除 {successCount} 张图片到回收站。");
        }
    }
}