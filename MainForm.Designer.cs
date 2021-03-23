
namespace Tubes2Stima_ckck
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.labelFileName = new System.Windows.Forms.Label();
            this.PanelGraphVisualizer = new System.Windows.Forms.Panel();
            this.radioButtonBFS = new System.Windows.Forms.RadioButton();
            this.radioButtonDFS = new System.Windows.Forms.RadioButton();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.comboBoxInitial = new System.Windows.Forms.ComboBox();
            this.comboBoxTarget = new System.Windows.Forms.ComboBox();
            this.buttonSubmit = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(508, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dehan Mencari Teman";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(157, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "Graph File";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(14, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(157, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Algorithm";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(156, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = ":";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(156, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(15, 24);
            this.label5.TabIndex = 4;
            this.label5.Text = ":";
            // 
            // BrowseButton
            // 
            this.BrowseButton.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowseButton.Location = new System.Drawing.Point(177, 85);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(112, 30);
            this.BrowseButton.TabIndex = 5;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // labelFileName
            // 
            this.labelFileName.AutoSize = true;
            this.labelFileName.Font = new System.Drawing.Font("Comic Sans MS", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFileName.Location = new System.Drawing.Point(295, 92);
            this.labelFileName.Name = "labelFileName";
            this.labelFileName.Size = new System.Drawing.Size(0, 20);
            this.labelFileName.TabIndex = 6;
            // 
            // PanelGraphVisualizer
            // 
            this.PanelGraphVisualizer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelGraphVisualizer.Location = new System.Drawing.Point(12, 170);
            this.PanelGraphVisualizer.Name = "PanelGraphVisualizer";
            this.PanelGraphVisualizer.Size = new System.Drawing.Size(508, 276);
            this.PanelGraphVisualizer.TabIndex = 9;
            // 
            // radioButtonBFS
            // 
            this.radioButtonBFS.AutoSize = true;
            this.radioButtonBFS.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonBFS.Location = new System.Drawing.Point(177, 124);
            this.radioButtonBFS.Name = "radioButtonBFS";
            this.radioButtonBFS.Size = new System.Drawing.Size(58, 23);
            this.radioButtonBFS.TabIndex = 10;
            this.radioButtonBFS.TabStop = true;
            this.radioButtonBFS.Text = "BFS";
            this.radioButtonBFS.UseVisualStyleBackColor = true;
            this.radioButtonBFS.CheckedChanged += new System.EventHandler(this.radioButtonBFS_CheckedChanged);
            // 
            // radioButtonDFS
            // 
            this.radioButtonDFS.AutoSize = true;
            this.radioButtonDFS.Font = new System.Drawing.Font("Comic Sans MS", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButtonDFS.Location = new System.Drawing.Point(247, 124);
            this.radioButtonDFS.Name = "radioButtonDFS";
            this.radioButtonDFS.Size = new System.Drawing.Size(59, 23);
            this.radioButtonDFS.TabIndex = 11;
            this.radioButtonDFS.TabStop = true;
            this.radioButtonDFS.Text = "DFS";
            this.radioButtonDFS.UseVisualStyleBackColor = true;
            this.radioButtonDFS.CheckedChanged += new System.EventHandler(this.radioButtonDFS_CheckedChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(14, 466);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(157, 23);
            this.label7.TabIndex = 12;
            this.label7.Text = "Choose Account";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(14, 500);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(194, 23);
            this.label8.TabIndex = 13;
            this.label8.Text = "Explore friends with";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(193, 466);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 24);
            this.label9.TabIndex = 14;
            this.label9.Text = ":";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(193, 500);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(15, 24);
            this.label10.TabIndex = 15;
            this.label10.Text = ":";
            // 
            // comboBoxInitial
            // 
            this.comboBoxInitial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxInitial.FormattingEnabled = true;
            this.comboBoxInitial.Location = new System.Drawing.Point(214, 469);
            this.comboBoxInitial.MaximumSize = new System.Drawing.Size(500, 0);
            this.comboBoxInitial.Name = "comboBoxInitial";
            this.comboBoxInitial.Size = new System.Drawing.Size(176, 24);
            this.comboBoxInitial.TabIndex = 16;
            this.comboBoxInitial.SelectedIndexChanged += new System.EventHandler(this.comboBoxInitial_SelectedIndexChanged);
            // 
            // comboBoxTarget
            // 
            this.comboBoxTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxTarget.FormattingEnabled = true;
            this.comboBoxTarget.Location = new System.Drawing.Point(214, 503);
            this.comboBoxTarget.MaximumSize = new System.Drawing.Size(500, 0);
            this.comboBoxTarget.Name = "comboBoxTarget";
            this.comboBoxTarget.Size = new System.Drawing.Size(176, 24);
            this.comboBoxTarget.TabIndex = 17;
            this.comboBoxTarget.SelectedIndexChanged += new System.EventHandler(this.comboBoxTarget_SelectedIndexChanged);
            // 
            // buttonSubmit
            // 
            this.buttonSubmit.Font = new System.Drawing.Font("Comic Sans MS", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSubmit.Location = new System.Drawing.Point(18, 538);
            this.buttonSubmit.Name = "buttonSubmit";
            this.buttonSubmit.Size = new System.Drawing.Size(112, 30);
            this.buttonSubmit.TabIndex = 19;
            this.buttonSubmit.Text = "Submit";
            this.buttonSubmit.UseVisualStyleBackColor = true;
            this.buttonSubmit.Click += new System.EventHandler(this.buttonSubmit_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(445, 121);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(75, 23);
            this.resetButton.TabIndex = 21;
            this.resetButton.Text = "reset";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(532, 583);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.buttonSubmit);
            this.Controls.Add(this.comboBoxTarget);
            this.Controls.Add(this.comboBoxInitial);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.radioButtonDFS);
            this.Controls.Add(this.radioButtonBFS);
            this.Controls.Add(this.PanelGraphVisualizer);
            this.Controls.Add(this.labelFileName);
            this.Controls.Add(this.BrowseButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(550, 630);
            this.Name = "MainForm";
            this.Text = "Tubes Brow";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label judul;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.Label labelFileName;
        private System.Windows.Forms.Panel PanelGraphVisualizer;
        private System.Windows.Forms.RadioButton radioButtonBFS;
        private System.Windows.Forms.RadioButton radioButtonDFS;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox comboBoxInitial;
        private System.Windows.Forms.ComboBox comboBoxTarget;
        private System.Windows.Forms.Button buttonSubmit;
        private System.Windows.Forms.Button resetButton;
    }
}

