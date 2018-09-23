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
    public partial class Menu : Form
    {
        ConfiguracaoMenu configuracaoMenu;
        Usuario usuario;
        string pathImage = "";
        public Menu(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }
        private void SairToolStripMenuItem_Click(object sender, EventArgs e)
        {
           DialogResult dialogResult =  MessageBox.Show("Alerta !","batata",MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
                new Login().Show();
            }
            else
            {

            }
        }
        private void FecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Menu_Load(object sender, EventArgs e)
        {
            if(usuario.Tipo == "vendedor")
            {
                clientesToolStripMenuItem.Visible = false;
                vendedoresToolStripMenuItem.Visible = false;
                listagemToolStripMenuItem.Visible = false;
            }else if (usuario.Tipo == "analista")
            {
                gerenciarToolStripMenuItem.Visible = false;
                gerenciarToolStripMenuItem1.Visible = false;
                novasVendasToolStripMenuItem.Visible = false;
                historicoToolStripMenuItem.Visible = false;
                listagemToolStripMenuItem.Visible = false;
            }
            contaToolStripMenuItem.Text = usuario.Login;
           Carregaconf();
        }
        private void Carregaconf()
        {
            configuracaoMenu = Control.GetMenuConfig(usuario.Id);
            if (configuracaoMenu != null)
            {
                if (!(configuracaoMenu.image == "")) {
                    this.BackgroundImage = Image.FromFile(configuracaoMenu.image);
                    menuStrip1.ForeColor = Color.FromArgb(configuracaoMenu.corR, configuracaoMenu.corG, configuracaoMenu.corB);
                    menuStrip1.Font = new Font(configuracaoMenu.nome_fonte, configuracaoMenu.tamanho_texto);
                }

            }
            else
            {
                configuracaoMenu = new ConfiguracaoMenu();
                configuracaoMenu.image = "";
                configuracaoMenu.corR = menuStrip1.ForeColor.R;
                configuracaoMenu.corG = menuStrip1.ForeColor.G;
                configuracaoMenu.corB = menuStrip1.ForeColor.B;
                configuracaoMenu.tamanho_texto = menuStrip1.Font.Size;
                configuracaoMenu.nome_fonte = menuStrip1.Font.Name;
                configuracaoMenu.id = usuario.Id;


            }
        }
        private void ContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (usuario.Tipo)
            {
                case "admin":
                    Conta_Admin conta_Admin = new Conta_Admin();
                    conta_Admin.MdiParent = this;
                    conta_Admin.Show();
                    break;
                case "vendedor":
                    Conta_Usuario conta_Usuario = new Conta_Usuario(usuario);
                    conta_Usuario.MdiParent = this;
                    conta_Usuario.Show();
                    break;
                case "analista":
                    Conta_Usuario conta_analista = new Conta_Usuario(usuario);
                    conta_analista.MdiParent = this;
                    conta_analista.Show();
                    break;
            }
        }
        private void ConfiguraçõesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Configuracao configuracao = new Configuracao(usuario, configuracaoMenu);
            configuracao.config.image = pathImage;
            configuracao.config.corR = menuStrip1.ForeColor.R;
            configuracao.config.corG = menuStrip1.ForeColor.G;
            configuracao.config.corB = menuStrip1.ForeColor.B;
            configuracao.config.tamanho_texto = menuStrip1.Font.Size;
            configuracao.config.nome_fonte = menuStrip1.Font.Name;

            if (configuracao.ShowDialog() == DialogResult.OK)
            {
               pathImage = configuracao.config.image;
                if (!(pathImage == ""))
                {
                    this.BackgroundImage = Image.FromFile(pathImage);
                }
               
                
               menuStrip1.ForeColor = Color.FromArgb(configuracao.config.corR, configuracao.config.corG, configuracao.config.corB);
                menuStrip1.Font = new Font(configuracao.config.nome_fonte, configuracao.config.tamanho_texto);
            }
        }

        private void InserirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Festa festa = new Festa();
            festa.MdiParent = this;

            festa.Show();

        }

        private void RelatorioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            RelatorioFesta relatorio = new RelatorioFesta();
            relatorio.MdiParent = this;
            relatorio.Show();
        }

        private void Menu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
