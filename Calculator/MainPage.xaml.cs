using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        double leftInput = 0;
        Boolean onOperation = false;
        Boolean resetDisplay = false;
        Boolean decimalDeclared = false;
        String operation = "";

        public MainPage()
        {
            this.InitializeComponent();
            Display.Text = 0.ToString();
        }

        private void addToDisplay(string input)
        {
            try
            {
                double number = double.Parse(input);
                if (Display.Text == "0" || resetDisplay)
                {
                    Display.Text = String.Empty;
                    resetDisplay = false;
                }
                Display.Text += number.ToString();

            } catch (FormatException e) {
                switch(input)
                {
                    case "+":
                        if(onOperation)
                            leftInput += double.Parse(Display.Text);
                        else
                            leftInput = double.Parse(Display.Text);
                        resetDisplay = true;
                        onOperation = true;
                        decimalDeclared = false;
                        Display.Text += "+";
                        operation = "+";
                        break;

                    case "-":
                        if (onOperation)
                            leftInput -= double.Parse(Display.Text);
                        else
                            leftInput = double.Parse(Display.Text);
                        resetDisplay = true;
                        onOperation = true;
                        decimalDeclared = false;
                        Display.Text += "-";
                        operation = "-";
                        break;

                    case "x":
                        if (onOperation)
                            leftInput *= double.Parse(Display.Text);
                        else
                            leftInput = double.Parse(Display.Text);
                        resetDisplay = true;
                        onOperation = true;
                        decimalDeclared = false;
                        Display.Text += "x";
                        operation = "x";
                        break;

                    case "/":
                        if (onOperation)
                            leftInput /= double.Parse(Display.Text);
                        else
                            leftInput = double.Parse(Display.Text);
                        resetDisplay = true;
                        onOperation = true;
                        decimalDeclared = false;
                        Display.Text += "/";
                        operation = "/";
                        break;

                    case "=":
                        if (onOperation)
                        {
                            switch (operation)
                            {
                                case "+":
                                    leftInput += double.Parse(Display.Text);
                                    break;
                                case "-":
                                    leftInput -= double.Parse(Display.Text);
                                    break;
                                case "x":
                                    leftInput *= double.Parse(Display.Text);
                                    break;
                                case "/":
                                    leftInput /= double.Parse(Display.Text);
                                    break;
                            }
                            Display.Text = leftInput.ToString();
                            onOperation = false;
                            decimalDeclared = false;
                            resetDisplay = true;
                        }
                        break;

                    case "c":
                        Display.Text = 0.ToString();
                        onOperation = false;
                        resetDisplay = false;
                        decimalDeclared = false;
                        operation = "";
                        leftInput = 0;
                        break;

                    case "del":
                        if(Display.Text.Last() == '.')
                        {
                            Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
                            decimalDeclared = false;
                        }
                        else if (Display.Text.Length > 0)
                            Display.Text = Display.Text.Substring(0, Display.Text.Length - 1);
                        if (Display.Text.Length == 0)
                            Display.Text = 0.ToString();
                        break;

                    case "-/+":
                        if(Display.Text != "0")
                        {
                            double current = double.Parse(Display.Text) * -1;
                            Display.Text = current.ToString();
                        }
                        break;

                    case ".":
                        if (!decimalDeclared)
                        {
                            Display.Text += ".";
                            decimalDeclared = true;
                        }
                        break;

                    default: break;
                }
            }
        }

        private void clearBtn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("c");
        }

        private void numDelBtn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("del");
        }

        private void numDivBtn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("/");
        }

        private void num7Btn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("7");
        }

        private void num8Btn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("8");
        }

        private void num9Btn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("9");
        }

        private void numMulBtn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("x");
        }

        private void num4Btn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("4");
        }

        private void num5Btn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("5");
        }

        private void num6Btn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("6");
        }

        private void numSubBtn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("-");
        }

        private void num1Btn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("1");
        }

        private void num2Btn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("2");
        }

        private void num3Btn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("3");
        }

        private void numAddBtn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("+");
        }

        private void numSignBtn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("-/+");
        }

        private void num0Btn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("0");
        }

        private void numdotBtn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay(".");
        }

        private void numEqBtn_Click(object sender, RoutedEventArgs e)
        {
            addToDisplay("=");
        }
    }
}
