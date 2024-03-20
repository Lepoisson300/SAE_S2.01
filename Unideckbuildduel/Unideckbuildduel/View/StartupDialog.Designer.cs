namespace Unideckbuildduel.View
{
    partial class StartupDialog
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.turnLimitNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.turnsTextLabel = new System.Windows.Forms.Label();
            this.nameOneTextLabel = new System.Windows.Forms.Label();
            this.nameTwoTextLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.turnLimitNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(579, 105);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 0;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(579, 148);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // turnLimitNumericUpDown
            // 
            this.turnLimitNumericUpDown.Location = new System.Drawing.Point(210, 51);
            this.turnLimitNumericUpDown.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.turnLimitNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.turnLimitNumericUpDown.Name = "turnLimitNumericUpDown";
            this.turnLimitNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.turnLimitNumericUpDown.TabIndex = 2;
            this.turnLimitNumericUpDown.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // turnsTextLabel
            // 
            this.turnsTextLabel.AutoSize = true;
            this.turnsTextLabel.Location = new System.Drawing.Point(77, 57);
            this.turnsTextLabel.Name = "turnsTextLabel";
            this.turnsTextLabel.Size = new System.Drawing.Size(52, 13);
            this.turnsTextLabel.TabIndex = 3;
            this.turnsTextLabel.Text = "Turn limit:";
            // 
            // nameOneTextLabel
            // 
            this.nameOneTextLabel.AutoSize = true;
            this.nameOneTextLabel.Location = new System.Drawing.Point(77, 105);
            this.nameOneTextLabel.Name = "nameOneTextLabel";
            this.nameOneTextLabel.Size = new System.Drawing.Size(89, 13);
            this.nameOneTextLabel.TabIndex = 4;
            this.nameOneTextLabel.Text = "Player one name:";
            // 
            // nameTwoTextLabel
            // 
            this.nameTwoTextLabel.AutoSize = true;
            this.nameTwoTextLabel.Location = new System.Drawing.Point(80, 148);
            this.nameTwoTextLabel.Name = "nameTwoTextLabel";
            this.nameTwoTextLabel.Size = new System.Drawing.Size(88, 13);
            this.nameTwoTextLabel.TabIndex = 5;
            this.nameTwoTextLabel.Text = "Player two name:";
            // 
            // StartupDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 229);
            this.Controls.Add(this.nameTwoTextLabel);
            this.Controls.Add(this.nameOneTextLabel);
            this.Controls.Add(this.turnsTextLabel);
            this.Controls.Add(this.turnLimitNumericUpDown);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Name = "StartupDialog";
            this.Text = "StartupDialog";
            ((System.ComponentModel.ISupportInitialize)(this.turnLimitNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.NumericUpDown turnLimitNumericUpDown;
        private System.Windows.Forms.Label turnsTextLabel;
        private System.Windows.Forms.Label nameOneTextLabel;
        private System.Windows.Forms.Label nameTwoTextLabel;
    }
}