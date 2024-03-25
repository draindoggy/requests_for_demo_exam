namespace zayavki
{
    public partial class requestForm : Form
    {
        public requestForm()
        {
            InitializeComponent();
        }

        public string? equipment {  get; set; }
        public string? type { get; set; }
        public string? description { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            equipment = textBox1.Text;
            type = textBox2.Text;
            description = textBox3.Text;

            this.Close();
        }
    }
}