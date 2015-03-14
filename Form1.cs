using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CalculadoraFabieli
{
    public partial class Form1 : Form
    {

        double value = 0;
        double value2 = 0;
        string operacao = "";
        bool operacao_pressed = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {

            if ((result.Text == "0") || (operacao_pressed))
                result.Clear();

            operacao_pressed = false;
            Button b = (Button)sender;

            if (b.Text == ",")
            {

                if (!result.Text.Contains(","))
                    result.Text += ",";
            }

            else
                result.Text += b.Text;

            if (operacao == "")
                equacao.Text = result.Text;
            else
                equacao.Text = value2 + " " + operacao + " " + result.Text;
        }


        private void operacao_click(object sender, EventArgs e)
        {

            if (operacao != "")
            {
                Contas();
            }

            value2 = double.Parse(result.Text);
            Button b = (Button)sender;

            if (value != 0)
            {
                operacao_pressed = true;
                operacao = b.Text;
            }

            else
            {
                operacao = b.Text;
                operacao_pressed = true;
            }

            equacao.Text = value2 + " " + operacao;
        }

        private void resultado_click(object sender, EventArgs e)
        {
            Contas();
            operacao = "";
        }

        private void Contas()
        {

            value = double.Parse(result.Text);

            switch (operacao)
            {

                case "+":
                    result.Text = (value2 + value).ToString();
                    break;

                case "-":
                    result.Text = (value2 - value).ToString();
                    break;

                case "*":
                    result.Text = (value2 * value).ToString();
                    break;

                case "/":
                    result.Text = (value2 / value).ToString();
                    break;

                case "%":
                    result.Text = (value2 / 100 * value).ToString();
                    break;

                case "resto":
                    result.Text = (value2 % value).ToString();
                    break;

                case "^":
                    result.Text = (Math.Pow(value2, value)).ToString();
                    break;

                case "√":
                    result.Text = Math.Sqrt(value2).ToString();
                    break;

                case "sen":
                    result.Text = (Math.Sin((Math.PI / 180) * value2)).ToString();
                    break;

                case "cos":
                    result.Text = (Math.Cos((Math.PI / 180) * value2)).ToString();
                    break;

                case "tg":
                    result.Text = (Math.Tan((Math.PI / 180) * value2)).ToString();
                    break;

                case "! Iterativa":
                    result.Text = FatorialIterativa(value2).ToString();
                    break;

                case "! Recursiva":
                    result.Text = FatorialRecursiva(value2).ToString();
                    break;

                case "Fi Iterativa":
                    if (value2 > 0)
                        result.Text = FibonacciIterativa(value2).ToString();
                    else
                    {
                        result.Text = "";
                        MessageBox.Show("Números negativos não permitidos");
                    }
                    break;

                case "Fi Recursiva":
                    if (value2 < 40)
                        result.Text = FibonacciRecursiva(value2).ToString();

                    else
                    {
                        result.Text = "";
                        MessageBox.Show("Números grandes no modo recursivo poderão travar a calculadora");
                    }
                    break;
            }
        }

        static double FatorialIterativa(double n)
        {
            double result = 1;

            for (int i = 1; i <= n; i++)
            {
                result = result * i;
            }
            return result;
        }


        static double FibonacciRecursiva(double num)
        {
            if (num == 1)
                return 0;
            else if (num == 2)
                return 1;
            else
                return FibonacciRecursiva(num - 1) + FibonacciRecursiva(num - 2);
        }


        static double FibonacciIterativa(double num)
        {

            double a = 0;
            double b = 1;
            double c = 1;

            for (double i = 1; i < num; i++)
            {
                a = b;
                b = c;
                c = a + b;
            }
            return a;
        }


        static double FatorialRecursiva(double n)
        {
            if (n == 0)
            {
                return 1;
            }
            else
                return n * FatorialRecursiva(n - 1);
        }


        private void CE_click(object sender, EventArgs e)
        {
            result.Text = "0";
            value = 0;
        }

        private void C_click(object sender, EventArgs e)
        {
            result.Clear();
            value = 0;
            result.Text = "0";
            operacao = "";
            equacao.Text = " ";
        }

    }
}