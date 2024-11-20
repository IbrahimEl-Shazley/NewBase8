using System.Collections.Generic;
using System.IO;

namespace NewBase.Core.Helpers.IO
{
    public static class IOHelper
    {
        public static void CreateDirectoryIfNotExist(string path)
        {
            try { if (!Directory.Exists(path)) Directory.CreateDirectory(path); } catch { }
        }

        public static string ReadFile(string path)
        {
            if (FileExists(path))
                return File.ReadAllText(path);
            else return string.Empty;
        }

        public static void WriteToFile(string path, string contents)
        {
            CreateFileIfNotExist(path);
            File.WriteAllText(path, contents);
        }

        public static void CreateFileIfNotExist(string path)
        {
            try { if (!File.Exists(path)) File.Create(path).Dispose(); } catch { }
        }

        public static string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private static bool FileExists(string path)
        {
            return File.Exists(path);
        }

        private static Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"},
                {".webp", "image/webp"}
            };
        }
    }
}
