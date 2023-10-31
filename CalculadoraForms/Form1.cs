using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraForms
{
    public partial class Form1 : Form
    {
        int numero1;
        string ultimoOp;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbTela.Clear();
        }
        private void Operador_Click(object sender, EventArgs e)
        {
            // Obter o botão que está chamando o evento
            var botao = (Button)sender;
            numero1 = int.Parse(txbTela.Text);
            txbTela.Clear();
            txbAux.Text = numero1.ToString() + botao.Text;
            ultimoOp = botao.Text;

        }
        private void Numero_Click(object sender, EventArgs e)
        {
            // Obter o botão que está chamando o evento
            var botao = (Button)sender;
            txbTela.Text += botao.Text;
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            switch (ultimoOp)
            {
                case "+":
                    txbAux.Clear();
                    txbTela.Text = (numero1 + int.Parse(txbTela.Text)).ToString();
                    break;
            }
        }
    }
}
