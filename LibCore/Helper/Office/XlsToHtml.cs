namespace LibCore.Helper.Office
{
    using System.IO;
    using System.Text;
    using Application = Microsoft.Office.Interop.Excel.Application;

    public class XlsToHtml : FileConverter, IConverter
    {
        public byte[] Convert()
        {
            var excel = new Application();

            if (File.Exists(FileToSave))
            {
                File.Delete(FileToSave);
            }
            try
            {
                excel.Workbooks.Open(Filename: FullFilePath);
                excel.Visible = false;
                if (excel.Workbooks.Count > 0)
                {
                    var wsEnumerator = excel.ActiveWorkbook.Worksheets.GetEnumerator();
                    object format = Microsoft.Office.Interop.Excel.XlFileFormat.xlHtml;
                    while (wsEnumerator.MoveNext())
                    {
                        var wsCurrent = (Microsoft.Office.Interop.Excel.Worksheet)wsEnumerator.Current;
                        wsCurrent.SaveAs(Filename: FileToSave, FileFormat: format);
                        break;
                    }
                    excel.Workbooks.Close();
                }
            }
            finally
            {
                excel.Application.Quit();
            }
            return base.ReadConvertedFile();
        }
        ~XlsToHtml()
        {
            //base.DeleteFiles();
        }
    }
}
