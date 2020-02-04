using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Google Hashcode 2020 Practice Question*/
            //Input the file name
            string fileName = "e_also_big";
            //Get the data in the file
            string[] inputArr = File.ReadAllLines("C:/VS19Projects/ConsoleApp1/ConsoleApp1/HashcodeIn/" + fileName + ".in");
            //Get the maximum slice from the data
            int max = Convert.ToInt32(inputArr[0].Split()[0]);
            //Get the pizzas from the file
            string[] ecIn = inputArr[1].Split();
            int[] ecCn = new int[ecIn.Length];
            for (int i = 0; i < ecIn.Length; i++)
            {
                ecCn[i] = Convert.ToInt32(ecIn[i]);
            }
            //Get average slice
            int avr = ecCn.Length / 2, sum = ecCn[avr], inc = 1;
            //Create a list to store pizza numbers
            List<int> store = new List<int>();
            store.Add(avr);
            //Add the pizzas in the list
            while (sum <= max && (avr - inc) >= 0 && (avr + inc) < ecCn.Length)
            {
                if ((sum + ecCn[avr - inc]) <= max)
                {
                    sum = sum + ecCn[avr - inc];
                    store.Add(avr - inc);
                }                    
                if ((sum + ecCn[avr + inc]) <= max)
                {
                    sum = sum + ecCn[avr + inc]; 
                    store.Add(avr + inc);
                }
                else
                {
                    inc++;
                    while (sum <= max && (avr - inc) >= 0)
                    {
                        if ((sum + ecCn[avr - inc]) <= max)
                        {
                            sum = sum + ecCn[avr - inc];
                            store.Add(avr - inc);
                        }
                        inc++;
                    }
                }
                inc++;
            }
            //Rearrange the pizzas
            store.Sort();
            //Give the output
            string output = store.Count.ToString() + Environment.NewLine;
            for(int i = 0; i < store.Count; i++)
            {
                if (i != store.Count - 1) { output += store[i] + " "; }
                else { output += store[i]; }
            }
            //Create the output file
            File.WriteAllText("C:/VS19Projects/ConsoleApp1/ConsoleApp1/HashcodeOut/" + fileName + ".out", output);
        }
    }
}
