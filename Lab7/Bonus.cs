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
    public partial class Bonus : Form
    {
        public Bonus()
        {
            InitializeComponent();
        }

        Form form1;

        private void Search_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == null)
                throw new ApplicationException("Поле пустое! Введите значение или закройте окно");
            form1 = Application.OpenForms[0];
            form1.Show();
            DataBank.BonusSort = Int32.Parse(textBox1.Text);
            this.Close();
        }
    }
}
