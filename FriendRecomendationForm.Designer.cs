
namespace Tubes2Stima_ckck
{
    partial class FriendRecomendationForm
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
            this.labelFriendRecomendation = new System.Windows.Forms.Label();
            this.titleExplore = new System.Windows.Forms.Label();
            this.pathExplore = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelFriendRecomendation
            // 
            this.labelFriendRecomendation.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFriendRecomendation.Location = new System.Drawing.Point(11, 106);
            this.labelFriendRecomendation.Name = "labelFriendRecomendation";
            this.labelFriendRecomendation.Size = new System.Drawing.Size(501, 23);
            this.labelFriendRecomendation.TabIndex = 19;
            this.labelFriendRecomendation.Text = "Friends Recomendation for ?\r\n";
            // 
            // titleExplore
            // 
            this.titleExplore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.titleExplore.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleExplore.Location = new System.Drawing.Point(12, 9);
            this.titleExplore.Name = "titleExplore";
            this.titleExplore.Size = new System.Drawing.Size(501, 23);
            this.titleExplore.TabIndex = 20;
            this.titleExplore.Text = "Explore Friends";
            // 
            // pathExplore
            // 
            this.pathExplore.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pathExplore.Location = new System.Drawing.Point(12, 42);
            this.pathExplore.Name = "pathExplore";
            this.pathExplore.Size = new System.Drawing.Size(501, 47);
            this.pathExplore.TabIndex = 21;
            this.pathExplore.Text = "SiapaKeSiapa";
            // 
            // FriendRecomendationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(533, 642);
            this.Controls.Add(this.pathExplore);
            this.Controls.Add(this.titleExplore);
            this.Controls.Add(this.labelFriendRecomendation);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(549, 628);
            this.Name = "FriendRecomendationForm";
            this.Text = "IniTeman";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelFriendRecomendation;
        private System.Windows.Forms.Label titleExplore;
        private System.Windows.Forms.Label pathExplore;
    }
}