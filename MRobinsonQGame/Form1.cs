using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRobinsonQGame
{
    public partial class Form1 : Form
    {
        PuzzleDesign puzzleDesign;
        PlayForm playForm;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDesign_Click(object sender, EventArgs e)
        {
            // Create a new instance of DesignForm if it doesn't exist or it was closed
            if (puzzleDesign == null || puzzleDesign.IsDisposed)
            {
                puzzleDesign = new PuzzleDesign();
            }

            puzzleDesign.Show();
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            if (playForm == null || playForm.IsDisposed) 
            { 
                playForm = new PlayForm();
            }

            playForm.Show();
        }
    }
}
