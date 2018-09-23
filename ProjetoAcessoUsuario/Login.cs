using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAcessoUsuario
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Usuario usuario = Control.CapturaUsuario(textBox1.Text, textBox2.Text);
            if(usuario != null)
            {
                Menu login = new Menu(usuario);
                login.StartPosition = FormStartPosition.CenterScreen;
                login.Text = textBox1.Text;
                this.Hide();
                login.ShowDialog();  
            }
            else
            {
                MessageBox.Show("You Wrong Dude!");
            }            
        }
        private void Login_Load(object sender, EventArgs e)
        {
        }

    }
}
