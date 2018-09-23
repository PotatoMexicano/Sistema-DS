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
    public partial class Configuracao : Form
    {

        public ConfiguracaoMenu config;
        public Usuario usuario;

        public Configuracao(Usuario usuario, ConfiguracaoMenu confg)
        {
            InitializeComponent();
            this.usuario = usuario;
            this.config = confg;

            if (!(config.image == "")) {
                pictureBox1.Image = Image.FromFile(config.image);

                openFileDialog1.FileName = config.image;

                label2.Font = new Font(config.nome_fonte, config.tamanho_texto);

                label2.ForeColor = Color.FromArgb(config.corR, config.corG, config.corB);

                fontDialog1.Font = label2.Font;

                fontDialog1.Color = label2.ForeColor;
            }
            
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = config.image;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            config.id = usuario.Id;

            config.image = openFileDialog1.FileName;

            config.corR = fontDialog1.Color.R;

            config.corG = fontDialog1.Color.G;

            config.corB = fontDialog1.Color.B;

            config.nome_fonte = fontDialog1.Font.Name;

            config.tamanho_texto = fontDialog1.Font.Size;

            this.DialogResult = DialogResult.OK;


            Control.InsertConfig(config);


        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            fontDialog1.ShowColor = true;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                label2.Font = fontDialog1.Font;

                label2.ForeColor = fontDialog1.Color;
            }
        }

        private void Configuracao_Load(object sender, EventArgs e)
        {

        }
    }
}
