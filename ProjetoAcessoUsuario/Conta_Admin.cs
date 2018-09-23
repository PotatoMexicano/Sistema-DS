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
    public partial class Conta_Admin : Form
    {
        public Conta_Admin()
        {
            InitializeComponent();
            LoadListbox();
            LoadCombobox();

            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }

        public void LoadListbox()
        {
            listBox1.DataSource = Control.SelectUsers();
            listBox1.DisplayMember = Control.SelectUsers().Columns[1].ColumnName;
            listBox1.ValueMember = Control.SelectUsers().Columns[0].ColumnName;
        }
        public void LoadCombobox()
        {
            comboBox1.DataSource = Control.SelectType();
            comboBox1.DisplayMember = Control.SelectType().Columns[0].ColumnName;
            comboBox1.ValueMember = Control.SelectType().Columns[0].ColumnName;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //textBox1.Text = listBox1.Text;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
           
            if (MessageBox.Show("Confirma", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Control.RemoveUser(Convert.ToInt32(listBox1.SelectedValue.ToString()));
                LoadListbox();  //Atualiza o listBox
            }
            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Control.AdicionaUser(textBox1.Text, textBox2.Text, comboBox1.SelectedText);
            LoadListbox();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Conta_Admin_Load(object sender, EventArgs e)
        {

        }
    }
}
