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
        bool[,] universe = new bool[5, 5];
        Timer timer = new Timer();
        int gens = 0;

        //To-Do: fix the timer, floats, ...

        public Form1()
        {
            InitializeComponent();
            timer.Interval = 20;
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //Calculate the new Generation
            gens++;
            //Update status
            GenerationStatus.Text = "Generations: " + gens.ToString();
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

                    if (universe[(int)x,(int)y] == true)
                    {
                        e.Graphics.FillRectangle(Brushes.Black, rect.X, rect.Y, rect.Width, rect.Height);
                    }

                    e.Graphics.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
                }
            }
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            float w = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            float h = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            if (e.Button == MouseButtons.Left)
            {
                float x = e.X / w;
                float y = e.Y / h;


                universe[(int)x, (int)y] = !universe[(int)x, (int)y];

                graphicsPanel1.Invalidate();
            }
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
            graphicsPanel1.Invalidate();
        }
    }
}