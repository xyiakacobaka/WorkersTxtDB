using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7
{
    public partial class Finder : Form
    {
        public Finder()
        {
            InitializeComponent();
        }

        Form form1;

        private void Find_Click(object sender, EventArgs e)
        {
            if (FindFamily == null)
                throw new ApplicationException("Невозможно найти. Поле пустое, заполните его!");
            else
            {
                form1 = Application.OpenForms[0];
                form1.Show();
                DataBank.Family = FindFamily.Text;
                this.Close();
            }
        }

        private void FindFamily_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
