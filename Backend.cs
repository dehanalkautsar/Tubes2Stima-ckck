using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Tubes2Stima_ckck
{
    class Backend
    {
        /* Test Azhar */
        public static void TestAzhar()
        {
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
            else
            {
                Console.WriteLine("Not Found");
            }
        }
            
        
    }

    class ReadFile
    {
        public static Graph inputGraphFile(string namaFile)
        {
            try 
            {
                string relativePath = @"./data/" + namaFile;  
                //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relativePath);
                // Baca File
                string[] lines = File.ReadAllLines(relativePath);

                // Hitung jumlah node
                int nNode = int.Parse(lines[0]); // Asumsi ukuran matrix paling besar segini

                Graph initGraph = new Graph(nNode);

                // Tambah daftar node ke dictionary
                // bisa pake split buat pecahin string
                string[] pairNode;
                int idx = 0;
                foreach (var line in lines)
                {
                    pairNode = line.Split(' ');
                    if (pairNode.Length == 2)
                    {
                        // Tambah ke dalam kamus jika belum ada di kamus;
                        if (initGraph.addToDictionary(pairNode[0],idx))
                        {
                            idx++;
                        }
                        if (initGraph.addToDictionary(pairNode[1], idx))
                        {
                            idx++;
                        }
                        // Buat matrix ketetanggaan
                        initGraph.addAdj(pairNode[0], pairNode[1]);

                        Console.WriteLine(pairNode[0] + " " + pairNode[1]);
                        
                    }
                }
                // Return graph
                return initGraph;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message + "\n");
                Console.WriteLine("Exception: " + e.StackTrace + "\n");
                return new Graph(0);
            }
            
        }
    }


}
