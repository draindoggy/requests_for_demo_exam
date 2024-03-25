namespace zayavki
{
    public partial class registration : Form
    {
        public List<string[]> loginPasswordList = new List<string[]>();
        public string? loginTextBox { get; set; }
        public string? passwordTextBox { get; set; }

        public registration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loginTextBox = textBox1.Text;
            passwordTextBox = textBox2.Text;

            loginPasswordList.Add(new string[] { loginTextBox, passwordTextBox });

            SaveDataToFile();
        }

        private void SaveDataToFile()
        {
            using (StreamWriter writer = new StreamWriter("login.txt"))
            {
                foreach (string[] data in loginPasswordList)
                {
                    writer.WriteLine(string.Join(",", data));
                }
            }
        }
        //private void LoadDataFromFile()
        //{
        //    if (File.Exists("login.txt"))
        //    {
        //        loginPasswordList.Clear();
        //        using (StreamReader reader = new StreamReader("login.txt"))
        //        {
        //            string line;
        //            while ((line = reader.ReadLine()) != null)
        //            {
        //                string[] data = line.Split(',');
        //                loginPasswordList.Add(data);
        //            }
        //        }
        //    }
        //}
    }
}
