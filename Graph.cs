using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tubes2Stima_ckck
{
    class Graph
    {
        private bool[,] adjacentMatrix; //nentuin dimensi pake koma
        private int count_node; //ngitung node yang ada (aktif dan tidak)
        private Dictionary<string, int> node_dictionary; //nama orang, indeks di adjacent matriks

        //Constructor
        public Graph(int countNode)
        {
            this.count_node = countNode;
            this.adjacentMatrix = new bool[count_node, count_node]; //bikin adjacent matriks persegi
            this.node_dictionary = new Dictionary<string, int>();
        }

        public int getNumberOfNode()
        {
            return this.count_node;
        }

        public bool addToDictionary(string username, int index)
        {
            //add to dictionary -> <key: username, value: index>
            try
            {
                node_dictionary.Add(username, index);
                return true;
            }
            catch
            {
                //Console.WriteLine("Node sudah ada di dictionary");
                return false;
            }

        }

        public int foundIndex(string username)
        {
            //return index suatu username
            return node_dictionary[username]; //dict[key] ntar return value
        }

        public bool foundAdj(string username1, string username2)
        {
            //melihat apakah sebuah username index berkaitan dengan username index lainnya <mutual>
            int index1, index2;
            index1 = foundIndex(username1);
            index2 = foundIndex(username2);

            if (adjacentMatrix[index1, index2] == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void addAdj(string username1, string username2)
        {
            //add adjacent nodes to adjacentMatrix
            int index1, index2;
            index1 = foundIndex(username1);
            index2 = foundIndex(username2);

            if (!foundAdj(username1, username2))
            {
                adjacentMatrix[index1, index2] = true;
                adjacentMatrix[index2, index1] = true;
            }
        }

        public string[] DFS(string currNode, string targetNode)
        {
            bool[] visited = new bool[this.getNumberOfNode()];
            string[] rute = new string[0];
            bool found = this.doDFS(currNode, targetNode, ref visited, ref rute);
            if (found) {
                return rute;
            }
            else {
                throw new ExceptionGraphRuteDFSNotFound();
            }
            
        }

        private bool doDFS(string currNode, string targetNode, ref bool[] visited, ref string[] rute)
        {
            // Cek apakah sudah di target
            if (currNode == targetNode)
            {
                return true;
            }

            // Copy dulu rute yang udah diambil
            string[] tempRute = new string[rute.Length + 1];
            int i;
            for (i = 0; i < rute.Length; i++)
            {
                tempRute[i] = rute[i];
            }
            tempRute[i] = currNode;

            // Tandai telah dilewati
            int idx = this.foundIndex(currNode);
            visited[idx] = true;

            // Untuk rute sudah sesuai ditemukan
            bool found = false;

            foreach (var node in this.node_dictionary)
            {
                if (this.foundAdj(currNode, node.Key))
                {
                    if (!visited[node.Value])
                    {
                        found = doDFS(node.Key, targetNode, ref visited, ref tempRute);
                        if (found)
                        {
                            break;
                        }
                    }
                }
            }

            if (found)
            {
                rute = tempRute;
            }
            return found;
        }

        public bool BFS(string initNode, string targetNode){
            //buat antrian baru yang bersifat dynamic
            Queue rute = new Queue();
            //memasukkan initNode dalam queue
            rute.Enqueue(initNode);
            
            int idxrute; //index array finalrute
            bool Bfound; //udah goal ke targetNode atau belom

            idxrute = 0;
            Bfound = false;

            while(!Bfound && rute.Count > 0){ //iterasi sampai ketemu, atau queue abis
                finalrute[idxrute] = rute.Dequeue(); //dequeue, masukin ke finalrute
                if (finalrute[idxrute] == targetNode){
                    Bfound = true;
                } else {
                    foreach (var node in this.node_dictionary){
                    if (this.foundAdj(finalrute[idxrute], node.Key)){
                        if (!visited[node.Value]){
                            rute.Enqueue(node.Key);
                            visited[node.Value] = true;
                            }
                        } //else, skip
                    } 
                    idxrute++;
                }   
            }
            return Bfound;
        }
    }

    
    public class ExceptionGraphRuteDFSNotFound : Exception
    {
        public ExceptionGraphRuteDFSNotFound() : base("Graph: DFS rute not found")
        {
        }
    }
}
