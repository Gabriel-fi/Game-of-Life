﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Game_of_Life
{
    public partial class Form1 : Form
    {
        bool[,] universe = new bool[20, 20];
        bool[,] spad = new bool[40, 40];
        Timer timer = new Timer();
        int gens = 0;

        //To-Do: fix the timer, floats, ...

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 70;
            timer.Tick += Timer_Tick;
            timer.Stop();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Calculate the new Generation
            gens++;
            //Update status
            GenerationStatus.Text = "Generations: " + gens.ToString();
            Update2();
            graphicsPanel1.Invalidate();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //TODO: Change int of w,h to floats
        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            float w = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            float h = graphicsPanel1.ClientSize.Height / universe.GetLength(1);
            for (float x = 0f; x < universe.GetLength(0); x++) //X-Axis
            {
                for (float y = 0f; y < universe.GetLength(1); y++) //Y-Axis
                {
                    RectangleF rect = RectangleF.Empty;
                    rect.X = x * w;
                    rect.Y = y * h;
                    rect.Width = w;
                    rect.Height = h;

                    if (universe[(int)x, (int)y] == true)
                    {
                        e.Graphics.FillRectangle(Brushes.DodgerBlue, rect.X, rect.Y, rect.Width, rect.Height);
                    }

                    e.Graphics.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
                }
            }
        }

        private static int AdjChecks(bool[,] universe, int ScreenSize, int x, int y, int horizontal, int veritcal)
        {
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
        private void Update2()
        {
            int sizeX = universe.GetLength(0);
            int sizeY = universe.GetLength(1);
            int size = 20;

            for (int i = 0; i < sizeX; i++)
            {
                for (int t = 0; t < sizeY; t++)
                {
                    spad[i, t] = universe[i, t];
                }
            }
            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    int count = AdjChecks(universe, size, x, y, -1, 0) + AdjChecks(universe, size, x, y, -1, 1) 
                        + AdjChecks(universe, size, x, y, 0, 1) + AdjChecks(universe, size, x, y, 1, 1) + AdjChecks(universe, size, x, y, 1, 0) 
                        + AdjChecks(universe, size, x, y, 1, -1) + AdjChecks(universe, size, x, y, 0, -1) + AdjChecks(universe, size, x, y, -1, -1);
                    bool isAlive = universe[x, y];
                    bool TurnOn = false;

                    if (isAlive && (count == 2 || count == 3))
                    {
                        TurnOn = true;
                    }
                    else if (!isAlive && count == 3)
                    {
                        TurnOn = true;
                    }

                    spad[x, y] = TurnOn;
                }
            }
            for (int i = 0; i < size; i++)
            {
                for (int t = 0; t < size; t++)
                {
                    universe[i, t] = spad[i, t];
                }
            }
        }
        /*
        private void Update1()
        {
            int sizeX = universe.GetLength(0);
            int sizeY = universe.GetLength(1);
            int count = 0;
            for (int a = 0; a < sizeX; a++)
            {
                for (int i = 0; i < sizeY; i++)
                {
                    spad[a, i] = universe[a, i];
                    
                }
            }
            for (int x = 0; x < universe.GetLength(0); x++) //X-Axis
            {
                for (int y = 0; y < universe.GetLength(1); y++) //Y-Axis
                {
                    //Check top
                    if (y - 1 >= 0 && universe[x, y - 1] == true)
                        count++;
                    //Check top-right
                    if (y - 1 >= 0 && x + 1 < sizeX && universe[x + 1, y - 1] == true)
                        count++;
                    //Check right
                    if (x + 1 < sizeX && universe[x + 1, y] == true)
                        count++;
                    //Check bottom-right
                    if (y + 1 < sizeY && x + 1 < sizeX && universe[x + 1, y + 1] == true)
                        count++;
                    //Check-bottom
                    if (y + 1 < sizeY && universe[x, y + 1] == true)
                        count++;
                    //Check bottom-left
                    if (y + 1 < sizeY && x - 1 >= 0 && universe[x - 1, y + 1] == true)
                        count++;
                    //Check left
                    if (x-1>=0 && universe[x - 1, y] == true)
                        count++;
                    //Check top-left
                    if (y - 1 >= 0 && x - 1 >= 0 && universe[x - 1, y - 1] == true)
                        count++;

                    ////////////////Living is dying
                    //if (count > 3)
                    //spad[x, y] = false;
                    //////////////////Living in the next generation
                    if (universe[x, y] && (count == 2 || count == 3))
                        spad[x, y] = true;
                    ///////////////////Living is dying
                    //else if (count <= 1)
                    //spad[x, y] = false;
                    //////////////Dead will Live
                    else if (universe[x, y] && count == 3)
                        spad[x, y] = true;
                }
            }
            //bool[,] tmp = universe;
            //universe = spad;
            //spad = tmp;

            
            for (int x = 0; x < universe.GetLength(0); x++) //X-Axis
            {
                for (int y = 0; y < universe.GetLength(1); y++) //Y-Axis
                {
                    universe[x, y] = spad[x, y];
                    //spad[x, y] = false;
                }
            }
            spad = new bool[40, 40];
            
        }
        */
        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            float w = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            float h = graphicsPanel1.ClientSize.Height / universe.GetLength(1);
            try
            {
                if (e.Button == MouseButtons.Left)
                {
                    float x = e.X / w;
                    float y = e.Y / h;


                    universe[(int)x, (int)y] = !universe[(int)x, (int)y];
                }
                graphicsPanel1.Invalidate();
            }
            catch (IndexOutOfRangeException) { }

        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < universe.GetLength(0); x++) //X-Axis
            {
                for (int y = 0; y < universe.GetLength(1); y++) //Y-Axis
                {
                    universe[x, y] = false;
                }
            }
            timer.Stop();
            gens = 0;
            GenerationStatus.Text = "Generations: " + gens.ToString();
            graphicsPanel1.Invalidate();
        }

        private void PlayButton_Click(object sender, EventArgs e)
        {
            timer.Start();
        }

        private void PauseButton_Click(object sender, EventArgs e)
        {
            timer.Stop();
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            //Calculate the new Generation
            gens++;
            //Update status
            GenerationStatus.Text = "Generations: " + gens.ToString();
            Update2();
            graphicsPanel1.Invalidate();
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem1_Click(sender, e);
        }
    }
}
