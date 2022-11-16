namespace calculator
{
    public partial class Form1 : Form
    {
        List<string> historyList = new();
        List<string> outputList = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void PopulateOutput()
        {
            outputList.Clear();
            string numberString1 = "";
            string operatorString = "";
            string numberString2 = "";
            bool firstNumber = true;
            // Run trough historyList to make the outputList
            foreach (var item in historyList)
            {
                // Check if item is number or operator
                if (int.TryParse(item, out int number) || item == "," || item == "+/-")
                {
                    // check if item is first number
                    if (firstNumber)
                    {
                        numberString1 = MakeNumberString(item, numberString1);
                    }
                    else
                    {
                        numberString2 = MakeNumberString(item, numberString2);
                    }
                } else 
                {
                    firstNumber = false;
                    operatorString = item;
                }
            }
            // check operator
            if (operatorString == "√" || operatorString == "sqr")
            {
                outputList.Add("");
                outputList.Add(operatorString);
                outputList.Add("(");
                outputList.Add(numberString1 + numberString2);
                outputList.Add(")");
                calcOutput.Text = String.Join("", outputList);
            }
            else
            {
                outputList.Add(numberString1);
                outputList.Add(operatorString);
                outputList.Add(numberString2);
                calcOutput.Text = String.Join(" ", outputList);
            }
        }

        private string MakeNumberString(string item, string numberString)
        {
            // Make sure string has only one comma
            bool commaInString = !numberString.Contains(',') || item != ",";
            // max number length
            bool numberLength = numberString.Length < 12;
            // Positive or negative
            if (item == "+/-")
            {
                if (numberString.Contains('-'))
                {
                    numberString = numberString.Remove(0, 1);
                }
                else
                {
                    numberString = numberString.Insert(0, "-");
                }
            }
            else if (commaInString && numberLength)
            {
                numberString += item;
            }
            return numberString;
        }

        private void CalculateOutput()
        {
            // check if output can be calculated
            bool checkOutputList = true;
            if (outputList[1] == "sqr" || outputList[1] == "√")
            {
                checkOutputList = outputList[3] != "" && !outputList[3].Contains('-') && outputList[3] != ",";
            }
            else
            {
                checkOutputList = outputList[0] != "" && outputList[0] != "-" && outputList[0] != "," 
                    && outputList[2] != "" && outputList[2] != "-" && outputList[2] != ",";
            }
            // Calculate the sum
            double calcSum = 0;
            if (checkOutputList)
            {
                switch (outputList[1])
                {
                    case "-":
                        calcSum = double.Parse(outputList[0]) - double.Parse(outputList[2]);
                        break;
                    case "+":
                        calcSum = double.Parse(outputList[0]) + double.Parse(outputList[2]);
                        break;
                    case "x":
                        calcSum = double.Parse(outputList[0]) * double.Parse(outputList[2]);
                        break;
                    case "÷":
                        calcSum = double.Parse(outputList[0]) / double.Parse(outputList[2]);
                        break;
                    case "√":
                        calcSum = Math.Sqrt(double.Parse(outputList[3]));
                        break;
                    case "sqr":
                        calcSum = Math.Pow(double.Parse(outputList[3]), 2);
                        break;
                }
            }
            calcOutput.Text += " = " + calcSum.ToString();
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            PopulateOutput();
            CalculateOutput();
        }

        private void backspaceButton_Click(object sender, EventArgs e)
        {
            // Remove last item from history
            if (historyList.Count > 0)
            {
                historyList.RemoveAt(historyList.Count - 1);
            }
            PopulateOutput();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            // Remove every item from history
            if (historyList.Count > 0)
            {
                historyList.Clear();
            }
            PopulateOutput();
        }

        private void positiveNegativeButton_Click(object sender, EventArgs e)
        {
            historyList.Add("+/-");
            PopulateOutput();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            historyList.Add("+");
            PopulateOutput();
        }

        private void subtractButton_Click(object sender, EventArgs e)
        {
            historyList.Add("-");
            PopulateOutput();
        }

        private void devideButton_Click(object sender, EventArgs e)
        {
            historyList.Add("÷");
            PopulateOutput();
        }

        private void multiplyButton_Click(object sender, EventArgs e)
        {
            historyList.Add("x");
            PopulateOutput();
        }

        private void squareButton_Click(object sender, EventArgs e)
        {
            historyList.Add("sqr");
            PopulateOutput();
        }

        private void squarerootButton_Click(object sender, EventArgs e)
        {
            historyList.Add("√");
            PopulateOutput();
        }

        private void zeroButton_Click(object sender, EventArgs e)
        {
            historyList.Add("0");
            PopulateOutput();
        }

        private void oneButton_Click(object sender, EventArgs e)
        {
            historyList.Add("1");
            PopulateOutput();
        }

        private void twoButton_Click(object sender, EventArgs e)
        {
            historyList.Add("2");
            PopulateOutput();
        }

        private void threeButton_Click(object sender, EventArgs e)
        {
            historyList.Add("3");
            PopulateOutput();
        }

        private void fourButton_Click(object sender, EventArgs e)
        {
            historyList.Add("4");
            PopulateOutput();
        }

        private void fiveButton_Click(object sender, EventArgs e)
        {
            historyList.Add("5");
            PopulateOutput();
        }

        private void sixButton_Click(object sender, EventArgs e)
        {
            historyList.Add("6");
            PopulateOutput();
        }

        private void sevenButton_Click(object sender, EventArgs e)
        {
            historyList.Add("7");
            PopulateOutput();
        }

        private void eightButton_Click(object sender, EventArgs e)
        {
            historyList.Add("8");
            PopulateOutput();
        }

        private void nineButton_Click(object sender, EventArgs e)
        {
            historyList.Add("9");
            PopulateOutput();
        }

        private void commatButton_Click(object sender, EventArgs e)
        {
            historyList.Add(",");
            PopulateOutput();
        }
    }
}