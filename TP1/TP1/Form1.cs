using System;
using Entidades;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void btnCerrar_OnClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOperar_OnClick(object sender, EventArgs e)
        {
            Numero num1 = new Numero(txtNumero1.Text);
            Numero num2 = new Numero(txtNumero2.Text);

            lblResultado.Text = Calculadora.Operar(num1, num2, cmbOperador.Text).ToString();            
        }

        private void txtNumero1_OnLeave(object sender, EventArgs e)
        {
            if (!double.TryParse(txtNumero1.Text,out double result))
            {
                ToolTip mensaje = new ToolTip();
                mensaje.IsBalloon = true;
                txtNumero1.Focus();
                mensaje.Show("Valor invalido",txtNumero1,20,-40,2000);
            }
        }

        private void txtNumero2_OnLeave(object sender, EventArgs e)
        {
            if (!double.TryParse(txtNumero2.Text, out double result))
            {
                ToolTip mensaje = new ToolTip();
                mensaje.IsBalloon = true;
                txtNumero2.Focus();
                mensaje.Show("Valor invalido", txtNumero2, 20, -40, 2000);
            }
        }

        private void btnLimpiar_OnClick(object sender, EventArgs e)
        {
            lblResultado.Text = "0";
            txtNumero1.Text = "";
            txtNumero2.Text = "";
            cmbOperador.Text = "";
        }
    }
}
