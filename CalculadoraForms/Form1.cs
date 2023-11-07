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
        bool apertouOperador = false;
        string numero1;
        string ultimoOp;
        string dadosDigitados = string.Empty;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txbTela.Clear();
            txbAux.Clear();
            //limpando strings e txb's pra que não fique salvos dados em strings de operações anteriores
            dadosDigitados = string.Empty;
            numero1 = string.Empty;
            apertouOperador = false;
        }

        private void Operador_Click(object sender, EventArgs e)
        {
            // Obter o botão que está chamando o evento
            var botao = (Button)sender;

            if (apertouOperador == false && txbTela.Text != "")
            {
                numero1 = txbTela.Text;
                dadosDigitados = numero1 + botao.Text;
                txbAux.Text = dadosDigitados;
                ultimoOp = botao.Text;
                apertouOperador = true;
            }
            else
            {
                if (txbAux.Text != "" && txbTela.Text != "")
                {
                    btnIgual.PerformClick();
                    txbAux.Text = txbTela.Text + botao.Text;
                    numero1 = txbTela.Text;
                    dadosDigitados = txbTela.Text + botao.Text;
                    txbTela.Text = "";
                    ultimoOp = botao.Text;
                }
            }
        }

        private void Numero_Click(object sender, EventArgs e)
        {
            // Obter o botão que está chamando o evento
            var botao = (Button)sender;
            dadosDigitados += botao.Text;
            txbTela.Text = dadosDigitados;

        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dadosDigitados))
            {
                string[] partes = dadosDigitados.Split(new char[] { '+', '-', 'x', '÷' });
                if (partes.Length == 2)
                {
                    numero1 = partes[0];
                    string operador = dadosDigitados.Substring(partes[0].Length, 1);
                    string numero2 = partes[1];

                    switch (operador)
                    {
                        case "+":
                            txbAux.Clear();
                            txbTela.Text = (int.Parse(numero1) + int.Parse(numero2)).ToString();
                            break;
                        case "-":
                            txbAux.Clear();
                            txbTela.Text = (int.Parse(numero1) - int.Parse(numero2)).ToString();
                            break;
                        case "x":
                            txbAux.Clear();
                            txbTela.Text = (int.Parse(numero1) * int.Parse(numero2)).ToString();
                            break;
                        case "÷":
                            txbAux.Clear();
                            txbTela.Text = (int.Parse(numero1) / int.Parse(numero2)).ToString();
                            break;
                    }
                }
            }
        }

    }
}
