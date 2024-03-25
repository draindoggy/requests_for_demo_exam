namespace zayavki
{
    public partial class login : Form
    {
        public List<string[]> loginPasswordList1 = new List<string[]>();

        public login()
        {
            InitializeComponent();
            LoadDataFromFile();
        }
        private void LoadDataFromFile()
        {
            if (File.Exists("login.txt"))
            {
                loginPasswordList1.Clear();
                using (StreamReader reader = new StreamReader("login.txt"))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string[] data = line.Split(',');
                        loginPasswordList1.Add(data);
                    }
                }
            }
        }

        public string? textBoxLogin { get; set; }
        public string? textBoxPassword { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxLogin = textBox1.Text;
            textBoxPassword = textBox2.Text;

            bool loginSuccess = false;

            foreach (string[] loginData in loginPasswordList1)
            {
                if (textBoxLogin == loginData[0] && textBoxPassword == loginData[1])
                {
                    loginSuccess = true;
                    break;
                }
            }

            if (loginSuccess)
            {
                Form mainForm = new Form1();
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("неверные логин или пароль. пожалуйста, попробуйте снова.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Form regForm = new registration();
            regForm.ShowDialog();
        }
    }
}
