using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            lexer my = new lexer();
            String data = "";

            //try
            //{
            //    data = new string(File.ReadAllBytes(@""))
            //   // data = new String(File.ReadAllBytes
            //   // (Paths.get("C:\\Users\\M.H.GH.K\\Desktop\\hes.txt")));
            //}
            //catch (IOException e)
            //{
            //    //e.printStackTrace();
            //}
            my.lexerAnalyzer(
                "if  123.545 2.  . /    .565 " +
                "( ( ( ) ) ) ( ( ( . . . . a= == == ==  * ** /" +
                " // / ) ( ., ;");
            Console.WriteLine();

            my.Print();

            Console.WriteLine(my.allOfTokens.Capacity);
        }
    }
}
