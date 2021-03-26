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
        
        //public static void Testadila(){
        //    Graph initGraph = ReadFile.inputGraphFile("test.txt");
        //    bool[] visited = new bool[initGraph.getNumberOfNode()];
        //    for (int i = 0; i < visited.Length; i++)
        //    {
        //        visited[i] = false;
        //    }
        //    String[] finalrute = new String[initGraph.getNumberOfNode() + 1];
        //    for (int i = 0; i < finalrute.Length; i++)
        //    {
        //        finalrute[i] = " ";
        //    }

        //    bool found = initGraph.doBFS("A", "H", ref visited, ref finalrute);
        //    if (found){
        //        foreach (var r in finalrute)
        //        {
        //            if (r != " "){
        //                Console.WriteLine(r);
        //            }   
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("Not Found");
        //    }
        //}

        public static void TestAdila()
        {
            Graph initGraph = ReadFile.inputGraphFile("test.txt");
            //initGraph.mutualFriend("A", "F", initGraph).ForEach(i => Console.Write("{0}\t", i));
            Dictionary<string, List<string>> mutualT = new Dictionary<string, List<string>>();
            mutualT = initGraph.allMutual("A");
            //initGraph.displayFriendR(mutualT);
        }
        
        public static void TestDehan() //testttt dehan
        {
            Graph initGraph = ReadFile.inputGraphFile("test.txt");
            string pilihan;
            Console.Write("Masukkan Pilihan Metode (BFS/DFS): ");
            pilihan = Console.ReadLine();
            try
            {
                string[] rute = initGraph.ExploreFriend("A", "H", pilihan);
                foreach (var item in rute)
                {
                    Console.WriteLine(item);
                }
                Graph.printRute(rute);
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
                string[] fileLines = File.ReadAllLines(relativePath); //tiap index dari lines diisi sama baris dlm file

                Graph initGraph = stringFileToGraph(fileLines);
                return initGraph;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message + "\n");
                Console.WriteLine("Exception: " + e.StackTrace + "\n");
                return new Graph(0); //karna fungsi public static ini harus return graph
            }
            
        }

        public static Graph stringFileToGraph(string[] fileLines)
        {
            // Hitung jumlah node
            int nRelation = int.Parse(fileLines[0]); // Asumsi ukuran matrix paling besar segini, itutu jumlah sisi
                                             // Converts the string representation of a number to its 32-bit signed integer equivalent.
            Graph initGraph = new Graph();

            // Tambah daftar node ke dictionary
            // bisa pake split buat pecahin string
            string[] pairNode;
            int idx = 0;
            int i = 0;
            foreach (var line in fileLines)
            {
                pairNode = line.Split(' ');
                if (pairNode.Length == 2) //kalo isinya cuma satu username, ga dianggap
                {
                    // Tambah ke dalam kamus jika belum ada di kamus;
                    if (initGraph.addToDictionary(pairNode[0], idx))
                    {
                        idx++;
                    }
                    if (initGraph.addToDictionary(pairNode[1], idx))
                    {
                        idx++;
                    }

                }
                i++;

                if (i > nRelation)
                {
                    break;
                }
            }

            i = 0;
            initGraph.initAdjacentMatrix(idx);
            foreach (var line in fileLines)
            {
                pairNode = line.Split(' ');
                if (pairNode.Length == 2) //kalo isinya cuma satu username, ga dianggap
                {
                    // Buat matrix ketetanggaan
                    initGraph.addAdj(pairNode[0], pairNode[1]);

                    //Console.WriteLine(pairNode[0] + " " + pairNode[1]);

                }
                i++;

                if (i > nRelation)
                {
                    break;
                }
            }
            // Return graph
            return initGraph;
        }
    }
}
