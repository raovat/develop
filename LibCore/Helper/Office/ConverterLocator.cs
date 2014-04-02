namespace LibCore.Helper.Office
{
    using System.Linq;

    public class ConverterLocator
    {
        public static IConverter Converter(string fullFilePath, string fileToSave)
        {
            IConverter converter = null;
            var ext = fullFilePath.Split('.').Last().ToLower();
            switch (ext)
            {
                case "doc": converter = new DocToHtml { FileToSave = fileToSave, FullFilePath = fullFilePath };
                    break;
                case "docx": converter = new DocToHtml { FileToSave = fileToSave, FullFilePath = fullFilePath };
                    break;
                case "dot": converter = new DocToHtml { FileToSave = fileToSave, FullFilePath = fullFilePath };
                    break;
                case "dotx": converter = new DocToHtml { FileToSave = fileToSave, FullFilePath = fullFilePath };
                    break;
                case "rtf": converter = new DocToHtml { FileToSave = fileToSave, FullFilePath = fullFilePath };
                    break;
                case "xls": converter = new XlsToHtml { FileToSave = fileToSave, FullFilePath = fullFilePath };
                    break;
                case "xlsx": converter = new XlsToHtml { FileToSave = fileToSave, FullFilePath = fullFilePath };
                    break;
                case "txt": converter = new TxtToHtml() { FileToSave = fileToSave, FullFilePath = fullFilePath };
                    break;
            }
            return converter;
        }
    }
}
