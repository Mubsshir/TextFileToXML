using System.Text;
namespace TextReading
{
    public class TextReader
    {
        public static void Main(String[] args)
        {
            string path = @"C:\\Users\\Mubsshir\\source\\repos\\TextReading\\TextReading\\hello.txt";
            FileTextReader.ConvertToXML(path);
        }
    }
}