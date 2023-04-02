using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class Menu : Form
    {
        GameForm gameForm;

        public Menu()
        {
            InitializeComponent();
        }

        private void NewGame(int lvl)
        {
            gameForm = new GameForm(lvl);
            Hide();
            gameForm.Show();
        }

        private void buttonLv1_Click(object sender, EventArgs e)
        {
            NewGame(1);
        }

        private void buttonLv2_Click(object sender, EventArgs e)
        {
            NewGame(2);
        }

        private void buttonLv3_Click(object sender, EventArgs e)
        {
            NewGame(3);
        }
    }
}
