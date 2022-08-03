
namespace form
{
    public partial class Form1 : Form
    {
        Dados teste = new Dados();
        

        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string salvar = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source="+Application.StartupPath+@"\Database1.accdb";
            string comando = "INSERT INTO Database1(Dado1,Dado2,Dado3,Dado4)values(@Dado1,@Dado2,@Dado3,@Dado4)";

            teste.setCodigo(textBox5.Text);
            teste.setDado1(textBox4.Text);
            teste.setDado2(textBox1.Text);
            teste.setDado3(textBox3.Text);
            teste.setDado4(textBox2.Text);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}