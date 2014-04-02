namespace LibCore.Helper.Office
{
    using System.IO;

    public class TxtToHtml : FileConverter, IConverter
    {
        public byte[] Convert()
        {
            if (File.Exists(FileToSave))
            {
                File.Delete(FileToSave);
            }

            FileStream fsRead = new FileStream(FullFilePath, FileMode.Open, FileAccess.Read);
            StreamReader srRead = new StreamReader(fsRead);
            string content = srRead.ReadToEnd();
            srRead.Close();
            srRead.Dispose();
            fsRead.Close();
            fsRead.Dispose();

            FileStream fs = new FileStream(FileToSave, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(fs);
            sw.WriteLine("<HTML>");
            sw.WriteLine("<BODY>");
            sw.WriteLine("<PRE>");
            sw.Write(content);
            sw.WriteLine("</PRE>");
            sw.WriteLine("</BODY>");
            sw.WriteLine("</HTML>");
            sw.Flush();
            sw.Close();
            sw.Dispose();
            fs.Close();
            fs.Dispose();

            return base.ReadConvertedFile();
        }
        ~TxtToHtml()
        {
            //base.DeleteFiles();
        }
    }
}
