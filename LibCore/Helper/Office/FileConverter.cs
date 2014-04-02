using System;
using System.Text;
using System.IO;

namespace LibCore.Helper.Office
{
    public class FileConverter
    {
        public string FullFilePath { get; set; }
        public string FileToSave { get; set; }
        public string Url;
        private byte[] _convertedResult;

        public FileConverter()
        {
            _convertedResult = null;
        }

        public void DeleteFiles()
        {
            if (File.Exists(FileToSave))
                File.Delete(FileToSave);
            if (File.Exists(FullFilePath))
                File.Delete(FullFilePath);
        }
        public byte[] ReadConvertedFile()
        {
            var count = 0;
            ReadFileAgain:
            try
            {
                /*
                var ext = Path.GetExtension(FullFilePath);
                if (ext == ".xls" || ext == ".xlsx")
                {
                    return ReadXlsxFile();
                }
                */
                using (var fs = new FileStream(FileToSave, FileMode.Open, FileAccess.Read))
                {
                    var reader = new BinaryReader(fs);
                    _convertedResult = reader.ReadBytes((int)fs.Length);
                    reader.Close();
                    reader.Dispose();
                    fs.Close();
                    fs.Dispose();
                }
            }
            catch (Exception)
            {
                System.Threading.Thread.Sleep(100);
                if (++count == 3)
                {
                    throw;
                }
                goto ReadFileAgain;
            }
            return _convertedResult;
        }
        /*
        private byte[] ReadXlsxFile()
        {
            var fileName = Path.GetFileName(FileToSave);
            if (fileName == null) return _convertedResult;

            var directory = Path.GetDirectoryName(FileToSave) + "\\" + fileName.Split('.')[0] + "_files";

            var files = Directory.GetFiles(directory);
            for (var i = 0; i < files.Length - 1; i++)
            {
                if (Path.GetExtension(files[i]) == ".html")
                {
                    _convertedResult.Append(File.ReadAllText(files[i]).Replace("<![endif]>", ""));
                }
            }
            return _convertedResult;
        }
         * */
    }
}
