using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment
{
    internal static class DictionaryEnglish
    {
        public static string[] Line { get; set; }

        static DictionaryEnglish()
        {
            //Line = File.ReadAllText("dictionary_english.txt");
            Line = File.ReadAllLines("dictionary_english.txt");
        }

    }

}
