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
    public partial class Conta_Usuario : Form
    {

       int id;
       public Conta_Usuario(Usuario usuario)
        {

            InitializeComponent();

            //Command for start child form in maximized state.
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Dock = DockStyle.Fill;



            label3.Text = usuario.Login.ToString();
            id = Convert.ToInt32(usuario.Id.ToString());

        }

        private void Button2_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Control.UpdateUser(id, textBox2.Text);
            MessageBox.Show("Senha alterada","",MessageBoxButtons.OK);
            this.Close();
        }

        private void Conta_Usuario_Load(object sender, EventArgs e)
        {
            
        }
    }
}
