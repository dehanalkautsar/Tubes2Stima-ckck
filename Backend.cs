﻿using System;
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

    class Graph
    {
        private bool[,] adjacentMatrix;
        private int count_node;
        private Dictionary<string, int> node_dictionary;

        //Constructor
        public Graph(int countNode) {
            this.count_node = countNode;
            this.adjacentMatrix = new bool[count_node,count_node];
            this.node_dictionary = new Dictionary<string, int>();
        }

        public int getNumberOfNode()
        {
            return this.count_node;
        }

        public bool addToDictionary(string username, int index) {
            //add to dictionary -> <key: username, value: index>
            try {
                node_dictionary.Add(username,index);
                return true;
            } catch
            {
                //Console.WriteLine("Node sudah ada di dictionary");
                return false;
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

        public bool DFS(string currNode, string targetNode, ref bool[] visited, ref string[] rute)
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
                if (this.foundAdj(currNode,node.Key))
                {
                    if (!visited[node.Value])
                    {
                        found = DFS(node.Key, targetNode, ref visited, ref tempRute);
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
    }
}
