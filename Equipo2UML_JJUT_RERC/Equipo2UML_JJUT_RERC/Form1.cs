using System.Security.Cryptography.Pkcs;

namespace Equipo2UML_JJUT_RERC
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Procesos P1 = new Procesos();
        private bool cambioPermitido = false;
        private bool A, B, C;
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!cambioPermitido)
            {
                e.Cancel = true;
            }
        }

        private bool logicaCheckbox()
        {
            int seleccionados = 0;
            A = false;
            B = false;
            C = false;
            if (!checkBox1.Checked) { MessageBox.Show("Debes seleccionar el seguro obligatorio (Opcion A)"); return false; }
            if (checkBox1.Checked) { seleccionados++; A = true; }
            if (checkBox2.Checked) { seleccionados++; B = true; }
            if (checkBox3.Checked) { seleccionados++; C = true; }

            if (seleccionados > 2) { MessageBox.Show("Solo puedes seleccionar dos seguros"); return false; }
            else { return true; }
        }

        private void limpiarCampos()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (P1.ValidarCampos(textBox1.Text) && P1.ValidarCampos(textBox2.Text) && P1.ValidarComboBox(comboBox1.SelectedItem) && P1.ValidarCampos(textBox3.Text) && P1.ValidarComboBox(comboBox2.SelectedItem) && P1.ValidarCampos(textBox4.Text) && P1.ValidarCampos(textBox5.Text))
            {
                if (P1.ValidarDouble(textBox3.Text) && P1.ValidarEntero(textBox4.Text) && P1.ValidarEntero(textBox5.Text))
                {
                    if (P1.RevisarPlaca(textBox2.Text))
                    {
                        cambioPermitido = true;
                        tabControl1.SelectedIndex = 1;
                        cambioPermitido = false;
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos correctamente.");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (logicaCheckbox())
            {
                P1.GuardarDatos(A, B, C, textBox1.Text, textBox2.Text, comboBox1.SelectedItem.ToString(), double.Parse(textBox3.Text), comboBox2.SelectedItem.ToString(), int.Parse(textBox4.Text), int.Parse(textBox5.Text));
                cambioPermitido = true;
                tabControl1.SelectedIndex = 0;
                cambioPermitido = false;
                limpiarCampos();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 Buscador = new Form2();
            Buscador.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            P1.cerrarPrograma();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cambioPermitido = true;
            tabControl1.SelectedIndex = 0;
            cambioPermitido = false;
        }
    }
}