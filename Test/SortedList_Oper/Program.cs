using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortedList_Oper
{
    class Program
    {
        static void Main(string[] args)
        {


            // Create a new sorted list of strings, with string
            // keys.
            SortedList<string, string> openWith =
            new SortedList<string, string>();
 
            // Add some elements to the list. There are no 
            // duplicate keys, but some of the values are duplicates.
            openWith.Add("txt", "notepad.exe");
            openWith.Add("bmp", "paint.exe");
            openWith.Add("dib", "paint.exe");
            openWith.Add("rtf", "wordpad.exe");
            foreach(KeyValuePair<string, string> kvp in openWith)
            {
                Console.WriteLine(kvp.Key + ",\t" + kvp.Value);
            }

            SortedList objCarDetails = 
                new SortedList();
            objCarDetails.Add("090", "abc90");
            objCarDetails.Add("101", "abc101");
            objCarDetails.Add("102", "abc102");
            objCarDetails.Add("099", "abc99");
            objCarDetails.Add("103", "abc103");
            foreach (DictionaryEntry objDE in objCarDetails)
            {
                Console.WriteLine(objDE.Key + "\t" + objDE.Value);
            }

            Console.ReadLine();
        }
    }
}
