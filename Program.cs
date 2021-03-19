using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes2Stima_ckck
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            Console.WriteLine("Hello World");

            Graph initGraph = ReadFile.inputGraphFile("test.txt");
            bool[] visited = new bool[initGraph.getNumberOfNode()];
            for (int i = 0; i < visited.Length; i++)
            {
                visited[i] = false;
            }
            string[] rute = new string[0];

            bool found = initGraph.DFS("A", "H", ref visited, ref rute);
            if (found)
            {
                foreach (var r in rute)
                {
                    Console.WriteLine(r);
                }
            }


            Console.WriteLine("Press Any Key To Continue..");
            Console.ReadLine();

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
        }
    }
}
