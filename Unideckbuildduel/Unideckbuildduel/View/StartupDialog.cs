using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Unideckbuildduel.View
{
    /// <summary>
    /// A simple startup dialog to be called at the start of a new game.
    /// </summary>
    public partial class StartupDialog : Form
    {
        public string Player1Name;

        public string Player2Name; 

        /// <summary>
        /// The limit of turns selected by the user
        /// </summary>
        public int TurnLimit { get { return (int)turnLimitNumericUpDown.Value; } }
        /// <summary>
        /// Empty-parametered constructor
        /// </summary>
        public StartupDialog()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Player1Name = txtBoxp1.Text;
            Player2Name = txtBoxp2.Text;
        }
    }
}
