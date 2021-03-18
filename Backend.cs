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

        
    }

    class ReadFile
    {
        public static void inputGraphFile(string namaFile)
        {
            try 
            {
                
                string relativePath = @"./data/" + namaFile;  
                //string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), relativePath);
                // Baca File
                string[] lines = File.ReadAllLines(relativePath);

                // Hitung jumlah node
                int nNode = int.Parse(lines[0]);
                int i = 0;

                //Graph initGraph = new Graph(nNode);

                // Tambah daftar node ke dictionary
                // bisa pake split buat pecahin string
                string[] pairNode;
                foreach (var line in lines)
                {
                    pairNode = line.Split(' ');
                    if (pairNode.Length == 2)
                    {
                        Console.WriteLine(pairNode[0] + " " + pairNode[1]);
                    }
                }

                // Buat matrix ketetanggaan

                // Return graph
                //return initGraph;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message + "\n");
                throw e;
            }
            
        }
    }

    class Graph
    {
        private bool[,] adjacentMatrix;
        private int count_node;
        private Dictionary<string, int> node_dictionary;

        //Constructor
        public Graph(int countNode) {
            adjacentMatrix = new bool[count_node,count_node];
            this.count_node = countNode;
            node_dictionary = new Dictionary<string,int>();
        }

        public void addToDictionary(string username, int index) {
            //add to dictionary -> <key: username, value: index>
            try {
                node_dictionary.Add(username,index);
            } catch
            {
                Console.WriteLine("Node sudah ada di dictionary");
            }
            
        }

        public int foundIndex(string username) {
            //return index suatu username
            return node_dictionary[username];
        }

        public bool foundAdj(string username1, string username2) {
            //melihat apakah sebuah username index berkaitan dengan username index lainnya <mutual>
            int index1, index2;
            index1 = foundIndex(username1);
            index2 = foundIndex(username2);

            if (adjacentMatrix[index1,index2] == true) {
                return true;
            }
            else {
                return false;
            }
        }

        public void addAdj(string username1, string username2) {
            //add adjacent nodes to adjacentMatrix
            int index1, index2;
            index1 = foundIndex(username1);
            index2 = foundIndex(username2);

            if (!foundAdj(username1,username2)) {
                adjacentMatrix[index1,index2] = true;
                adjacentMatrix[index2,index1] = true;
            }
        }
    }
}
