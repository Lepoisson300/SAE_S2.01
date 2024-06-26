﻿namespace Unideckbuildduel.View
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
            this.drawOncePerTurn = new System.Windows.Forms.Button();
            this.ActiveEffectListBox = new System.Windows.Forms.ListBox();
            this.DrawFromDiscardButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(1385, 528);
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
            this.outputListBox.Location = new System.Drawing.Point(1125, 31);
            this.outputListBox.Name = "outputListBox";
            this.outputListBox.Size = new System.Drawing.Size(371, 433);
            this.outputListBox.TabIndex = 1;
            // 
            // nextTurnButton
            // 
            this.nextTurnButton.Location = new System.Drawing.Point(1385, 489);
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
            this.turnLabel.Location = new System.Drawing.Point(1288, 564);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(35, 13);
            this.turnLabel.TabIndex = 4;
            this.turnLabel.Text = "label1";
            // 
            // playerTwoScoreLabel
            // 
            this.playerTwoScoreLabel.AutoSize = true;
            this.playerTwoScoreLabel.Location = new System.Drawing.Point(1288, 528);
            this.playerTwoScoreLabel.Name = "playerTwoScoreLabel";
            this.playerTwoScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.playerTwoScoreLabel.TabIndex = 5;
            this.playerTwoScoreLabel.Text = "label1";
            // 
            // playerOneScoreLabel
            // 
            this.playerOneScoreLabel.AutoSize = true;
            this.playerOneScoreLabel.Location = new System.Drawing.Point(1288, 489);
            this.playerOneScoreLabel.Name = "playerOneScoreLabel";
            this.playerOneScoreLabel.Size = new System.Drawing.Size(35, 13);
            this.playerOneScoreLabel.TabIndex = 6;
            this.playerOneScoreLabel.Text = "label1";
            // 
            // replayButton
            // 
            this.replayButton.Enabled = false;
            this.replayButton.Location = new System.Drawing.Point(1385, 564);
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
            this.DeckSize.Location = new System.Drawing.Point(1122, 489);
            this.DeckSize.Name = "DeckSize";
            this.DeckSize.Padding = new System.Windows.Forms.Padding(5);
            this.DeckSize.Size = new System.Drawing.Size(45, 23);
            this.DeckSize.TabIndex = 8;
            this.DeckSize.Text = "label1";
            this.DeckSize.Click += new System.EventHandler(this.DeckSize_Click);
            // 
            // DiscardSize
            // 
            this.DiscardSize.AutoSize = true;
            this.DiscardSize.Location = new System.Drawing.Point(1122, 528);
            this.DiscardSize.Name = "DiscardSize";
            this.DiscardSize.Padding = new System.Windows.Forms.Padding(5);
            this.DiscardSize.Size = new System.Drawing.Size(45, 23);
            this.DiscardSize.TabIndex = 9;
            this.DiscardSize.Text = "label2";
            this.DiscardSize.Click += new System.EventHandler(this.DiscardSize_Click);
            // 
            // drawOncePerTurn
            // 
            this.drawOncePerTurn.Location = new System.Drawing.Point(1100, 564);
            this.drawOncePerTurn.Name = "drawOncePerTurn";
            this.drawOncePerTurn.Size = new System.Drawing.Size(135, 23);
            this.drawOncePerTurn.TabIndex = 11;
            this.drawOncePerTurn.Text = "Draw From Deck";
            this.drawOncePerTurn.UseVisualStyleBackColor = true;
            this.drawOncePerTurn.Visible = false;
            this.drawOncePerTurn.Click += new System.EventHandler(this.drawOncePerTurn_Click);
            // 
            // ActiveEffectListBox
            // 
            this.ActiveEffectListBox.FormattingEnabled = true;
            this.ActiveEffectListBox.Location = new System.Drawing.Point(967, 218);
            this.ActiveEffectListBox.Name = "ActiveEffectListBox";
            this.ActiveEffectListBox.Size = new System.Drawing.Size(152, 199);
            this.ActiveEffectListBox.TabIndex = 12;
            // 
            // DrawFromDiscardButton
            // 
            this.DrawFromDiscardButton.Enabled = false;
            this.DrawFromDiscardButton.Location = new System.Drawing.Point(1100, 593);
            this.DrawFromDiscardButton.Name = "DrawFromDiscardButton";
            this.DrawFromDiscardButton.Size = new System.Drawing.Size(135, 23);
            this.DrawFromDiscardButton.TabIndex = 13;
            this.DrawFromDiscardButton.Text = " Draw From Discard Once Per Turn";
            this.DrawFromDiscardButton.UseVisualStyleBackColor = true;
            this.DrawFromDiscardButton.Visible = false;
            this.DrawFromDiscardButton.Click += new System.EventHandler(this.DrawFromDiscardButton_Click);
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1502, 623);
            this.Controls.Add(this.DrawFromDiscardButton);
            this.Controls.Add(this.ActiveEffectListBox);
            this.Controls.Add(this.drawOncePerTurn);
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
        private System.Windows.Forms.Button drawOncePerTurn;
        private System.Windows.Forms.ListBox ActiveEffectListBox;
        private System.Windows.Forms.Button DrawFromDiscardButton;
    }
}

