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
            this.Close();
        }

        private void SaveDataToFile()
        {
            using (StreamWriter writer = new StreamWriter("login.txt", true))
            {
                foreach (string[] data in loginPasswordList)
                {
                    writer.WriteLine(string.Join(",", data));
                }
            }
        }
    }
}
