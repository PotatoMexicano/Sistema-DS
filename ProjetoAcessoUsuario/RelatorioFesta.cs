using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoAcessoUsuario
{
    public partial class RelatorioFesta : Form
    {
        public RelatorioFesta()
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void RelatorioFesta_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Control.GetFesta();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == false)
            {
                dataGridView1.DataSource = Control.GetFestaNome(textBox1.Text, textBox2.Text);
            }
            else
            {
                string horaI = monthCalendar1.SelectionStart.ToShortDateString() + " " + dateTimePicker1.Value.ToShortTimeString();
                string horaF = monthCalendar1.SelectionStart.ToShortDateString() + " " + dateTimePicker2.Value.ToShortTimeString();
                //MessageBox.Show(horaI + " -- " + horaF);

                dataGridView1.DataSource = Control.GetFestaTime(horaI, horaF);
                
            }
        }
   }
}
