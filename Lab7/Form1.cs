using Payments;
using System;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Payment> arrayList = new List<Payment>();

        private List<string> array = new List<string>();

        private Payment payment;

        private string linesearch;

        public string LineSearch
        {
            get { return linesearch; }
            set { linesearch = value; }
        }

        private Finder finder = new Finder();

        private Bonus Bonus = new Bonus();

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void ViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("123.txt");
            dataGridView1.DataSource = null;
            while (reader.Peek() > 1)
            {
                string[] strings = reader.ReadLine().Split(";");
                if (Check(strings[0]) && strings.Length == 6)
                {
                    Payment payment = new Payment(strings[0], Double.Parse(strings[1]), Int32.Parse(strings[2]),
                        Double.Parse(strings[3]), Int32.Parse(strings[4]), Double.Parse(strings[5]));
                    arrayList.Add(payment);
                    array.Add(strings[0]);
                }
            }
            dataGridView1.DataSource = arrayList;
            reader.Close();
        }

        private bool Check(string str)
        {
            foreach (Payment payment in arrayList)
            {
                if (str == payment.�������)
                {
                    return false;
                }
            }
            return true;
        }

        private void CreateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (arrayList.Count != 0)
            {
                StreamWriter writer = new StreamWriter("123.txt", false);
                foreach (var item in arrayList)
                {
                    writer.WriteLine(item);
                }
                dataGridView1.DataSource = arrayList;
                writer.Close();
            }
            else throw new ArgumentException("���������� ������� ������ ����. ��������� ���� ������");
        }

        private void Create_Click(object sender, EventArgs e)
        {
            payment = new Payment(LN.Text, Double.Parse(S.Text), Int32.Parse(Y.Text),
                    Double.Parse(B.Text), Int32.Parse(GA.Text), Double.Parse(WA.Text));
            foreach (Payment payment in arrayList)
            {
                if (payment.������� == LN.Text)
                {
                    throw new ArgumentException("����� ������� ��� ����������");
                }
            }
            arrayList.Add(payment);
            array.Add(LN.Text);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = arrayList;
        }

        private void EditToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (arrayList.Count != 0)
            {
                int i = 0;
                bool check = false;
                foreach (Payment payment in arrayList)
                {
                    if (payment.������� == editLN.Text)
                    {
                        payment.������� = editLN.Text;
                        payment.����� = Double.Parse(editS.Text);
                        payment.��� = Int32.Parse(editY.Text);
                        payment.����������_����� = Double.Parse(editB.Text);
                        payment.��������� = Int32.Parse(editGA.Text);
                        payment.����_�_��������� = Double.Parse(editWA.Text);
                        arrayList[i] = payment;
                        check = true;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = arrayList;
                        break;
                    }
                    i++;
                }
                if (check == false)
                    throw new ArgumentException("��������� ��������� �������");
            }
            else throw new ArgumentException("���� ������ �����");
        }

        private void �������1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbcheck();
            arrayList.Sort();
            array.Sort();
            dataGridView1.Refresh();
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbcheck();
            arrayList.Sort();
            array.Sort();
            arrayList.Reverse();
            array.Reverse();
            dataGridView1.Refresh();
        }

        private void dbcheck()
        {
            if (dataGridView1.DataSource == null || arrayList.Count == 0)
            {
                throw new ArgumentException("������� ������� ������, � ������ ���� ��� ����, �� ������� ������ '�����������'");
            }
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbcheck();
            finder.ShowDialog();
            List<Payment> arrayListFind = new List<Payment>();
            int i = array.IndexOf(DataBank.Family);
            if (i == -1)
                throw new ApplicationException("����� ��������� �� ������");
            arrayListFind.Add(arrayList[i]);
            dataGridView1.DataSource = arrayListFind.GetRange(0, arrayListFind.Count);
            arrayListFind.Clear();
        }

        private void ��������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbcheck();
            finder.ShowDialog();
            List<Payment> arrayListFind = new List<Payment>();
            int i = array.BinarySearch(DataBank.Family);
            if (i < 0)
                throw new ApplicationException("����� ��������� �� ������");
            arrayListFind.Add(arrayList[i]);
            dataGridView1.DataSource = arrayListFind.GetRange(0, arrayListFind.Count);
            arrayListFind.Clear();
        }

        private void �������2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int max = 0;
            List<int> mas = new List<int>();
            foreach (Payment payment in arrayList)
            {
                mas.Add(payment.GivenAmount);
            }
            int i = mas.Max();
            mas.Clear();
            foreach (Payment payment in arrayList)
            {
                if (payment.GivenAmount != i)
                    mas.Add(payment.GivenAmount);
            }
            int i2 = mas.Min();
            mas.Clear();
            List<Payment> arrayListFind = new List<Payment>();
            foreach (Payment payment in arrayList)
            {
                if ((payment.GivenAmount == i) || (payment.GivenAmount == i2))
                    arrayListFind.Add(payment);
            }
            dataGridView1.DataSource = arrayListFind.GetRange(0, arrayListFind.Count);
            arrayListFind.Clear();
        }

        private void �������3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbcheck();
            Bonus.ShowDialog();
            List<Payment> arrayListFind = new List<Payment>();
            foreach (Payment payment in arrayList)
            {
                double IntBonus = (payment.ProcentBonus / 100) * payment.�����;
                if (IntBonus > DataBank.BonusSort)
                    arrayListFind.Add(payment);
            }
            dataGridView1.DataSource = arrayListFind.GetRange(0, arrayListFind.Count);
            arrayListFind.Clear();
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("������ ���������: v1.0\n" +
                "���������: ������� �����, �������: \n" +
                "������������\n");                
        }
    }
}
