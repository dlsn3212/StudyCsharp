using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using TESTMyStockSystem.Subitems;

namespace TESTMyStockSystem
{
    public partial class MainForm : MetroForm
    {
        public MainForm()
        {
            InitializeComponent();
            this.Location = new Point(Screen.PrimaryScreen.Bounds.Width / 2 - this.Size.Width / 2, Screen.PrimaryScreen.Bounds.Height / 2 - this.Size.Height / 2);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {



        }

        private void MtlSearchItem_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SearchItemForm searchItemForm = new SearchItemForm();
            searchItemForm.Location = this.Location;
            searchItemForm.ShowDialog();
            this.Close();
        }

        private void metroTile1_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            SearchPicForm searchPicForm = new SearchPicForm();
            searchPicForm.Location = this.Location;
            searchPicForm.ShowDialog();
            this.Close();
        }
    }
}
