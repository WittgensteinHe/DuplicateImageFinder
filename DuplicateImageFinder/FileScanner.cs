using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace DuplicateImageFinder
{
    public class FileScanner
    {
        private List<string> _allowedExtensions;

        public FileScanner(List<string> extensions)
        {
            _allowedExtensions = extensions.Select(e => e.ToLower()).ToList();
        }

        public async Task<Dictionary<string, List<string>>> ScanForDuplicatesAsync(string rootPath, IProgress<string> progress)
        {
            return await Task.Run(() =>
            {
                var allFiles = new List<string>();
                progress?.Report("正在遍历文件...");
                SafeGetFiles(rootPath, allFiles);

                progress?.Report($"共找到 {allFiles.Count} 个文件，正在按大小预筛...");

                // 第一步：按大小分组
                var sizeGroups = allFiles
                    .Select(f => new FileInfo(f))
                    .GroupBy(f => f.Length)
                    .Where(g => g.Count() > 1)
                    .ToList();

                var duplicateGroups = new Dictionary<string, List<string>>();
                int processed = 0;

                // 第二步：计算MD5
                foreach (var group in sizeGroups)
                {
                    processed++;
                    if (processed % 10 == 0) progress?.Report($"正在分析第 {processed}/{sizeGroups.Count} 组...");

                    var hashGroup = new Dictionary<string, List<string>>();
                    foreach (var fileInfo in group)
                    {
                        string hash = ComputeMD5(fileInfo.FullName);
                        if (string.IsNullOrEmpty(hash)) continue; // 文件可能被占用，跳过

                        if (!hashGroup.ContainsKey(hash)) hashGroup[hash] = new List<string>();
                        hashGroup[hash].Add(fileInfo.FullName);
                    }

                    foreach (var kvp in hashGroup.Where(h => h.Value.Count > 1))
                    {
                        duplicateGroups.Add(kvp.Key, kvp.Value);
                    }
                }
                return duplicateGroups;
            });
        }

        private void SafeGetFiles(string path, List<string> fileList)
        {
            try
            {
                var files = Directory.GetFiles(path);
                foreach (var file in files)
                {
                    if (_allowedExtensions.Contains(Path.GetExtension(file).ToLower()))
                        fileList.Add(file);
                }
                foreach (var dir in Directory.GetDirectories(path))
                {
                    SafeGetFiles(dir, fileList);
                }
            }
            catch { /* 忽略权限错误 */ }
        }

        private string ComputeMD5(string filePath)
        {
            try
            {
                using (var md5 = MD5.Create())
                using (var stream = File.OpenRead(filePath))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
                }
            }
            catch { return null; }
        }
    }
}