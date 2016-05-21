using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Game_of_Life
{
    public partial class Form1 : Form
    {
        bool[,] universe = new bool[30, 30];
        bool[,] spad = new bool[30, 30];
        int sizeX;
        int sizeY;
        int liveCount = 0;
        int gens = 0;
        bool IsGridVisible = true;
        Timer timer = new Timer();
        SolidBrush color = new SolidBrush(Properties.Settings.Default.CellColor);
        Random rand;
        SeedForm seed = new SeedForm();


        public Form1()
        {
            InitializeComponent();
            GenerationStatus.Text = "Generations: " + gens.ToString();
            CellStatus.Text = "Live Cells: " + liveCount.ToString();
            timer.Interval = 70;
            timer.Tick += Timer_Tick;
            timer.Stop();
        }

        void GetLiveCellCount()
        {
            liveCount = 0;
            for (int x = 0; x < universe.GetLength(0); x++) //X-Axis
            {
                for (int y = 0; y < universe.GetLength(1); y++) //Y-Axis
                {
                    if (universe[x, y] == true)
                        liveCount++;
                }
            }
            CellStatus.Text = "Live Cells: " + liveCount.ToString();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Calculate the new Generation
            gens++;
            Update1();
            //Update status
            GenerationStatus.Text = "Generations: " + gens.ToString();
            GetLiveCellCount();
            graphicsPanel1.Invalidate();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //GraphicsPanel
        #region
        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            float w = (float)graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            float h = (float)graphicsPanel1.ClientSize.Height / universe.GetLength(1);
            for (int x = 0; x < universe.GetLength(0); x++) //X-Axis
            {
                for (int y = 0; y < universe.GetLength(1); y++) //Y-Axis
                {
                    RectangleF rect = RectangleF.Empty;
                    rect.X = x * w;
                    rect.Y = y * h;
                    rect.Width = w;
                    rect.Height = h;

                    if (universe[(int)x, (int)y] == true)
                    {
                        e.Graphics.FillRectangle(color, rect.X, rect.Y, rect.Width, rect.Height);
                    }
                    if (IsGridVisible == true)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
                    }
                }
            }
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            float w = (float)graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            float h = (float)graphicsPanel1.ClientSize.Height / universe.GetLength(1);
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    float x = e.X / w;
                    float y = e.Y / h;

                    //If already selected, Unselect!
                    universe[(int)x, (int)y] = !universe[(int)x, (int)y];

                    //Live Cell count. Check for subtraction
                    if (universe[(int)x, (int)y] == false && liveCount > 0)
                        liveCount--;
                    else if(universe[(int)x, (int)y] == true)
                        liveCount++;
                }
                CellStatus.Text = "Live Cells: " + liveCount.ToString();
                graphicsPanel1.Invalidate();
            }
            catch (IndexOutOfRangeException) { }
        }
        #endregion

        //Game Logic
        #region
        private static int AdjChecks(bool[,] universe, int ScreenSize, int x, int y, int horizontal, int veritcal)
        {
            //Checking the bounds and making sure it doesn't crash
            int amt = 0;

            int boundsX = x + horizontal;
            int boundsY = y + veritcal;
            bool outOfBounds = boundsX < 0 || boundsX >= ScreenSize || boundsY < 0
                || boundsY >= ScreenSize;
            if (!outOfBounds)
            {
                amt = universe[x + horizontal, y + veritcal] ? 1 : 0;
            }
            return amt;
        }

        private void Update1()
        {
            int sizeX = universe.GetLength(0);
            int sizeY = universe.GetLength(1);
            //int size = 20;
            bool isAlive;

            for (int x = 0; x < sizeX; x++) //X-Axis
            {
                for (int y = 0; y < sizeY; y++) //Y-Axis
                {
                    //Using the class to check the bounds in the grid
                    int count = AdjChecks(universe, sizeX, x, y, -1, 0) + AdjChecks(universe, sizeX, x, y, -1, 1)
                        + AdjChecks(universe, sizeX, x, y, 0, 1) + AdjChecks(universe, sizeX, x, y, 1, 1) + AdjChecks(universe, sizeX, x, y, 1, 0)
                        + AdjChecks(universe, sizeX, x, y, 1, -1) + AdjChecks(universe, sizeX, x, y, 0, -1) + AdjChecks(universe, sizeX, x, y, -1, -1);

                    isAlive = universe[x, y];
                    bool TurnOn = false;

                    //Living in the next generation
                    if (isAlive && (count == 2 || count == 3))
                        TurnOn = true;
                    //Dead will Live
                    else if (!isAlive && count == 3)
                        TurnOn = true;

                    spad[x, y] = TurnOn;
                }
            }

            for (int i = 0; i < sizeX; i++)
            {
                for (int t = 0; t < sizeY; t++)
                {
                    universe[i, t] = spad[i, t];
                }
            }
            for (int i = 0; i < sizeX; i++)
            {
                for (int t = 0; t < sizeY; t++)
                {
                    spad[i, t] = universe[i, t];
                }
            }
        }
        #endregion

        //Play/Pause/Next
        #region
        private void PlayButton_Click(object sender, EventArgs e)
        {
            timer.Start();
            //Perhaps change this in the future
            PlayButton.Enabled = false;
            NextButton.Enabled = false;
            Run_Start.Enabled = false;
            Run_Next.Enabled = false;
            startToolStripMenuItem.Enabled = false;
            nextToolStripMenuItem.Enabled = false;
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
            //Perhaps change this in the future
            PlayButton.Enabled = true;
            NextButton.Enabled = true;
            Run_Start.Enabled = true;
            Run_Next.Enabled = true;
            startToolStripMenuItem.Enabled = true;
            nextToolStripMenuItem.Enabled = true;
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            //Tick, but only once
            //gens++;
            //GenerationStatus.Text = "Generations: " + gens.ToString();
            //Update1();
            //graphicsPanel1.Invalidate();
            Timer_Tick(sender, e);
        }
        #endregion

        //ToolStripts & ect.
        #region
        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Reset
            for (int x = 0; x < universe.GetLength(0); x++) //X-Axis
            {
                for (int y = 0; y < universe.GetLength(1); y++) //Y-Axis
                {
                    universe[x, y] = false;
                }
            }
            timer.Stop();
            gens = 0;
            liveCount = 0;
            PlayButton.Enabled = true;
            NextButton.Enabled = true;
            Run_Start.Enabled = true;
            Run_Next.Enabled = true;
            startToolStripMenuItem.Enabled = true;
            nextToolStripMenuItem.Enabled = true;
            GenerationStatus.Text = "Generations: " + gens.ToString();
            CellStatus.Text = "Live Cells: " + liveCount.ToString();
            graphicsPanel1.Invalidate();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            //Access New
            newToolStripMenuItem1_Click(sender, e);
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem1_Click(sender, e);
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void Run_Start_Click(object sender, EventArgs e)
        {
            PlayButton_Click(sender, e);
        }

        private void Run_Pause_Click(object sender, EventArgs e)
        {
            PauseButton_Click(sender, e);
        }

        private void Run_Next_Click(object sender, EventArgs e)
        {
            NextButton_Click(sender, e);
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PlayButton_Click(sender, e);
        }

        private void pauseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PauseButton_Click(sender, e);
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NextButton_Click(sender, e);
        }
        #endregion

        private void colorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = color.Color;
            if (DialogResult.OK == dlg.ShowDialog())
                color.Color = dlg.Color;
            graphicsPanel1.Invalidate();
        }

        //Saving stuff when user closes
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.CellColor = color.Color;
            Properties.Settings.Default.Save();
        }

        private void resetSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reset();
            color.Color = Properties.Settings.Default.CellColor;

            graphicsPanel1.Invalidate();
        }

        private void reloadSettingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Reload();
            color.Color = Properties.Settings.Default.CellColor;

            graphicsPanel1.Invalidate();
        }

        private void OptionsToolStrip_Click(object sender, EventArgs e)
        {
            Options options = new Options();
            sizeX = universe.GetLength(0);
            sizeY = universe.GetLength(1);
            options.UniverseHeight = sizeY;
            options.UniverseWidth = sizeX;
            options.Time = timer.Interval;
            if (DialogResult.OK == options.ShowDialog())
            {
                timer.Interval = options.Time;
                sizeY = options.UniverseHeight;
                sizeX = options.UniverseWidth;
                universe = new bool[sizeX, sizeY];
                spad = new bool[sizeX, sizeY];
                newToolStripMenuItem1_Click(sender, e);
            }
            graphicsPanel1.Invalidate();
        }

        //Random
        #region
        private void fromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rand = new Random();
            for (int x = 0; x < universe.GetLength(0); x++) //X-Axis
            {
                for (int y = 0; y < universe.GetLength(1); y++) //Y-Axis
                {
                    int randomize = rand.Next(0, 2);
                    if (randomize == 1)
                        universe[x, y] = false;
                    else
                        universe[x, y] = true;
                }
            }
            GetLiveCellCount();
            graphicsPanel1.Invalidate();
        }

        private void fromNewSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == seed.ShowDialog())
            {
                rand = new Random(seed.Value);

                for (int x = 0; x < universe.GetLength(0); x++) //X-Axis
                {
                    for (int y = 0; y < universe.GetLength(1); y++) //Y-Axis
                    {
                        int randomize = rand.Next() % 2;
                        if (randomize == 1)
                            universe[x, y] = false;
                        else
                            universe[x, y] = true;
                    }
                }
                GetLiveCellCount();
                graphicsPanel1.Invalidate();
            }
        }

        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rand = new Random(seed.Value);

            for (int x = 0; x < universe.GetLength(0); x++) //X-Axis
            {
                for (int y = 0; y < universe.GetLength(1); y++) //Y-Axis
                {
                    int randomize = rand.Next() % 2;
                    if (randomize == 1)
                        universe[x, y] = false;
                    else
                        universe[x, y] = true;
                }
            }
            GetLiveCellCount();
            graphicsPanel1.Invalidate();
        }

        private void randomFromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fromTimeToolStripMenuItem_Click(sender, e);
        }
        #endregion

        //Save + Open
        #region
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";


            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamWriter writer = new StreamWriter(dlg.FileName);

                for (int y = 0; y < universe.GetLength(1); y++)
                {
                    String currentRow = string.Empty;
                    for (int x = 0; x < universe.GetLength(0); x++)
                    {
                        if (universe[x, y] == true)
                            writer.Write("O");
                        else
                            writer.Write(".");
                    }
                    writer.WriteLine();
                }
                writer.Close();
            }
        }

        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;

            if (DialogResult.OK == dlg.ShowDialog())
            {
                StreamReader reader = new StreamReader(dlg.FileName);
                int maxWidth = 0;
                int maxHeight = 0;
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    //while (row != null)
                    for (int i = 0; i < row.Length; i++)
                    {
                        if (row.Length > universe.GetLength(0))
                            maxWidth = row.Length;

                        maxHeight++;
                    }
                }
                universe = new bool[maxWidth, maxHeight];
                spad = new bool[maxWidth, maxHeight];
                reader.BaseStream.Seek(0, SeekOrigin.Begin);
                while (!reader.EndOfStream)
                {
                    string row = reader.ReadLine();
                    for (int xPos = 0; xPos < row.Length; xPos++)
                    {
                        if (row[xPos] == 'O')
                            universe[xPos, 0] = true;
                        else if (row[xPos] == '.')
                            universe[xPos, 0] = false;
                    }
                }
                reader.Close();
            }
            GetLiveCellCount();
            graphicsPanel1.Invalidate();
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            saveToolStripMenuItem1_Click(sender, e);
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            openToolStripMenuItem1_Click(sender, e);
        }
        #endregion

        //View Options
        private void gridVisibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridVisibleToolStripMenuItem.Checked == false)
                IsGridVisible = false;
            else
                IsGridVisible = true;

            graphicsPanel1.Invalidate();
        }
    }
}
