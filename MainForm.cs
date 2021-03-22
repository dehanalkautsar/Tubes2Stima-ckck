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
        Microsoft.Msagl.Drawing.Graph graphVisualizer;
        private string pilihanMode = "None";

        public MainForm()
        {
            InitializeComponent();
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
                string filename = openFileDialog.FileName;
                string[] filelines = File.ReadAllLines(filename);

                openedGraph = ReadFile.stringFileToGraph(filelines);
                labelFileName.Text = "." + filename.Replace(Directory.GetCurrentDirectory(), "");

                //create a form 
                System.Windows.Forms.Form form = new System.Windows.Forms.Form();
                //create a viewer object 
                Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
                //create a graph object 
                ConstructGraphVisualizer();
                Microsoft.Msagl.Drawing.Graph graph = graphVisualizer;

                viewer.Graph = graph;
                //associate the viewer with the form 
                visualGraph.SuspendLayout();
                viewer.Dock = System.Windows.Forms.DockStyle.Fill;
                visualGraph.Controls.Add(viewer);
                visualGraph.ResumeLayout();
                

                foreach (var node in openedGraph.getAllNodes())
                {
                    Console.WriteLine(node);
                }
            
            }
        }




        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
            
        }
    }
}
