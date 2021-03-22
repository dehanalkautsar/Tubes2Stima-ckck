﻿using System;
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
            AddComponent();
        }

        public void AddComponent()
        {
            // EDIT DISINI
            int i = 2;
            this.SuspendLayout();

            // Ganti loop ini jadi apa yang mau dibuat
            while (i < 8)
            { 
                // Label nodeLabel 
                Label nodeLabel = new Label();
                // Edit properties nodeLabel
                nodeLabel.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                nodeLabel.Location = new System.Drawing.Point(20, 120 + i * 55);
                nodeLabel.Name = "labelNode" + i.ToString();
                //nodeLabel.Size = new System.Drawing.Size(262, 23);
                nodeLabel.Text = "Node" + i.ToString();
                // Tambah ke form
                this.Controls.Add(nodeLabel);

                // Label listMutualFriend
                Label listMutualFriend = new Label();
                // Edit properties listMutualFriend
                listMutualFriend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
                listMutualFriend.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                listMutualFriend.Location = new System.Drawing.Point(20, 140 + i * 55);
                listMutualFriend.Name = "labelListMutualFriend" + i.ToString();
                //listMutualFriend.Size = new System.Drawing.Size(487, 38);
                listMutualFriend.Text = "List Mutual Friend" + i.ToString();
                // Tambah ke form
                this.Controls.Add(listMutualFriend);

                i++;
            }
            this.ResumeLayout(false);

        }

    }
}
