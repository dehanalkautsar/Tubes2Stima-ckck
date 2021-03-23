using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tubes2Stima_ckck
{
    public partial class FriendRecomendationForm : Form
    {
        private Graph openedGraph;
        private string pilihanMode;
        private string initialNode;
        private string targetNode;

        public FriendRecomendationForm(Graph _openedGraph, string _pilihanMode, string _initialNode, string _targetNode)
        {
            this.openedGraph = _openedGraph;
            this.pilihanMode = _pilihanMode;
            this.initialNode = _initialNode;
            this.targetNode = _targetNode;
            InitializeComponent();
            titleExploreFriend();
            pathExploreEditor();
            AddComponentFriendR();
        }

        public void titleExploreFriend()
        {
            string text = "Explore Friends Between: " + this.initialNode + " - " + this.targetNode;
            this.titleExplore.Text = text;
        }

        public void pathExploreEditor()
        {
            string text = "";

            //run explore friend code
            string[] arrayOfPath = this.openedGraph.ExploreFriend(this.initialNode, this.targetNode, this.pilihanMode);
            if (arrayOfPath.Length > 0)
            {
                int index = 0;
                text = text + arrayOfPath[index];
                while (index < arrayOfPath.Length - 1)
                {
                    text = text + " -> " + arrayOfPath[index + 1];
                    index++;
                }
                text = text + "\n";

                int nth = index - 1; //untuk keperluan nth connection
                if (nth == 1)
                {
                    text = text + "1st Degree";
                }
                else if (nth == 2)
                {
                    text = text + "2nd Degree";
                }
                else if (nth == 3)
                {
                    text = text + "3rd Degree";
                }
                else
                {
                    text = text + nth + "th Degree";
                }
            }

            else
            {
                text = text + "Tidak ada jalur koneksi yang tersedia \nAnda harus memulai koneksi baru itu sendiri\n";
            }

            this.pathExplore.Text = text;
        }

        public void AddComponentFriendR()
        {
            this.labelFriendRecomendation.Text = "Friend Recommendations for: " + initialNode;
            // EDIT DISINI
            int i = 0;
            this.SuspendLayout();
            Dictionary<string, List<string>> dict = openedGraph.allMutual(initialNode);
            //Dictionary<string, List<string>> allMutual(string username1)
            int offset = 0;
            // Ganti loop ini jadi apa yang mau dibuat
            foreach (KeyValuePair<string, List<string>> friend in dict.OrderByDescending(key => key.Value.Count()))
            {
                
                //Console.WriteLine("Key: {0}, Value: {1}", author.Key, author.Value.Count());
                // Label nodeLabel 
                Label nodeLabel = new Label();
                // Edit properties nodeLabel
                nodeLabel.Font = new System.Drawing.Font("Metropolis", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                nodeLabel.Location = new System.Drawing.Point(15, 110 + i * 55 + offset);
                nodeLabel.Name = "labelNode" + i.ToString();
                nodeLabel.Size = new System.Drawing.Size(487, 15);
                nodeLabel.Text = "Nama akun: " + friend.Key.ToString();
                // Tambah ke form
                this.Controls.Add(nodeLabel);

                // Label listMutualFriend
                Label listMutualFriend = new Label();
                int countMutual = friend.Value.Count();
                // Edit properties listMutualFriend
                listMutualFriend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
                listMutualFriend.Font = new System.Drawing.Font("Metropolis", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                listMutualFriend.Location = new System.Drawing.Point(17, 128 + i * 55 + offset);
                listMutualFriend.Name = "labelListMutualFriend" + i.ToString();
                listMutualFriend.Size = new System.Drawing.Size(487, 15 + countMutual * 15);
                listMutualFriend.Text = friend.Value.Count().ToString() + " Mutual Friend:\n";
                
                foreach(var item in friend.Value)
                {
                    listMutualFriend.Text = listMutualFriend.Text + "   "+ item.ToString() + "\n";
                    offset += 10;
                }
                

                // Tambah ke form
                this.Controls.Add(listMutualFriend);

                i++;

            }

            this.ResumeLayout(false);

        }

    
    }
}
