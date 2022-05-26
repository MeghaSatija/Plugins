using System;
using System.Text;
using  nullpointer.Metaphone;

namespace Soundex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter any Name");
            string Name = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Entered Name befor Soundex Logic is: " +Name);

          DoubleMetaphone mp = new DoubleMetaphone(Name);
            Console.WriteLine("Double Metaphone primary Key : " +mp.PrimaryKey);
            Console.WriteLine("Double metaphone Alternate Key : " +mp.AlternateKey);
            Console.WriteLine("Soundex Code : " +soundexlogic(Name));
            Console.ReadKey();
     
        }
        public static string soundexlogic( string data) 
        {
            StringBuilder result = new StringBuilder();

            if (data != null && data.Length > 0)
            {
                string previousCode = "", currentCode = "", currentLetter = "";
                result.Append(data[0]); // keep initial char

                for (int i = 0; i < data.Length; i++) //start at 0 in order to correctly encode "Pf..."
                {
                    currentLetter = data[i].ToString().ToLower();
                    currentCode = "";

                    if ("bfpv".Contains(currentLetter))
                        currentCode = "1";
                    else if ("cgjkqsxz".Contains(currentLetter))
                        currentCode = "2";
                    else if ("dt".Contains(currentLetter))
                        currentCode = "3";
                    else if (currentLetter == "l")
                        currentCode = "4";
                    else if ("mn".Contains(currentLetter))
                        currentCode = "5";
                    else if (currentLetter == "r")
                        currentCode = "6";

                    if (currentCode != previousCode && i > 0) // do not add first code to result string
                        result.Append(currentCode);

                    if (result.Length == 4) break;

                    previousCode = currentCode; // always retain previous code, even empty
                }
            }
            if (result.Length < 4)
                result.Append(new String('0', 4 - result.Length));

            return result.ToString().ToUpper();
        }

    }
}
