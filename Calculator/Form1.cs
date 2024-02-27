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

        Operators currentOperators = Operators.None;

        bool operatorChangeFlag = false;
        double firstValue = 0;
        double secondValue = 0;

        public Form1()
        {
            InitializeComponent();
        }

        // 결국 =(연산결과)와 AC(올클리어)를 제외한 모든 클릭함수는 계산기를 클릭했을 시 나오는 display의 텍스트를 바꿔주는 역할 
        // 숫자 버튼을 클릭할때 double과 Tostring(문자열)로 번갈아 바꿔주는 건 디스플레이에 처음 설정한 0을 string으로 그대로 출력했을시 01이 되어 보여지기 때문임.
        // 그래서 double로 바꿔준뒤 다시 string으로 바꿔줌
        private void button_7_Click(object sender, EventArgs e)
        {
            ReturntoDoubleString("7");
        }

        private void button_8_Click(object sender, EventArgs e)
        {
            ReturntoDoubleString("8");
        }

        private void button_9_Click(object sender, EventArgs e)
        {
            ReturntoDoubleString("9");
        }

        private void button_4_Click(object sender, EventArgs e)
        {
            ReturntoDoubleString("4");
        }

        private void button_5_Click(object sender, EventArgs e)
        {
            ReturntoDoubleString("5");
        }

        private void button_6_Click(object sender, EventArgs e)
        {
            ReturntoDoubleString("6");
        }

        private void button_1_Click(object sender, EventArgs e)
        {
            ReturntoDoubleString("1");
        }

        private void button_2_Click(object sender, EventArgs e)
        {
            ReturntoDoubleString("2");
        }

        private void button_3_Click(object sender, EventArgs e)
        {
            ReturntoDoubleString("3");
        }

        private void button_0_Click(object sender, EventArgs e)
        {
            if (display.Text == "0" || operatorChangeFlag == true)
            {
                display.Text = "0";
                operatorChangeFlag = false;
            }
            else
                display.Text += "0";
        }

        private void ReturntoDoubleString(string number)
        {
            if (operatorChangeFlag == true)
            {
                display.Text = "";
                operatorChangeFlag = false;
            }
            string result = display.Text += number;
            display.Text = double.Parse(result).ToString();

        }
        private void button_Divide_Click(object sender, EventArgs e)
        {
            firstValue = double.Parse(display.Text);
            currentOperators = Operators.Divide;
            operatorChangeFlag = true;
        }
        private void button_Multiply_Click(object sender, EventArgs e)
        {
            firstValue = double.Parse(display.Text);
            currentOperators = Operators.Multiply;
            operatorChangeFlag = true;
        }

        private void button_Minus_Click(object sender, EventArgs e)
        {
            firstValue = double.Parse(display.Text);
            currentOperators = Operators.Subtract;
            operatorChangeFlag = true;
        }

        private void button_Plus_Click(object sender, EventArgs e)
        {
            firstValue = double.Parse(display.Text);
            currentOperators = Operators.Add;
            operatorChangeFlag = true;
        }

        private void button_AllClear_Click(object sender, EventArgs e)
        {
            firstValue = 0;
            secondValue = 0;
            display.Text = "0";
            operatorChangeFlag = false;
        }

        private void button_Dot_Click(object sender, EventArgs e)
        {
            if (display.Text.Contains("."))
            {
                return;
            }
            else
                display.Text += ".";
        }

        private void button_equals_Click(object sender, EventArgs e)
        {
            secondValue = double.Parse(display.Text);
            if (currentOperators == Operators.Add)
            {
                double result = firstValue + secondValue;
                display.Text = result.ToString();
            }
            else if (currentOperators == Operators.Subtract)
            {
                double result = firstValue - secondValue;
                display.Text = result.ToString();
            }
            else if (currentOperators == Operators.Multiply)
            {
                double result = firstValue * secondValue;
                display.Text = result.ToString();
            }
            else if (currentOperators == Operators.Divide)
            {
                if (secondValue == 0)
                {
                    MessageBox.Show("첫번 째 데이터에는 알려줄 정보를 입력하는 내용","메시지 박스의 제목을 입력",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    MessageBox.Show("0으로 나눌 수 없습니다", "나누기 에러", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    double result = firstValue / secondValue;
                    display.Text = result.ToString();
                }
                // 계산기를 업데이트
                // 기존 계산기에서 2+2에서 =을 안누르고 +2를 계속 누르면 계속 계산됨
            }
        }
    }
}
