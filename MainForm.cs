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
        private string method = "None";

        public MainForm()
        {
            InitializeComponent();
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
                    for (int j = 0; j < nNode; j++)
                    {
                        //if (openedGraph.foundAdj(openedGraph.))
                        //{

                        //}
                    }
                }

                //graph.AddNode("A");
                //var Edge = graph.AddEdge("47", "52");
                //{
                //    Edge.Attr.ArrowheadAtTarget = ArrowStyle.None;
                //    Edge.Attr.ArrowheadAtSource = ArrowStyle.None;
                //    //ArrowStyle.
                //}

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
            method = "BFS";
        }

        private void radioButtonDFS_CheckedChanged(object sender, EventArgs e)
        {
            method = "DFS";
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            //create a form 
            System.Windows.Forms.Form form = new System.Windows.Forms.Form();
            //create a viewer object 
            Microsoft.Msagl.GraphViewerGdi.GViewer viewer = new Microsoft.Msagl.GraphViewerGdi.GViewer();
            //create a graph object 
            Microsoft.Msagl.Drawing.Graph graph = new Microsoft.Msagl.Drawing.Graph("graph");
            //create the graph content 
            //graph.AddNode("A");
            //graph.
            var Edge = graph.AddEdge("47", "52");
            {
                Edge.Attr.ArrowheadAtTarget = ArrowStyle.None;
                Edge.Attr.ArrowheadAtSource = ArrowStyle.None;
                //ArrowStyle.
            }
            //graph.AddEdge("A", "B");
            //graph.AddEdge("B", "C");
            //graph.AddEdge("A", "C").Attr.Color = Microsoft.Msagl.Drawing.Color.Green;
            //graph.FindNode("A").Attr.FillColor = Microsoft.Msagl.Drawing.Color.Magenta;
            //graph.FindNode("B").Attr.FillColor = Microsoft.Msagl.Drawing.Color.MistyRose;
            //Microsoft.Msagl.Drawing.Node c = graph.FindNode("C");
            //c.Attr.FillColor = Microsoft.Msagl.Drawing.Color.PaleGreen;
            //c.Attr.Shape = Microsoft.Msagl.Drawing.Shape.Diamond;
            //bind the graph to the viewer 
            viewer.Graph = graph;
            //associate the viewer with the form 
            visualGraph.SuspendLayout();
            //form.SuspendLayout();
            viewer.Dock = System.Windows.Forms.DockStyle.Fill;
            visualGraph.Controls.Add(viewer);
            //form.Controls.Add(viewer);
            visualGraph.ResumeLayout();
            //form.ResumeLayout();
            //show the form 
            //form.ShowDialog();
        }
    }
}
