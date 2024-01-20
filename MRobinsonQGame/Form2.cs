using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRobinsonQGame
{
    public partial class PuzzleDesign : Form
    {
        int numOfRows;
        int numOfColumns;
        int cellSize = 66;
        string toolSelected;
        public PuzzleDesign()
        {
            InitializeComponent();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            // Check if the TextBoxes are empty or contain invalid values for numRows and numColumns
            if (string.IsNullOrEmpty(txtbxRows.Text) || string.IsNullOrEmpty(txtbxColumns.Text))
            {
                MessageBox.Show("Please enter valid numbers for rows and columns.");
                return;
            }

            if (!int.TryParse(txtbxRows.Text, out numOfRows) || !int.TryParse(txtbxColumns.Text, out numOfColumns))
            {
                MessageBox.Show("Please enter valid positive integer values for rows and columns.");
                return;
            }

            // Check if the number of rows and columns are positive and within the limit
            if (numOfRows <= 0 || numOfColumns <= 0)
            {
                MessageBox.Show("Only positive numbers are acceptable for rows and columns.");
                return;
            }

            // Limit the number of rows and columns to 12
            if (numOfRows > 12 || numOfColumns > 12)
            {
                MessageBox.Show("The maximum allowed rows and columns is 12.");
                return;
            }

            // Create the grid
            CreateGrid(numOfRows, numOfColumns);
        }

        private void CreateGrid(int numOfRows, int numOfColumns)
        {
            // Clear any existing grid
            panel.Controls.Clear();

            // Create the new grid
            for (int row = 0; row < numOfRows; row++)
            {
                for (int column = 0; column < numOfColumns; column++)
                {
                    // Create a new PictureBox for each cell in the grid
                    PictureBox pictureBox = new PictureBox();

                    // Set properties for the PictureBox
                    pictureBox.Size = new Size(cellSize, cellSize);
                    pictureBox.Location = new Point(column * cellSize, row * cellSize);
                    pictureBox.BorderStyle = BorderStyle.FixedSingle;

                    // Set the background color to blue
                    pictureBox.BackColor = Color.LightBlue;
                    // Add a click event handler
                    pictureBox.Click += PictureBox_Click;

                    // Add the PictureBox to the Panel
                    panel.Controls.Add(pictureBox);
                }
            }
        }
     
        private void btnNone_Click(object sender, EventArgs e)
        {
            toolSelected = "none";
        }
        private void btnWall_Click_1(object sender, EventArgs e)
        {
            toolSelected = "wall";
        }
        private void btnGreenDoor_Click(object sender, EventArgs e)
        {
            toolSelected = "greenmen";
        }

        private void btnRedDoor_Click(object sender, EventArgs e)
        {
            toolSelected = "redmen";
        }

        private void btnGreenExit_Click(object sender, EventArgs e)
        {
            toolSelected = "greenexit";
        }

        private void btnRedExit_Click(object sender, EventArgs e)
        {
            toolSelected = "redexit";
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            // The sender is the PictureBox that was clicked
            PictureBox pictureBox = (PictureBox)sender;

            // Now you can place the selected tool on pictureBox
            switch (toolSelected)
            {
                case "wall":
                    pictureBox.Image = Properties.Resources.brick_wall;
                    pictureBox.Tag = "wall";
                    break;
                case "none":
                    pictureBox.Image = null;  // This clears the PictureBox
                    pictureBox.Tag = "none";
                    break;
                case "greenmen":
                    pictureBox.Image = Properties.Resources.Green_Man;
                    pictureBox.Tag = "men-green";
                    break;
                case "redmen":
                    pictureBox.Image = Properties.Resources.Red_Man;
                    pictureBox.Tag = "men-red";
                    break;
                case "greenexit":
                    pictureBox.Image = Properties.Resources.Green_Exit;
                    pictureBox.Tag = "exit-green";
                    break;
                case "redexit":
                    pictureBox.Image = Properties.Resources.Red_Exit;
                    pictureBox.Tag = "exit-red";
                    break;
            }
        }

        private PictureBox GetPictureBoxAtLocation(int row, int column)
        {
            foreach (Control control in panel.Controls)
            {
                if (control is PictureBox pictureBox &&
                    pictureBox.Location.X / cellSize == column &&
                    pictureBox.Location.Y / cellSize == row)
                {
                    return pictureBox;
                }
            }

            return null;
        }


        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SaveFileDialog saveFileDialog = new SaveFileDialog();
        //    saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

        //    if (saveFileDialog.ShowDialog() == DialogResult.OK)
        //    {
        //        using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
        //        {
        //            writer.WriteLine($"{numOfRows} {numOfColumns}");

        //            for (int row = 0; row < numOfRows; row++)
        //            {
        //                for (int column = 0; column < numOfColumns; column++)
        //                {
        //                    PictureBox pictureBox = GetPictureBoxAtLocation(row, column);
        //                    string state = pictureBox?.Tag != null ? pictureBox.Tag.ToString() : "0";

        //                    // Convert the state to the desired format
        //                    string convertedState = ConvertState(state);

        //                    writer.Write(convertedState);

        //                    if (column < numOfColumns)
        //                    {
        //                        writer.Write("");
        //                    }
        //                }

        //                writer.WriteLine();
        //            }
        //        }

        //        MessageBox.Show($"Level saved successfully!\n\nRows: {numOfRows}\nColumns: {numOfColumns}");
        //    }
        //}

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Initialize counters
                int numWalls = 0, numGreenMen = 0, numRedMen = 0, numGreenExits = 0, numRedExits = 0;

                using (StreamWriter writer = new StreamWriter(saveFileDialog.FileName))
                {
                    writer.WriteLine($"{numOfRows} {numOfColumns}");

                    for (int row = 0; row < numOfRows; row++)
                    {
                        for (int column = 0; column < numOfColumns; column++)
                        {
                            PictureBox pictureBox = GetPictureBoxAtLocation(row, column);
                            string state = pictureBox?.Tag != null ? pictureBox.Tag.ToString() : "0";

                            // Convert the state to the desired format
                            string convertedState = ConvertState(state);

                            // Update counters based on the state
                            switch (state)
                            {
                                case "wall":
                                    numWalls++;
                                    break;
                                case "men-green":
                                    numGreenMen++;
                                    break;
                                case "men-red":
                                    numRedMen++;
                                    break;
                                case "exit-green":
                                    numGreenExits++;
                                    break;
                                case "exit-red":
                                    numRedExits++;
                                    break;
                            }

                            writer.Write(convertedState);

                            if (column < numOfColumns)
                            {
                                writer.Write("");
                            }
                        }

                        writer.WriteLine();
                    }

                    MessageBox.Show($"Level saved successfully!\n\nRows: {numOfRows}\nColumns: {numOfColumns}\nWalls: {numWalls}\nGreen Men: {numGreenMen}\nRed Men: {numRedMen}\nGreen Exits: {numGreenExits}\nRed Exits: {numRedExits}");
                }
            }
        }


        // Helper method to convert the state to the desired format
        private string ConvertState(string state)
        {
            switch (state)
            {
                case "none":
                    return "0";
                case "wall":
                    return "1";
                case "men-green":
                    return "2";
                case "men-red":
                    return "3";
                case "exit-green":
                    return "4";
                case "exit-red":
                    return "5";
                default:
                    return "0";
            }
        }

    }
}
 
  