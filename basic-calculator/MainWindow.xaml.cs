using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace basic_calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Operations operations = new Operations();
        private double x = 0;
        private double y = 0;
        private bool isFirst = true;
        private bool operationFinished = false;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void updateOutputBox(string s)
        {
            if (output_block.Text.Length > 12) return;

            if (output_block.Text[0] == '0')
            {
                output_block.Text = s;
                return;
            }
            output_block.Text += s;
        }

        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            var conv = sender as Button;

            if (operationFinished)
            {
                output_block.Text = "0";
                operationFinished = false;
            }

            if (conv != null)
            {
                var num = conv.Tag.ToString();

                if(num != null)
                    updateOutputBox(num);
            }
        }

        private void clear_Click(object sender, RoutedEventArgs e)
        {
            output_block.Text = "0";
            cur_operation_block.Text = "";
            isFirst = true;
            x = 0;
            y = 0;
        }

        private void CalculatorReset()
        {
            isFirst = true;
            x = 0;
            y = 0;
            cur_operation_block.Text = "";
        }

        private void btn_dot_Click(object sender, RoutedEventArgs e)
        {
            if (output_block.Text.Contains('.')) return;
            if (output_block.Text.Length > 12) return;

            output_block.Text += "."; 
        }

        private void btn_operation_Click(object sender, RoutedEventArgs e)
        {
            var conv = sender as Button;

            if (conv == null) return;

            var op = conv.Tag.ToString();

            if (op == null) return;

            operations.ChangeOperation(op);
            cur_operation_block.Text = operations.GetOperation.ToString();

            // Checks if its first, to add input to variable X
            if (isFirst)
            {
                isFirst = false;
                Double.TryParse(output_block.Text, out x);
                output_block.Text = "0";
            }
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {
            if (isFirst) return;
            
            if (Double.TryParse(output_block.Text, out y))
            {
                output_block.Text = Calculation.Calculate(x, y, operations).ToString();
                CalculatorReset();
                operationFinished = true;
            }
        }

        private void percent_Click(object sender, RoutedEventArgs e)
        {
            if (isFirst)
            {
                if (!Double.TryParse(output_block.Text, out x)) return;
                x = Calculation.ToDecimal(x);
                output_block.Text = x.ToString();
                return;
            }

            if (!Double.TryParse(output_block.Text, out y)) return;
            y = Calculation.ToDecimal(y);
            output_block.Text = y.ToString();
        }

        private void negate_Click(object sender, RoutedEventArgs e)
        {
            if (isFirst)
            {
                if (!Double.TryParse(output_block.Text, out x)) return;
                x = Calculation.Negate(x);
                output_block.Text = x.ToString();
                return;
            }

            if (!Double.TryParse(output_block.Text, out y)) return;
            y = Calculation.Negate(y);
            output_block.Text = y.ToString();
        }

        private void undo_Click(object sender, RoutedEventArgs e)
        {
            if (output_block.Text.Length == 1)
            {
                if (output_block.Text[0] != '0')
                {
                    output_block.Text = "0";
                    return;
                }
                return;
            }

            output_block.Text = output_block.Text.Remove(output_block.Text.Length - 1);
        }
    }
}
