using System.Text;
namespace ReadTextFiles
{
    public class TextReader
    {
        public static void Main(String[] args)
        {
            StringBuilder stringBuilder = new StringBuilder("<Root>\n");
            string path = @"C:\\Users\\Mubsshir\\source\\repos\\TextReading\\TextReading\\hello.txt";
            FileInfo fileInfo = new FileInfo(path);
            string DPath = fileInfo.DirectoryName + "\\";
            Console.WriteLine(DPath);
            using (FileStream fs = new FileStream(path, FileMode.Open))
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
            Console.WriteLine(XML);
        }
    }
}