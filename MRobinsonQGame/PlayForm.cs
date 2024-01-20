using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MRobinsonQGame
{
    public partial class PlayForm : Form
    {
        // Declare your variables here
        int numOfRows;
        int numOfColumns;
        int numOfMen = 0; // Variable to count the number of Men
        int cellSize = 68;
        string toolSelected;
        int numOfMoves;
        Tile[,] tiles;
        Tile selectedTile;
        private Tile[,] grid; // Added declaration
        Tile clickedTile;

        public PlayForm()
        {
            InitializeComponent();
        }
        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClearGameBoard();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Text Files (*.txt)|*.txt";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Reset the number of men
                numOfMen = 0;

                using(StreamReader reader = new StreamReader(openFileDialog.FileName))
                {
                    // Read the number of rows and columns
                    string[] dimensions = reader.ReadLine().Split(' ');
                    numOfRows = int.Parse(dimensions[0]);
                    numOfColumns = int.Parse(dimensions[1]);

                    // Initialize your grid here
                    InitializeGrid();

                    // Read the type of tool in each cell of the grid
                    for(int row = 0; row < numOfRows; row++)
                    {
                        string states = reader.ReadLine();

                        for(int column = 0; column < numOfColumns; column++)
                        {
                            // Check if the states array has enough elements
                            if(column < states.Length)
                            {
                                // Find the Tile corresponding to the current row and column
                                Tile tile = GetTileAtLocation(row, column);

                                // Set the state of the Tile
                                tile.tileType = states[column].ToString();

                                // Update the image of the Tile based on the state
                                switch(states[column])
                                {
                                    case '1':
                                        tile.Image = Properties.Resources.brick_wall;
                                        tile.tileType = "wall";
                                        break;
                                    case '2':
                                    case '3':
                                        if(tile.tileType.StartsWith("2") || tile.tileType.StartsWith("3"))
                                        {
                                            // Increment the number of doors
                                            numOfMen++;
                                        }
                                        if(tile.tileType == "2")
                                        {
                                            tile.Image = Properties.Resources.Green_Man;
                                            tile.tileType = "men-green";
                                        }
                                        else if(tile.tileType == "3")
                                        {
                                            tile.Image = Properties.Resources.Red_Man;
                                            tile.tileType = "men-red";
                                        }
                                        break;
                                    case '4':
                                        tile.Image = Properties.Resources.Green_Exit;
                                        tile.tileType = "exit-green";
                                        break;
                                    case '5':
                                        tile.Image = Properties.Resources.Red_Exit;
                                        tile.tileType = "exit-red";
                                        break;
                                    default:
                                        tile.Image = null;  // This clears the Tile
                                        tile.tileType = "";
                                        break;
                                }
                            }
                        }
                    }
                }
                MessageBox.Show($"Level loaded successfully!\n\nRows: {numOfRows}\nColumns: {numOfColumns}\nNumber of Men: {numOfMen}");
                txtboxRemaingMen.Text = numOfMen.ToString();
            }
        }
        private void InitializeGrid()
        {
            // Create a new grid based on the loaded file
            grid = new Tile[numOfRows, numOfColumns];

            // Loop through the grid and initialize each Tile
            for(int i = 0; i < numOfRows; i++)
            {
                for(int j = 0; j < numOfColumns; j++)
                {
                    Tile tile = new Tile
                    {
                        BorderStyle = BorderStyle.FixedSingle,
                        SizeMode = PictureBoxSizeMode.StretchImage,
                        Size = new Size(cellSize, cellSize), // Set a fixed size
                        row = i,
                        col = j,
                    };

                    // Calculate the location based on the size of the Tile and the cell size
                    int x = j * cellSize;
                    int y = i * cellSize;

                    tile.Location = new Point(x, y);

                    this.gamePanel.Controls.Add((PictureBox)tile); // Add the tile to the gamePanel

                    grid[i, j] = tile;

                    // Wire up the event handler for the Tile_Click event
                    tile.Click += Tile_Click;
                }
            }
        }

        private Tile GetTileAtLocation(int row, int column)
        {
            // grid is a 2D array of Tile that represents your grid
            if(row >= 0 && row < grid.GetLength(0) && column >= 0 && column < grid.GetLength(1))
            {
                Tile tile = grid[row, column];
                if(tile != null)
                {
                    return tile;
                }
            }
            return null;
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Tile_Click(object sender, EventArgs e)
        {
            // The sender is the Tile that was clicked
            Tile tile = (Tile)sender;

            // Check if the clicked tile is a man
            if(tile.tileType.StartsWith("men-"))
            {
                // Set the clicked tile as the selected tile
                selectedTile = tile;
                tile.BorderStyle = BorderStyle.Fixed3D;
            }
            else
            {
                // Display a message if the clicked tile is not a man
                MessageBox.Show("Please select a man before trying to move.");
                return; // Exit the method, as there's no valid man selected
            }

            // place the selected tool on the tile
            switch(toolSelected)
            {
                case "wall":
                    tile.Image = Properties.Resources.brick_wall;
                    tile.tileType = "wall";
                    break;
                case "none":
                    tile.Image = null;  // This clears the Tile
                    tile.tileType = "none";
                    break;
                case "greenmen":
                    tile.Image = Properties.Resources.Green_Man;
                    tile.tileType = "men-green";
                    break;
                case "redmen":
                    tile.Image = Properties.Resources.Red_Man;
                    tile.tileType = "men-red";
                    break;
                case "greenexit":
                    tile.Image = Properties.Resources.Green_Exit;
                    tile.tileType = "exit-green";
                    break;
                case "redexit":
                    tile.Image = Properties.Resources.Red_Exit;
                    tile.tileType = "exit-red";
                    break;
            }
        } 

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveTile(selectedTile, 0, -1);
        }
        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveTile(selectedTile, 0, 1);
        }
        private void btnLeft_Click(object sender, EventArgs e)
        {
                MoveTile(selectedTile, -1, 0);
            
        }
        private void btnRight_Click(object sender, EventArgs e)
        {
            MoveTile(selectedTile, 1, 0);
        }

        private void MoveTile(Tile tile, int dX, int dY)
        {
            if (tile == null)
            {
                MessageBox.Show("Please select a man to move.");
                return;
            }
            // Ensure that a tile is selected
            if(tile != null && tile.tileType.StartsWith("men-"))
            {
                int newRow = tile.row + dY;
                int newCol = tile.col + dX;
                // Check if the new position is within the bounds of the grid
                if(newRow >= 0 && newRow < numOfRows && newCol >= 0 && newCol < numOfColumns)

                {
                    // Get the tile at the new position
                    Tile newTile = GetTileAtLocation(newRow, newCol);

                    // Check if the new position is empty (no wall or other obstacles)
                    if(newTile != null && newTile.tileType != "wall" && !newTile.tileType.StartsWith("men-"))
                    {
                        // Check if the player has reached an exit
                        if(newTile.tileType.StartsWith("exit-"))
                        {
                            // Check if the man selected matches the exit
                            string exitColor = newTile.tileType.Substring(5); // Extract color from "exit-color"
                            string manColor = tile.tileType.Substring(4); // Extract color from "men-color"

                            if(exitColor == manColor)
                            {
                                // Man matches the exit, decrease numOfMen
                                numOfMen--;
                                // Remove the man and the exit
                                RemoveTile(tile);

                                var emptyTile = new Tile
                                {
                                    Image = null,
                                    tileType = "none",
                                    Size = new Size(cellSize, cellSize),
                                    BorderStyle = BorderStyle.FixedSingle,
                                    SizeMode = PictureBoxSizeMode.StretchImage,
                                    row = tile.row,
                                    col = tile.col,
                                };
                                grid[tile.row, tile.col] = emptyTile;
                                gamePanel.Controls.Add(emptyTile);
                                emptyTile.Location = tile.Location;

                                txtboxRemaingMen.Text = numOfMen.ToString();
                                // Update the number of moves
                                numOfMoves++;

                                // Update the UI to display the number of moves
                                txtboxNumofMoves.Text = numOfMoves.ToString();

                                // Check if all men have reached their matching exits
                                if (numOfMen == 0)
                                    // Remove the man and the exit
                                    RemoveTile(tile);


                                // Check if all men have reached their matching exits
                                if(numOfMen == 0)
                                {
                                    // Declare a winner and display success message
                                    MessageBox.Show("Congratulations! \nYou win!");
                                    // Clear the game board or perform other actions as needed
                                    ClearGameBoard();
                                }

                                selectedTile = null;
                                // Exit the method, since the man has already moved to the exit
                                return;
                            }
                            else
                            {
                                return;
                            }
                        }

                        Tile replaceTile = grid[newRow, newCol];

                        // Move the tile to the new position in the grid
                        grid[tile.row, tile.col] = replaceTile; // Clear the old position
                        grid[newRow, newCol] = tile;     // Set the tile in the new position

                        replaceTile.row = tile.row;
                        replaceTile.col = tile.col;

                        // Update the tile's row and column
                        tile.row = newRow;
                        tile.col = newCol;

                        //Controls.Add(replaceTile);
                        replaceTile.Location = tile.Location;

                        // Calculate the new location based on the size of the Tile and the cell size
                        int x = newCol * cellSize;
                        int y = newRow * cellSize;

                        tile.Location = new Point(x, y);

                        //RemoveTile(newTile);

                        // Update the number of moves
                        numOfMoves++;

                        // Update the UI to display the number of moves
                        txtboxNumofMoves.Text = numOfMoves.ToString();

                        // Update the selected tile reference
                        selectedTile = tile; // Update selectedTile to the moved tile

                    }
                }
            }
        }
        // Add a method to clear the game board
        private void ClearGameBoard()
        {
            gamePanel.Controls.Clear();
            txtboxNumofMoves.Text = "";
        }

        // Add a method to remove a tile from the game panel
        private void RemoveTile(Tile tile)
        {
            if(tile != null)
            {
                gamePanel.Controls.Remove(tile);
                grid[tile.row, tile.col] = null;
                tile.Dispose();  // Dispose the tile
            }
        }
    }
}

