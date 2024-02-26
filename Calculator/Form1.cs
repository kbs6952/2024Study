using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        enum Operators { None, Add, Subtract, Multiply, Divide, Result }

        Operators currentOperator= Operators.None;
        bool operatorChangeFlag = false;

        double firstValue = 0;
        double SecondeValue = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void button_7_Click(object sender, EventArgs e)
        {
            ReturnStringToDouble("7");
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            ReturnStringToDouble("8");
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            ReturnStringToDouble("9");
        }


        private void button_4_Click(object sender, EventArgs e)
        {
            ReturnStringToDouble("4");
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            ReturnStringToDouble("5");
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            ReturnStringToDouble("6");
        }

        private void button__Click(object sender, EventArgs e)
        {
            //곱하기
            firstValue = double.Parse(label_Display.Text);
            currentOperator = Operators.Multiply;
            operatorChangeFlag = true;
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            ReturnStringToDouble("1");
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            ReturnStringToDouble("2");
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            ReturnStringToDouble("3");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //마이너스
            firstValue = double.Parse(label_Display.Text);
            currentOperator = Operators.Subtract;
            operatorChangeFlag = true;
        }
        private void button_0_Click(object sender, EventArgs e)
        {
            if(operatorChangeFlag==true)
            {
                label_Display.Text = "0";
                operatorChangeFlag = false;
            }
        }
        private void button_Divide_Click(object sender, EventArgs e)
        {
            //나누기
            firstValue = double.Parse(label_Display.Text);
            currentOperator = Operators.Divide;
            operatorChangeFlag = true;
        }

        private void button_AllClear_Click(object sender, EventArgs e)
        {
            firstValue = 0;
            SecondeValue = 0;
            currentOperator = Operators.None;

        }


        private void button_Dot_Click(object sender, EventArgs e)
        {
            if(label_Display.Text.Contains("."))
            {
                return;
            }
            else
            {
                label_Display.Text+= ".";  
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            // 플러스 버튼
            firstValue = double.Parse(label_Display.Text);
            currentOperator = Operators.Add;
            operatorChangeFlag = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            SecondeValue = double.Parse(label_Display.Text);
            // firstvalue 연산자 secondvalue
            if(currentOperator==Operators.Add)
            {

            }
            else if(currentOperator==Operators.Subtract) { }
            else if (currentOperator==Operators.Multiply) { }
            else if (currentOperator==Operators.Divide)
            {
                if (SecondeValue == 0)
                {
                    MessageBox.Show("0으로는 숫자를 나눌수 없습니다.", "나누기의 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                firstValue /= SecondeValue;

                

                
            } 
           

            
        }
        private void ReturnStringToDouble(string stringNumber)
        {
            if(operatorChangeFlag)
            {
                // 연산자 처리만 이루어져야 하기 때문에
                operatorChangeFlag=false;
            }
            string result = label_Display.Text += stringNumber;

            label_Display.Text = double.Parse(result).ToString();
            
            

        }
    }
}
