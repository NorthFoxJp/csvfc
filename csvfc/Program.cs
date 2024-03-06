using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvfc
{
    internal class Program
    {
        static private String[] SourceLinesA = null;
        static private String[] SourceLinesB = null;

        static void Main(string[] args)
        {
            try
            {
                String filePathNameA = args[0];
                String filePathNameB = args[1];

                String fileNameA = Path.GetFileName(filePathNameA);
                String fileNameB = Path.GetFileName(filePathNameB);

                SourceLinesA = File.ReadAllLines(filePathNameA, Encoding.UTF8);
                SourceLinesB = File.ReadAllLines(filePathNameB, Encoding.UTF8);

                Int32 lineCount = 0;
                foreach(String lineA in SourceLinesA)
                {
                    ++lineCount;
                    Boolean hit = false;
                    foreach(String lineB in SourceLinesB)
                    {
                        if (lineA == lineB)
                        {
                            hit = true;
                            break;
                        }
                    }

                    // fileAの行がfileBに含まれていない
                    if(hit == false)
                    {
                        Console.WriteLine(lineCount.ToString() + "," + fileNameA + "," + lineA);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("完了しました。何かのキーを押してください。");
            Console.ReadKey();
        }
    }
}
