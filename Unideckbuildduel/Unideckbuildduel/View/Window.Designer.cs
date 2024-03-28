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
            this.nextTurnButton = new System.Windows.Forms.Button();
            this.turnLabel = new System.Windows.Forms.Label();
            this.playerTwoScoreLabel = new System.Windows.Forms.Label();
            this.playerOneScoreLabel = new System.Windows.Forms.Label();
            this.replayButton = new System.Windows.Forms.Button();
            this.DeckSize = new System.Windows.Forms.Label();
            this.DiscardSize = new System.Windows.Forms.Label();
            this.nextPhaseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(1167, 547);
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
            this.outputListBox.Location = new System.Drawing.Point(1017, 30);
            this.outputListBox.Name = "outputListBox";
            this.outputListBox.Size = new System.Drawing.Size(261, 433);
            this.outputListBox.TabIndex = 1;
            // 
            // nextTurnButton
            // 
            this.nextTurnButton.Location = new System.Drawing.Point(1167, 517);
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
            this.turnLabel.Location = new System.Drawing.Point(1070, 563);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(35, 13);
            this.turnLabel.TabIndex = 4;
            this.turnLabel.Text = "label1";
            // 
            // playerTwoScoreLabel
            // 
            this.playerTwoScoreLabel.AutoSize = true;
            this.playerTwoScoreLabel.Location = new System.Drawing.Point(1070, 527);
            this.playerTwoScoreLabel.Name = "playerTwoScoreLabel";
            this.playerTwoScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.playerTwoScoreLabel.TabIndex = 5;
            this.playerTwoScoreLabel.Text = "label1";
            // 
            // playerOneScoreLabel
            // 
            this.playerOneScoreLabel.AutoSize = true;
            this.playerOneScoreLabel.Location = new System.Drawing.Point(1070, 488);
            this.playerOneScoreLabel.Name = "playerOneScoreLabel";
            this.playerOneScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.playerOneScoreLabel.TabIndex = 6;
            this.playerOneScoreLabel.Text = "label1";
            // 
            // replayButton
            // 
            this.replayButton.Location = new System.Drawing.Point(1167, 576);
            this.replayButton.Name = "replayButton";
            this.replayButton.Size = new System.Drawing.Size(75, 23);
            this.replayButton.TabIndex = 7;
            this.replayButton.Text = "Restart";
            this.replayButton.UseVisualStyleBackColor = true;
            this.replayButton.Click += new System.EventHandler(this.replayButton_Click);
            // 
            // DeckSize
            // 
            this.DeckSize.AutoSize = true;
            this.DeckSize.Location = new System.Drawing.Point(904, 488);
            this.DeckSize.Name = "DeckSize";
            this.DeckSize.Size = new System.Drawing.Size(35, 13);
            this.DeckSize.TabIndex = 8;
            this.DeckSize.Text = "label1";
            // 
            // DiscardSize
            // 
            this.DiscardSize.AutoSize = true;
            this.DiscardSize.Location = new System.Drawing.Point(904, 527);
            this.DiscardSize.Name = "DiscardSize";
            this.DiscardSize.Size = new System.Drawing.Size(35, 13);
            this.DiscardSize.TabIndex = 9;
            this.DiscardSize.Text = "label2";
            // 
            // nextPhaseButton
            // 
            this.nextPhaseButton.Enabled = false;
            this.nextPhaseButton.Location = new System.Drawing.Point(1167, 488);
            this.nextPhaseButton.Name = "nextPhaseButton";
            this.nextPhaseButton.Size = new System.Drawing.Size(75, 23);
            this.nextPhaseButton.TabIndex = 10;
            this.nextPhaseButton.Text = "Next Phase";
            this.nextPhaseButton.UseVisualStyleBackColor = true;
            this.nextPhaseButton.Click += new System.EventHandler(this.nextPhaseButton_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 611);
            this.Controls.Add(this.nextPhaseButton);
            this.Controls.Add(this.DiscardSize);
            this.Controls.Add(this.DeckSize);
            this.Controls.Add(this.replayButton);
            this.Controls.Add(this.playerOneScoreLabel);
            this.Controls.Add(this.playerTwoScoreLabel);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.nextTurnButton);
            this.Controls.Add(this.outputListBox);
            this.Controls.Add(this.quitButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Window";
            this.Text = "Insert title here";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Window_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Window_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.ListBox outputListBox;
        private System.Windows.Forms.Button nextTurnButton;
        private System.Windows.Forms.Label turnLabel;
        private System.Windows.Forms.Label playerTwoScoreLabel;
        private System.Windows.Forms.Label playerOneScoreLabel;
        private System.Windows.Forms.Button replayButton;
        private System.Windows.Forms.Label DeckSize;
        private System.Windows.Forms.Label DiscardSize;
        private System.Windows.Forms.Button nextPhaseButton;
    }
}

