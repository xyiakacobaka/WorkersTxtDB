using Payments;

namespace Lab7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private List<Payment> arrayList = new List<Payment>();

        private Payment payment;

        private string linesearch;

        public string LineSearch 
        { 
            get { return linesearch; } 
            set { linesearch = value; } 
        }

        private Finder finder = new Finder();

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
                }
            }
            dataGridView1.DataSource = arrayList;
            reader.Close();
        }

        private bool Check(string str)
        {
            foreach (Payment payment in arrayList)
            {
                if (str == payment.Фамилия)
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
            else throw new ArgumentException("Невозможно создать пустой файл. Проверьте базу данных");
        }

        private void Create_Click(object sender, EventArgs e)
        {
            payment = new Payment(LN.Text, Double.Parse(S.Text), Int32.Parse(Y.Text),
                    Double.Parse(B.Text), Int32.Parse(GA.Text), Double.Parse(WA.Text));
            foreach (Payment payment in arrayList)
            {
                if (payment.Фамилия == LN.Text)
                {
                    throw new ArgumentException("Такая фамилия уже существует");
                }
            }
            arrayList.Add(payment);
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
                    if (payment.Фамилия == editLN.Text)
                    {
                        payment.Фамилия = editLN.Text;
                        payment.Оклад = Double.Parse(editS.Text);
                        payment.Год = Int32.Parse(editY.Text);
                        payment.Процентный_Бонус = Double.Parse(editB.Text);
                        payment.Выплачено = Int32.Parse(editGA.Text);
                        payment.Долг_в_процентах = Double.Parse(editWA.Text);
                        arrayList[i] = payment;
                        check = true;
                        dataGridView1.DataSource = null;
                        dataGridView1.DataSource = arrayList;
                        break;
                    }
                    i++;
                }
                if (check == false)
                    throw new ArgumentException("Проверьте введенную фамилию");
            }
            else throw new ArgumentException("База данных пуста");
        }

        private void ExOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbcheck();
            arrayList.Sort();
        }

        private void сортировакаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbcheck();
            arrayList.Reverse();
            dataGridView1.Refresh();
        }

        private void dbcheck()
        {
            if (dataGridView1.DataSource == null || arrayList.Count == 0)
            {
                throw new ArgumentException("Сначало введите данные, в случае если они есть, то нажмите кнопку 'Просмотреть'");
            }
        }

        private void линейныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dbcheck();
            finder.ShowDialog();
            List<Payment> arrayListFind = new List<Payment>();
            int i = arrayList.FindIndex(r => r.Фамилия.Equals(DataBank.Family));
            arrayListFind.Add(arrayList[i]);
            dataGridView1.DataSource = arrayListFind;
        }
    }
}
