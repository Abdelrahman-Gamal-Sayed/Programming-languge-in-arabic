using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Step_4
{
    class texthandel
    {
        static public string[] linsArrayword(string[] lins)
        {
            char[] c = { ' ' };
            string temp = "";
            foreach (string x in lins)
                temp = "  " + temp + x;
            string[] words = temp.Split(c, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }



        static public string[] WordsArray(string text)
        {

            string[] lines = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.RemoveEmptyEntries);
            string[] txttoarry = linsArrayword(lines);
            return txttoarry;
        }

    }
}
