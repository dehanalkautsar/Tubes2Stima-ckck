using Microsoft.Msagl.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes2Stima_ckck
{
    public partial class MainForm : Form
    {
        private Graph openedGraph;
        private Microsoft.Msagl.Drawing.Graph graphVisualizer;
        private string pilihanMode = "";
        private string initialNode = "";
        private string targetNode = "";

        public MainForm()
        {
            InitializeComponent();
            this.radioButtonBFS.Checked = true;
            pilihanMode = "BFS";
        }

        private void ConstructGraphVisualizer()
        {
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            foreach (var node in openedGraph.getAllNodes())
            {
                var simpul = graph.AddNode(node);
                simpul.Attr.Shape = Shape.Circle;
            }


            int nNode = openedGraph.getNumberOfNode();
            for (int i = 0; i < nNode; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    if (openedGraph.foundAdj(i, j))
                    {
                        var sisi = graph.AddEdge(openedGraph.indexToName(i), openedGraph.indexToName(j));
                        sisi.Attr.ArrowheadAtTarget = ArrowStyle.None;
                        sisi.Attr.ArrowheadAtSource = ArrowStyle.None;
                    }
                }
            }

            this.graphVisualizer = graph;
            //return graph;
        }

        private void ResetGraphVisualizer()
        {
            // Reset ke style awal

            // Inisialisasi viewer baru
            if (this.graphVisualizer == null)
            {
                Console.WriteLine("Error, graph kosong");
            }
            else
            {
                foreach (var simpul in graphVisualizer.Nodes)
                {
                    simpul.Attr.FillColor = Microsoft.Msagl.Drawing.Color.White;
                }

                foreach (var sisi in graphVisualizer.Edges)
                {
                    sisi.Attr.Color = Microsoft.Msagl.Drawing.Color.Black;
                }
                // Gambar Graph Visualizer
                DrawGraphVisualizer();
            }
                
        }

        private void DrawPathInGraphVisualizer(string[] rute)
        {
            ResetGraphVisualizer();
            if (this.graphVisualizer == null)
            {
                Console.WriteLine("Error, graph kosong");
            }
            else
            {
                Node simpulLama = null;
                // Ubah warna node
                foreach (var node in rute)
                {
                    var simpul = graphVisualizer.FindNode(node);
                    simpul.Attr.FillColor = Microsoft.Msagl.Drawing.Color.Aqua;
                    if (simpulLama != null)
                    {
                        foreach (var sisiKeluar in simpulLama.Edges)
                        {
                            foreach (var sisiMasuk in simpul.Edges)
                            {
                                if (sisiKeluar == sisiMasuk) // sisi yang sama
                                {
                                    sisiKeluar.Attr.Color = Microsoft.Msagl.Drawing.Color.DeepPink;
                                }
                            }
                        }
                    }

                    simpulLama = simpul;
                }
                // Gambar Graph Visualizer
                DrawGraphVisualizer();
                
            }  
        }

        private void DrawGraphVisualizer()
        {
            // Pastikan graphVisualizer tidak null
            if (this.graphVisualizer != null)
            {
                // Inisialisasi viewer baru
                Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                viewer.Graph = graphVisualizer;
                // Pasangkan di Panel
                PanelGraphVisualizer.SuspendLayout();
                viewer.Dock = System.Windows.Forms.DockStyle.Fill;
                PanelGraphVisualizer.Controls.Clear();
                PanelGraphVisualizer.Controls.Add(viewer);
                PanelGraphVisualizer.ResumeLayout();
            }
        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                InitialDirectory = @".\",
                Title = "Browse Text Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "txt",
                Filter = "txt files (*.txt)|*.txt",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {

                // Baca Graph dari file yang dipilih
                string path = openFileDialog.FileName;
                string[] filelines = File.ReadAllLines(path);

                // Buat variabel Graph yang sedang dibuka
                openedGraph = ReadFile.stringFileToGraph(filelines);

                // Nama label fileName
                labelFileName.Text = openFileDialog.SafeFileName;

                // Construct GraphVisualizer
                ConstructGraphVisualizer();
                // Gambar GraphVisualizer
                DrawGraphVisualizer();

                foreach (var node in openedGraph.getAllNodes())
                {
                    Console.WriteLine(node);
                }

                ComboBoxInitialNodeInit();
                ComboBoxTargetNodeInit();

            }
        }

        private void ComboBoxInitialNodeInit()
        {
            comboBoxInitial.Items.Clear();
            foreach (var node in openedGraph.getAllNodes())
            {
                comboBoxInitial.Items.Add(node);
            }
        }

        private void ComboBoxTargetNodeInit()
        {
            comboBoxTarget.Items.Clear();
            foreach (var node in openedGraph.getAllNodes())
            {
                comboBoxTarget.Items.Add(node);
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonBFS_CheckedChanged(object sender, EventArgs e)
        {
            pilihanMode = "BFS";
        }

        private void radioButtonDFS_CheckedChanged(object sender, EventArgs e)
        {
            pilihanMode = "DFS";
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            // Tambah cek kasus apakah semua syarat sudah terpenuhi

            FriendRecomendationForm childForm = new FriendRecomendationForm(this.openedGraph,this.pilihanMode,this.initialNode,this.targetNode);
            childForm.ShowDialog();
        }

        private void comboBoxInitial_SelectedIndexChanged(object sender, EventArgs e)
        {
            initialNode = comboBoxInitial.SelectedItem.ToString();
            if (initialNode != "" && targetNode != "" && initialNode != targetNode)
            {
                var rute = openedGraph.ExploreFriend(initialNode, targetNode, pilihanMode);
                if (rute.Length != 0)
                {
                    DrawPathInGraphVisualizer(rute);
                    return;
                }
            }
            ResetGraphVisualizer();
            //Console.WriteLine(initialNode);
        }

        private void comboBoxTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            targetNode = comboBoxTarget.SelectedItem.ToString();
            if (initialNode != "" && targetNode != "" && initialNode != targetNode)
            {
                var rute = openedGraph.ExploreFriend(initialNode, targetNode, pilihanMode);
                if (rute.Length != 0)
                {
                    DrawPathInGraphVisualizer(rute);
                    return;
                }
            }
            ResetGraphVisualizer();
            //Console.WriteLine(targetNode);
        }      

        private void resetButton_Click(object sender, EventArgs e)
        {
            ResetGraphVisualizer();
        }
    }
}
