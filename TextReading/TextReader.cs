using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace TextReading
{
    public class FileTextReader
    {
        public static void ConvertToXML(string txtFilePath)
        {
            FileInfo fileInfo = new FileInfo(txtFilePath);
            string DPath = fileInfo.DirectoryName + "\\";
            StringBuilder stringBuilder = new StringBuilder("<Root>\n");
            using (FileStream fs = new FileStream(txtFilePath, FileMode.Open))
            {
                StreamReader streamReader = new StreamReader(fs);
                string? line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    stringBuilder.Append("  <Student ");
                    string[] words = line.Split(',');
                    foreach (string word in words)
                    {
                        stringBuilder.Append(word + " ");
                    }
                    stringBuilder.Append("/>\n");
                }
                streamReader.Close();
            }
            stringBuilder.Append("</Root>");
            string XML = stringBuilder.ToString();
            using (FileStream newFile = new FileStream(DPath + "new.xml", FileMode.OpenOrCreate))
            {
                StreamWriter sw = new StreamWriter(newFile);
                sw.Write(XML);
                sw.Close();
            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
