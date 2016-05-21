using System;
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
    public partial class Options : Form
    {
        Color cell;
        Color back;
        Color grid;
        //Form1 main;
        public Options()
        {
            InitializeComponent();
            CellColorButton.BackColor = Properties.Settings.Default.CellColor;
            BackColorButton.BackColor = Properties.Settings.Default.Background;
            GridColorButton.BackColor = Properties.Settings.Default.GridColor;
        }

        //Event Handlers
        //public event EventHandler<ApplyEventArgs> FinalizeOptions;

        public Color Color
        {
            get { return CellColorButton.BackColor; }
            set { CellColorButton.BackColor = value; }
        }

        public Color GridColor
        {
            get { return GridColorButton.BackColor; }
            set { GridColorButton.BackColor = value; }
        }

        public Color BackgroundColor
        {
            get { return BackColorButton.BackColor; }
            set { BackColorButton.BackColor = value; }
        }

        public int Time
        {
            get { return (int)TimeUD.Value; }
            set { TimeUD.Value = value; }
        }

        public int UniverseWidth
        {
            get { return (int)WidthUD.Value; }
            set { WidthUD.Value = value; }
        }

        public int UniverseHeight
        {
            get { return (int)HeightUD.Value; }
            set { HeightUD.Value = value; }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            
        }

        //Normal stuff
        private void CellColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = cell;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                cell = dlg.Color;
                Properties.Settings.Default.CellColor = cell;
                CellColorButton.BackColor = cell;
            }
        }

        private void BackColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = back;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                back = dlg.Color;
                Properties.Settings.Default.Background = back;
                BackColorButton.BackColor = back;
            }
        }

        private void GridColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = grid;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                grid = dlg.Color;
                Properties.Settings.Default.GridColor = grid;
                GridColorButton.BackColor = grid;
            }
        }
    }
}
