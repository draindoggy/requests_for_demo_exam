namespace zayavki
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        string loginName = "user";
        string password = "12345";
        public string? textBoxLogin { get; set; }
        public string? textBoxPassword { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            textBoxLogin = textBox1.Text;
            textBoxPassword = textBox2.Text;

            if (textBoxLogin == loginName && textBoxPassword == password)
            {
                Form mainForm = new Form1();
                mainForm.ShowDialog();
            }
        }
    }
}
