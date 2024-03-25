namespace zayavki
{
    public partial class Form1 : Form
    {
        private List<string[]> dataList = new List<string[]>();

        public Form1()
        {
            InitializeComponent();
        }

        private void add_request_Click(object sender, EventArgs e)
        {
            Form requestForm = new requestForm();
            requestForm.ShowDialog();

            if (!string.IsNullOrEmpty(((requestForm)requestForm).equipment) &&
                !string.IsNullOrEmpty(((requestForm)requestForm).type) &&
                !string.IsNullOrEmpty(((requestForm)requestForm).description))
            {
                dataGridView1.Rows.Add(((requestForm)requestForm).equipment,
                                        ((requestForm)requestForm).type,
                                        ((requestForm)requestForm).description);

                dataList.Add(new string[] { ((requestForm)requestForm).equipment,
                                    ((requestForm)requestForm).type,
                                    ((requestForm)requestForm).description });
            }
            requestForm.Close();
        }

        private void LoadDataFromFile()
        {
            if (File.Exists("data.txt"))
            {
                dataList.Clear();
                using (StreamReader reader = new StreamReader("data.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        dataList.Add(data);
                    }
                }
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            LoadDataFromFile();

            foreach (string[] data in dataList)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridView1, data);
                dataGridView1.Rows.Add(row);
            }
        }
        private void SaveDataToFile()
        {
            using (StreamWriter writer = new StreamWriter("data.txt"))
            {
                foreach (string[] data in dataList)
                {
                    writer.WriteLine(string.Join(",", data));
                }
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            SaveDataToFile();
        }
    }
}