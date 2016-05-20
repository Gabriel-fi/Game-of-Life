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
    public partial class SeedForm : Form
    {
        public SeedForm()
        {
            InitializeComponent();
        }

        public int Value
        {
            get { return (int)numericUpDown1.Value; }
            set { numericUpDown1.Value = value; }
            
        }

        private void RandomButton_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            numericUpDown1.Value = rand.Next()%100001;
        }
    }
}
