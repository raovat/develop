namespace LibCore.Helper.Office
{
    using System.IO;
    using Microsoft.Office.Interop.Word;
    using Application = Microsoft.Office.Interop.Word.Application;

    public class DocToHtml : FileConverter, IConverter
    {
        public byte[] Convert()
        {
            var objWord = new Application();

            if (File.Exists(FileToSave))
            {
                File.Delete(FileToSave);
            }
            try
            {
                objWord.Documents.Open(FileName: FullFilePath);
                objWord.Visible = false;
                if (objWord.Documents.Count > 0)
                {
                    var oDoc = objWord.ActiveDocument;
                    oDoc.SaveAs(FileName: FileToSave, FileFormat: WdSaveFormat.wdFormatHTML);
                    oDoc.Close(SaveChanges: false);
                }
            }
            finally
            {
                objWord.Application.Quit(SaveChanges: false);
            }
            return base.ReadConvertedFile();
        }
        ~DocToHtml()
        {
            //base.DeleteFiles();
        }
    }
}
