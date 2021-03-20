using System; //ada Exception disini
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
            try
            {
                string[] rute = initGraph.DFS("A", "H");
                foreach (var item in rute)
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                string[] lines = File.ReadAllLines(relativePath); //tiap index dari lines diisi sama baris dlm file

                // Hitung jumlah node
                int nNode = int.Parse(lines[0]); // Asumsi ukuran matrix paling besar segini, itutu jumlah sisi
                // Converts the string representation of a number to its 32-bit signed integer equivalent.
                Graph initGraph = new Graph(nNode);

                // Tambah daftar node ke dictionary
                // bisa pake split buat pecahin string
                string[] pairNode;
                int idx = 0;
                foreach (var line in lines)
                {
                    pairNode = line.Split(' ');
                    if (pairNode.Length == 2) //kalo isinya cuma satu username, ga dianggap
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
                return new Graph(0); //karna fungsi public static ini harus return graph
            }
            
        }
    }


}
