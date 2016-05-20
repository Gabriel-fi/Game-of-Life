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
        Color color;
        //Form1 main;
        public Options()
        {
            InitializeComponent();
            CellColorButton.BackColor = Properties.Settings.Default.CellColor;
        }

        //Event Handlers
        //public event EventHandler<ApplyEventArgs> FinalizeOptions;

        public Color Color
        {
            get { return CellColorButton.BackColor; }
            set { CellColorButton.BackColor = value; }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            
            //ApplyEventArgs temp = new ApplyEventArgs();
            ////temp.Color = new Size(GetWidth, GetHeight);
            //FinalizeOptions(this, temp);
        }

        //Normal stuff
        private void CellColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog dlg = new ColorDialog();
            dlg.Color = color;
            if (DialogResult.OK == dlg.ShowDialog())
            {
                color = dlg.Color;
                Properties.Settings.Default.CellColor = color;
            }

            CellColorButton.BackColor = color;
            //Properties.Settings.Default.CellColor
        }


    }
}
