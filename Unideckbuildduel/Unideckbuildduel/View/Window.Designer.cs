namespace Unideckbuildduel.View
{
    partial class Window
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.quitButton = new System.Windows.Forms.Button();
            this.outputListBox = new System.Windows.Forms.ListBox();
            this.placeAllButton = new System.Windows.Forms.Button();
            this.nextTurnButton = new System.Windows.Forms.Button();
            this.turnLabel = new System.Windows.Forms.Label();
            this.playerTwoScoreLabel = new System.Windows.Forms.Label();
            this.playerOneScoreLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(1064, 552);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(75, 23);
            this.quitButton.TabIndex = 0;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.QuitButton_Click);
            // 
            // outputListBox
            // 
            this.outputListBox.FormattingEnabled = true;
            this.outputListBox.Location = new System.Drawing.Point(914, 28);
            this.outputListBox.Name = "outputListBox";
            this.outputListBox.Size = new System.Drawing.Size(261, 433);
            this.outputListBox.TabIndex = 1;
            // 
            // placeAllButton
            // 
            this.placeAllButton.Location = new System.Drawing.Point(1064, 523);
            this.placeAllButton.Name = "placeAllButton";
            this.placeAllButton.Size = new System.Drawing.Size(75, 23);
            this.placeAllButton.TabIndex = 2;
            this.placeAllButton.Text = "Play All";
            this.placeAllButton.UseVisualStyleBackColor = true;
            this.placeAllButton.Click += new System.EventHandler(this.PlaceAllButton_Click);
            // 
            // nextTurnButton
            // 
            this.nextTurnButton.Location = new System.Drawing.Point(1064, 494);
            this.nextTurnButton.Name = "nextTurnButton";
            this.nextTurnButton.Size = new System.Drawing.Size(75, 23);
            this.nextTurnButton.TabIndex = 3;
            this.nextTurnButton.Text = "Next Turn";
            this.nextTurnButton.UseVisualStyleBackColor = true;
            this.nextTurnButton.Click += new System.EventHandler(this.NextTurnButton_Click);
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Location = new System.Drawing.Point(967, 561);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(35, 13);
            this.turnLabel.TabIndex = 4;
            this.turnLabel.Text = "label1";
            // 
            // playerTwoScoreLabel
            // 
            this.playerTwoScoreLabel.AutoSize = true;
            this.playerTwoScoreLabel.Location = new System.Drawing.Point(967, 528);
            this.playerTwoScoreLabel.Name = "playerTwoScoreLabel";
            this.playerTwoScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.playerTwoScoreLabel.TabIndex = 5;
            this.playerTwoScoreLabel.Text = "label1";
            // 
            // playerOneScoreLabel
            // 
            this.playerOneScoreLabel.AutoSize = true;
            this.playerOneScoreLabel.Location = new System.Drawing.Point(967, 504);
            this.playerOneScoreLabel.Name = "playerOneScoreLabel";
            this.playerOneScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.playerOneScoreLabel.TabIndex = 6;
            this.playerOneScoreLabel.Text = "label1";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.playerOneScoreLabel);
            this.Controls.Add(this.playerTwoScoreLabel);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.nextTurnButton);
            this.Controls.Add(this.placeAllButton);
            this.Controls.Add(this.outputListBox);
            this.Controls.Add(this.quitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Window";
            this.Text = "Insert title here";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Window_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.ListBox outputListBox;
        private System.Windows.Forms.Button placeAllButton;
        private System.Windows.Forms.Button nextTurnButton;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label playerTwoScoreLabel;
        private System.Windows.Forms.Label playerOneScoreLabel;
    }
}

