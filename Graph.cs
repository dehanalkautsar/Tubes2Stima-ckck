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

        // Tanpa adjacent Matrix
        public Graph()
        {
            this.count_node = 0;
            this.adjacentMatrix = new bool[0, 0];
            this.node_dictionary = new Dictionary<string, int>();
        }

        // Dengan adjacent Matrix
        public Graph(int countNode)
        {
            this.count_node = countNode;
            this.adjacentMatrix = new bool[count_node, count_node]; //bikin adjacent matriks persegi
            this.node_dictionary = new Dictionary<string, int>();
        }

        public void initAdjacentMatrix(int countNode)
        {
            this.count_node = countNode;
            this.adjacentMatrix = new bool[count_node, count_node]; //bikin adjacent matriks persegi
        }

        //GETTERS
        public int getNumberOfNode()
        {
            return this.count_node;
        }

        public string[] getAllNodes() {
            // int length_node_dictionary = this.node_dictionary.Count;
            string[] nodes = new string[this.node_dictionary.Count];
            int i = 0;
            foreach (var node in this.node_dictionary) {
                nodes[i] = node.Key;
                i++;
            }

            return nodes;
        }

        public string indexToName(int index) { //translate index (values) to uname (keys)
            foreach (string keyVar in node_dictionary.Keys) {
                if (node_dictionary[keyVar] == index) {
                    return keyVar;
                }
            }
            return null;
        }

        //END OF GETTERS
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

        public bool foundAdj(int index1, int index2) //overloading parameter -> int index
        {
            return adjacentMatrix[index1, index2];
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
                // Copy dulu rute yang udah diambil
                string[] ruteFinal = new string[rute.Length + 1];
                int i;
                for (i = 0; i < rute.Length; i++)
                {
                    ruteFinal[i] = rute[i];
                }
                ruteFinal[i] = targetNode;
                return ruteFinal;
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

        public string[] BFS(string currNode, string targetNode)
        {
            bool[] visited = new bool[this.getNumberOfNode()];
            string[] rute = new string[this.getNumberOfNode() + 1];
            for (int i = 0; i < rute.Length; i++) {
                rute[i] = " ";
            }
            bool found = this.doBFS(currNode, targetNode, ref visited, ref rute);


            if (found) {
                //buat pathnya dalam bentuk list terbalik
                List<string> path = new List<string>();
                path.Add(targetNode); //masukin targetNode
                while (!path.Contains(currNode)) //looping sampe ketemu currNode di dalam list
                {
                    int j = 0;
                    string nodeToBeChecked = path[path.Count - 1]; //ambil elemen terakhir
                    int indexInRute;

                    int k = 0;
                    while (rute[k] != nodeToBeChecked)
                    {
                        k++;
                    }
                    indexInRute = k; //indexInRute adalah indeksnya elemen terakhir list

                    bool ketemuDiRute = false;
                    while (j < indexInRute && !ketemuDiRute) //looping sampe ketemu adj nya
                    {
                        if (foundAdj(rute[j], nodeToBeChecked))
                        {
                            ketemuDiRute = true;
                            path.Add(rute[j]);
                        }
                        else
                        {
                            j++;
                        }
                    }
                }
                //putarbalik listnya
                path.Reverse();
                //ubah list ke array path
                string[] arrayPath = path.ToArray();



                return arrayPath;
            }
            else {
                throw new ExceptionGraphRuteBFSNotFound();
            }
            
        }

        private bool doBFS(string initNode, string targetNode, ref bool[] visited ,ref string[] finalrute){
            //buat antrian baru yang bersifat dynamic
            Queue<string> rute = new Queue<string>();
            //memasukkan initNode dalam queue
            rute.Enqueue(initNode);
            visited[this.foundIndex(initNode)] = true;
            
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

        public string[] ExploreFriend(string username1, string username2, string pilihan) {
            Graph initGraph = ReadFile.inputGraphFile("test.txt");
            if (pilihan == "DFS") {
                try
                {
                    string[] rute = initGraph.DFS(username1, username2);
                    // foreach (var item in rute)
                    // {
                    //     Console.WriteLine(item);
                    // }
                    return rute;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new string[0];
                }
            }
            else if (pilihan == "BFS") {
                try
                {
                    string[] rute = initGraph.BFS(username1, username2);
                    
                    //int count = 0;

                    //for (int i = 0; i < rute.Length; i++)
                    //{
                    //    Console.WriteLine(rute[i]);
                    //}

                    //while (rute[count] != " ") {
                    //    count++;
                    //}
                    ////Console.WriteLine("check");
                    //string[] finalrute = new string[count];

                    //for (int i = 0; i < count; i++) {
                    //    finalrute[i] = rute[i];
                    //}
                    //// foreach (var item in rute)
                    //// {
                    ////     Console.WriteLine(item);
                    //// }
                    return rute;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new string[0];
                }
            }
            return new string[0];
        }
    }

    
    public class ExceptionGraphRuteDFSNotFound : Exception
    {
        public ExceptionGraphRuteDFSNotFound() : base("Graph: DFS rute not found")
        {
        }
    }

    public class ExceptionGraphRuteBFSNotFound : Exception
    {
        public ExceptionGraphRuteBFSNotFound() : base("Graph: BFS rute not found")
        {
        }
    }
}
