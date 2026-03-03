using System;
using System.Windows.Forms;

namespace SimpleCalculatorWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

 
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            PerformOperation((num1, num2) => num1 + num2);
        }

     
        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            PerformOperation((num1, num2) => num1 - num2);
        }


        private void buttonMultiply_Click(object sender, EventArgs e)
        {
            PerformOperation((num1, num2) => num1 * num2);
        }

  
        private void buttonDivide_Click(object sender, EventArgs e)
        {
            PerformOperation((num1, num2) =>
            {
                if (num2 == 0)
                {
                    MessageBox.Show("Ошибка: деление на ноль!", "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return 0;
                }
                return num1 / num2;
            });
        }

        private void PerformOperation(Func<double, double, double> operation)
        {
            try
            {
           
                double num1 = Convert.ToDouble(textBoxNum1.Text);
                double num2 = Convert.ToDouble(textBoxNum2.Text);

                double result = operation(num1, num2);

                labelResult.Text = "= " + result;
            }
            catch (FormatException)
            {
               
                MessageBox.Show("Пожалуйста, введите корректные числа!",
                    "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message,
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}