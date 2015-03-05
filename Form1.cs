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
	public partial class Form1 : Form {

		float value = 0;
        float value2 = 0;
		string operacao = "";
		bool operacao_pressed = false;
		
		public Form1 () {

			InitializeComponent();
		}

		private void button_click(object sender, EventArgs e) {
		
			if((result.Text == "0") || (operacao_pressed))
			   result.Clear();

			operacao_pressed = false;
			Button b = (Button)sender;

			if (b.Text == ","){

				if(!result.Text.Contains(","))
				result.Text += ",";					
			}

			else
			result.Text += b.Text;

            if(operacao == "")
                equacao.Text = result.Text;
            else
                equacao.Text = value2 + " " + operacao + " " + result.Text;
		}


	
		private void operacao_click(object sender, EventArgs e){

            if (operacao != "") {
                Contas();
            }

            value2 = float.Parse(result.Text);
			Button b = (Button)sender;

			if(value !=0){
			    operacao_pressed = true;
			    operacao = b.Text;
			}

			else{
                operacao = b.Text;
			    operacao_pressed = true;
			}

            equacao.Text = value2 + " " + operacao;
		}

		private void resultado_click(object sender, EventArgs e){
            Contas();
            operacao = "";
        }

        private void Contas(){

           
            value = float.Parse(result.Text);

            switch (operacao){

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
                    result.Text = (Math.Sin((Math.PI / 180) *value2)).ToString();
                    break;

                case "cos":
                    result.Text = (Math.Cos((Math.PI / 180) *value2)).ToString();
                    break;

                case "tg":
                    result.Text = (Math.Tan((Math.PI / 180) *value2)).ToString();
                    break;
            }
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