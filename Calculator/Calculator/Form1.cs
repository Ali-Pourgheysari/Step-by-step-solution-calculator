using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static Calculator.GFG;

namespace Calculator
{
    public partial class Form1 : Form
    {
        bool enter_value = false;
        string treeString = "";

        float iCelsius, iFahrenheit, iKevin;
        char iOperation;

        bool isnumber = false;
        bool containdot = false;
        bool arithmeticafterdot = false;

        LinkedStack Stack = new LinkedStack();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtStep.Text = "";
            txtDisplay.Text = "0";
            isnumber = false;
        }

        void iterate(nptr root, TreeNode node)
        {
            TreeNode leftnode = new TreeNode();
            TreeNode rightnode = new TreeNode();
            if (root == null)
            {
                if (root == null)
                {
                    return;
                }
                else
                {
                    rightnode = new TreeNode(root.data.ToString());
                }
                leftnode = new TreeNode(null);
            }
            else
            {
                if (root == null)
                {
                    rightnode = new TreeNode(null);
                }
                else
                {
                    rightnode = new TreeNode(root.data.ToString());
                }
                leftnode = new TreeNode(root.data.ToString());
            }
            TreeNode treenode = new TreeNode(root.data);
            iterate(root.left, treenode);
            node.Nodes.Add(treenode);
            iterate(root.right, treenode);
        }

        private void graphToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 379;
            txtDisplay.Width = 286;
            flowLayoutPanel2.Visible = false;
            groupBox2.Visible = false;
            tree.Location = new Point(12, 36);
            flowLayoutPanel1.Visible = false;
            tree.Visible = true;
            groupBox1.Visible = false;

            treeView1.Nodes.Clear();
            nptr root = build(treeString);
            TreeNode rootnode = new TreeNode("TREE");
            iterate(root, rootnode);
            treeView1.Nodes.Add(rootnode);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 607;
            txtDisplay.Width = 286;
            flowLayoutPanel1.Width = 286;
            flowLayoutPanel2.Visible = false;
            groupBox2.Visible = true;
            groupBox2.Location = new Point(304, 35);
            tree.Visible = false;

        }

        private void standardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 607;
            txtDisplay.Width = 286;
            flowLayoutPanel1.Width = 286;
            txtDisplay.Visible = true;
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = false;
            groupBox2.Visible = true;
            groupBox2.Location = new Point(304, 35);
            groupBox1.Visible = false;
            tree.Visible = false;

        }

        private void scientificToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 765;
            txtDisplay.Width = 448;
            flowLayoutPanel1.Width = 448;
            txtDisplay.Visible = true;
            flowLayoutPanel1.Visible = true;
            flowLayoutPanel2.Visible = true;
            groupBox2.Visible = true;
            groupBox2.Location = new Point(466, 36);
            groupBox1.Visible = false;
            tree.Visible = false;

        }

        private void temperatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 379;
            txtDisplay.Visible = false;
            flowLayoutPanel1.Visible = false;
            flowLayoutPanel2.Visible = false;
            groupBox1.Location = new Point(12, 35);
            groupBox2.Visible = false;
            tree.Visible = false;
            groupBox1.Visible = true;
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((txtDisplay.Text == "0") || (enter_value))
            {
                txtDisplay.Text = "";
            }
            enter_value = false;
            Button num = (Button)sender;
            if (!txtDisplay.Text.EndsWith(")"))
            {
                if (num.Text == ".")
                {
                    if (!containdot)
                    {
                        txtDisplay.Text = txtDisplay.Text + num.Text;
                        containdot = true;
                    }
                }
                else
                {
                    arithmeticafterdot = true;
                    txtDisplay.Text = txtDisplay.Text + num.Text;
                }
                isnumber = true;
            }

        }

        private void button_Click_1(object sender, EventArgs e)
        {
            txtDisplay.Text = "0";
            txtStep.Text = "";
            isnumber = false;
            containdot = false;

        }

        private void buttonback_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text[txtDisplay.Text.Length - 1] == '.')
            {
                containdot = false;
            }
            if (txtDisplay.Text[txtDisplay.Text.Length - 1] == ')')
            {
                Stack.push('(');
            }
            if (txtDisplay.Text[txtDisplay.Text.Length - 1] == '(')
            {
                Stack.pop();
            }
            if (txtDisplay.Text.Length > 0)
            {
                isnumber = true;
                txtDisplay.Text = txtDisplay.Text.Remove(txtDisplay.Text.Length - 1, 1);
                if (txtDisplay.Text.Length != 0)
                    switch (txtDisplay.Text[txtDisplay.Text.Length - 1])
                    {
                        case '+':
                        case '-':
                        case '×':
                        case '÷':
                        case '^':
                            isnumber = false;
                            break;
                    }
            }
            if (txtDisplay.Text == "")
            {
                txtDisplay.Text = "0";
                isnumber = false;
            }
        }

        private void arithmetic_op(object sender, EventArgs e)
        {
            Button num = (Button)sender;
            if (isnumber && txtDisplay.Text[txtDisplay.Text.Length - 1] != '.' && arithmeticafterdot
                && txtDisplay.Text[txtDisplay.Text.Length - 1] != '-' && txtDisplay.Text[txtDisplay.Text.Length - 1] != '+'
                && txtDisplay.Text[txtDisplay.Text.Length - 1] != '×' && txtDisplay.Text[txtDisplay.Text.Length - 1] != '÷')
            {
                if (txtDisplay.Text[txtDisplay.Text.Length - 1] != '(')
                {
                    txtDisplay.Text += num.Text.ToString();
                    isnumber = false;
                    containdot = false;
                }
                if (txtDisplay.Text[txtDisplay.Text.Length - 1] == '(' && num.Text == "-")
                {
                    txtDisplay.Text += num.Text.ToString();
                    isnumber = false;
                    containdot = false;
                }
            }
            if (txtDisplay.Text == "0" && num.Text == "-")
            {
                txtDisplay.Text = "-";
            }
        }

        private void Print(doublyLinkedList<string> list)
        {
            doublyLinkedList<string>.node<string> node = list.gethead().getNext();
            string dashnequal = "\n=";
            string printform = "";
            //o(n) onced counted
            while (node != list.gettail())
            {
                printform += node.getData();
                node = node.getNext();
            }

            string lastline = txtStep.Text.Split('=').Last();
            if (lastline != printform)
            {
                dashnequal += printform;
                txtStep.Text += dashnequal;
            }
        }


        private void StepByStepSoution(string result)
        {
            if (txtStep.Text == "Syntax Error")
            {
                return;
            }

            bool allowtoprint = false;
            doublyLinkedList<string> operatelist = new doublyLinkedList<string>();
            //o(n)
            for (int i = 0; i < result.Length; i++)
            {
                if ((!char.IsNumber(result[i]) && result[i] != '.') || (char.IsNumber(result[i]) && (result[i - 1] == '+' || result[i - 1] == '-'
                    || result[i - 1] == '^' || result[i - 1] == '÷' || result[i - 1] == '×' || result[i - 1] == '(' || result[i - 1] == ')')))
                {
                    operatelist.AddLast(result[i].ToString());
                }
                else
                {
                    operatelist.gettail().SetData(operatelist.gettail().getData() + result[i]);
                }
            }

            doublyLinkedList<string>.node<string> node = operatelist.gettail();
            doublyLinkedList<string>.node<string> head = operatelist.gethead();
            doublyLinkedList<string>.node<string> tail = operatelist.gettail();
            bool isException = false;
            //o(n)
            while (operatelist.gethead() != operatelist.gettail())
            {
                try
                {
                    if (node.getData() == null)
                    {
                        throw new Exception();
                    }
                    while (node.getData() != "(")
                    {
                        node = node.getprev();
                    }
                    head = node;
                    while (node.getData() != ")")
                    {
                        node = node.getNext();
                    }
                    tail = node;
                    node = head;
                    //o(n)
                    while (node.getNext() != tail)
                    {
                        node = node.getNext();
                        switch (node.getData())
                        {
                            case "^":
                                operatelist.AddBetween(node.getprev(), (Math.Pow(Convert.ToDouble(node.getprev().getData()), Convert.ToDouble(node.getNext().getData())).ToString()));
                                allowtoprint = true;
                                break;

                        }
                    }
                    //o(n)
                    if (allowtoprint)
                    {
                        Print(operatelist);
                        allowtoprint = false;
                    }
                    node = head.getNext();
                    //o(n)
                    // odd or even power
                    while (node != tail)
                    {
                        if (node.getData() == "+")
                        {
                            if (Convert.ToDouble(node.getNext().getData()) >= 0)
                            {
                                node.getNext().SetData($"+{node.getNext().getData()}");
                                node = operatelist.Deletenode(node);
                            }
                            else if (Convert.ToDouble(node.getNext().getData()) < 0)
                            {
                                node = operatelist.Deletenode(node);
                            }
                        }
                        else if (node.getData() == "-")
                        {
                            if (Convert.ToDouble(node.getNext().getData()) >= 0)
                            {
                                node.getNext().SetData((Convert.ToDouble(node.getNext().getData()) * (-1)).ToString());
                                node = operatelist.Deletenode(node);
                            }
                            else if (Convert.ToDouble(node.getNext().getData()) < 0)
                            {
                                node.getNext().SetData((Convert.ToDouble(node.getNext().getData()) * (-1)).ToString());
                                node.getNext().SetData($"+{node.getNext().getData()}");
                                node = operatelist.Deletenode(node);
                            }
                        }
                        node = node.getNext();
                    }
                    node = head;
                    if (head == operatelist.gethead() && tail == operatelist.gettail() && operatelist.gethead() == operatelist.gettail())
                    {
                        Print(operatelist);
                        break;
                    }
                    if (head.getNext() == tail.getprev())
                    {

                        if (tail.getNext() != null && tail.getNext().getData() == "^")
                        {
                            doublyLinkedList<string>.node<string> temp = tail.getNext();
                            if (temp.getNext().getData() == "(")
                            {
                                operatelist.AddBetweenNeg(head.getNext(), (Math.Pow(Convert.ToDouble(head.getNext().getData()), Convert.ToDouble(temp.getNext().getNext().getData())).ToString()));
                                allowtoprint = true;
                            }
                            else
                            {
                                operatelist.Deletenode(temp);
                                operatelist.AddBetweenmid(head, (Math.Pow(Convert.ToDouble(head.getNext().getData()), Convert.ToDouble(tail.getNext().getData())).ToString()));
                                allowtoprint = true;
                            }
                            Print(operatelist);
                            continue;
                        }
                        head.SetData(head.getNext().getData());
                        operatelist.Deletenode(head.getNext());
                        operatelist.Deletenode(head.getNext());
                        tail = head.getNext();
                        continue;
                    }

                    node = head;
                    //o(n)
                    while (node.getNext() != tail)
                    {
                        node = node.getNext();
                        try
                        {
                            if (Convert.ToDouble(node.getData()) >= 0 && !node.getData().StartsWith("+"))
                            {
                                node.SetData($"+{Convert.ToDouble(node.getData())}");
                            }
                        }
                        catch (Exception e)
                        {

                            continue;
                        }

                    }
                    if (allowtoprint)
                    {
                        Print(operatelist);
                        allowtoprint = false;
                    }
                    node = head;
                    //o(n)
                    while (node.getNext() != tail)
                    {
                        node = node.getNext();
                        switch (node.getData())
                        {
                            case "÷":
                                if (node.getNext().getData() == "(")
                                {
                                    operatelist.AddBetweenNeg(node.getprev(), (Convert.ToDouble(node.getprev().getData()) / Convert.ToDouble(node.getNext().getNext().getData())).ToString());
                                    tail = operatelist.gettail();
                                }
                                else
                                    operatelist.AddBetween(node.getprev(), (Convert.ToDouble(node.getprev().getData()) / Convert.ToDouble(node.getNext().getData())).ToString());
                                allowtoprint = true;
                                break;
                            case "×":
                                if (node.getNext().getData() == "(")
                                {
                                    operatelist.AddBetweenNeg(node.getprev(), (Convert.ToDouble(node.getprev().getData()) * Convert.ToDouble(node.getNext().getNext().getData())).ToString());
                                    tail = operatelist.gettail();
                                }
                                else
                                    operatelist.AddBetween(node.getprev(), (Convert.ToDouble(node.getprev().getData()) * Convert.ToDouble(node.getNext().getData())).ToString());
                                allowtoprint = true;
                                break;

                        }
                    }
                    node = head;
                    //o(n)
                    while (node.getNext() != tail)
                    {
                        node = node.getNext();
                        try
                        {
                            if (Convert.ToDouble(node.getData()) >= 0 && !node.getData().StartsWith("+"))
                            {
                                node.SetData($"+{Convert.ToDouble(node.getData())}");
                            }
                        }
                        catch (Exception)
                        {

                            continue;
                        }

                    }
                    if (allowtoprint)
                    {
                        Print(operatelist);
                        allowtoprint = false;
                    }
                    node = head.getNext();
                    //o(n)
                    while (node.getNext() != tail)
                    {
                        node = node.getNext();
                        node.getprev().SetData((Convert.ToDouble(node.getprev().getData()) + Convert.ToDouble(node.getData())).ToString());
                        operatelist.Deletenode(node);
                        allowtoprint = true;

                    }
                    if (allowtoprint)
                    {
                        Print(operatelist);
                        allowtoprint = false;
                    }
                }
                catch (Exception e)
                {
                    txtStep.Text = "Stntax Error";
                    isException = true;
                    break;
                }
            }
            if (!isException && txtStep.Text.Last() == ')')
            {
                string finalRes = "";
                node = operatelist.gethead();
                finalRes += node.getData();
                //o(n)
                while (node != operatelist.gettail())
                {
                    finalRes += node.getNext().getData();
                    node = node.getNext();
                }
                DataTable dt = new DataTable();
                var v = dt.Compute(finalRes, "");
                txtStep.Text += $"\n={v}";
            }
            
        }

        private void btnequal_click(object sender, EventArgs e)
        {
            switch (txtDisplay.Text[txtDisplay.Text.Length - 1])
            {
                case '+':
                case '-':
                case '×':
                case '÷':
                case '.':
                case '^':
                    txtDisplay.Text = "Syntax Error";
                    break;
            }
            if (!Stack.isEmpty())
            {
                int sizeofstack = Stack.size();
                for (int i = 0; i < sizeofstack; i++)
                {
                    txtDisplay.Text += ")";
                    Stack.pop();
                }
            }
            txtStep.Text = txtDisplay.Text;
            txtDisplay.Text = "0";
            isnumber = false;
            string sqrt = "";
            string result = txtStep.Text;
            //o(n)
            if (txtStep.Text.Contains("√"))
            {
                for (int i = 0; i < txtStep.Text.Length; i++)
                {
                    if (txtStep.Text[i] == '√')
                    {
                        int j;
                        for (j = i + 1; (j < txtStep.Text.Length) && (char.IsDigit(txtStep.Text[j]) || txtStep.Text[j] == '.'); j++)
                        {
                            sqrt += txtStep.Text[j];
                            i++;
                        }
                        try
                        {
                            string temp = Math.Sqrt(Convert.ToDouble(sqrt)).ToString();
                            result = result.Replace($"√{sqrt}", temp);
                            txtStep.Text += $"\n={result}";
                        }
                        catch (Exception)
                        {
                            txtStep.Text = "Syntax Error";
                            break;
                        }
                        
                        
                    }
                }
            }
            int lengthofStepAfterSqrt = result.Length;


            string a = txtStep.Text;
            //o(n/2)
            while (Stack.size() > 0)
            {
                Stack.pop();
            }
            //o(n)
            if (a.Contains("Sin") || a.Contains("Cos") || a.Contains("Tan") || a.Contains("Log"))
                result = calc_SinCosTanLog(lengthofStepAfterSqrt, result);

            //o(n^2)
            StepByStepSoution("(" + result + ")");

            treeString = "(" + result + ")";
            treeString = treeString.Replace('×', '*');
            treeString = treeString.Replace('÷', '/');
        }

        string calc_SinCosTanLog(int length, string stepLastLine)
        {
            string result = stepLastLine;
            for (int i = 0; i < length - 3; i++)
            {
                if (result[i] == 'S')
                {
                    int j;
                    string num = "";
                    for (j = i + 4; stepLastLine[j] != ')'; j++)
                    {
                        num += stepLastLine[j];
                        i++;
                    }
                    string temp = Math.Sin(Convert.ToDouble(num) * Math.PI / 180).ToString();
                    result = result.Replace($"Sin({num})", $"({temp})");
                }
                if (result[i] == 'C')
                {
                    int j;
                    string num = "";
                    for (j = i + 4; stepLastLine[j] != ')'; j++)
                    {
                        num += stepLastLine[j];
                        i++;
                    }
                    string temp = Math.Cos(Convert.ToDouble(num) * Math.PI / 180).ToString();
                    result = result.Replace($"Cos({num})", $"({temp})");
                }
                if (result[i] == 'T')
                {
                    int j;
                    string num = "";
                    for (j = i + 4; stepLastLine[j] != ')'; j++)
                    {
                        num += stepLastLine[j];
                        i++;
                    }
                    string temp = Math.Tan(Convert.ToDouble(num) * Math.PI / 180).ToString();
                    result = result.Replace($"Tan({num})", $"({temp})");
                }
                if (result[i] == 'L')
                {
                    int j;
                    string num = "";
                    for (j = i + 4; stepLastLine[j] != ')'; j++)
                    {
                        num += stepLastLine[j];
                        i++;
                    }
                    string temp = Math.Log10(Convert.ToDouble(num) * Math.PI / 180).ToString();
                    result = result.Replace($"Log({num})", $"({temp})");
                }
            }

            txtStep.Text += $"\n={result}";
            return result;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0")
                txtDisplay.Text = "3.14159";
            else if (!isnumber)
                txtDisplay.Text += "3.14159";

            arithmeticafterdot = true;
        }


        private void button34_Click(object sender, EventArgs e)
        {
            if (txtDisplay.Text == "0")
                txtDisplay.Text = "√";
            else if (!isnumber)
                txtDisplay.Text += "√";

            arithmeticafterdot = true;
            isnumber = true;
        }

        private void rbCeltoFah_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = 'C';
        }

        private void rbFahtoCel_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = 'F';

        }

        private void rbKevin_CheckedChanged(object sender, EventArgs e)
        {
            iOperation = 'K';

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            switch (iOperation)
            {
                case 'C':
                    iCelsius = float.Parse(txttemp.Text);
                    txtConvert.Text = (((9 * iCelsius) / 5) + 32).ToString();
                    break;
                case 'F':
                    iFahrenheit = float.Parse(txttemp.Text);
                    txtConvert.Text = (((iFahrenheit - 32) * 5) / 9).ToString();
                    break;
                case 'K':
                    iKevin = float.Parse(txttemp.Text);
                    txtConvert.Text = (((9 * iKevin) / 5) + 305.15).ToString();
                    break;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            txtConvert.Clear();
            txttemp.Clear();
            rbCeltoFah.Checked = false;
            rbFahtoCel.Checked = false;
            rbKevin.Checked = false;
        }

        private void paranthes1(object sender, EventArgs e)
        {
            if (!isnumber || txtDisplay.Text[txtDisplay.Text.Length - 1] == '(')
            {

                if (txtDisplay.Text == "0")
                {
                    txtDisplay.Text = "(";
                }
                else
                {
                    Button num = (Button)sender;
                    txtDisplay.Text += num.Text.ToString();
                }
                Stack.push('(');
            }
            isnumber = true;
        }

        private void paranthes2(object sender, EventArgs e)
        {
            char comp = txtDisplay.Text[txtDisplay.Text.Length - 1];
            if (!Stack.isEmpty() && comp != '+' && comp != '-' && comp != '×' && comp != '÷' && txtDisplay.Text[txtDisplay.Text.Length - 1] != '(')
            {
                Button num = (Button)sender;
                txtDisplay.Text += num.Text.ToString();
                Stack.pop();
            }
            isnumber = true;
        }


        private void TanLogSinCos_click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (txtDisplay.Text == "0")
                txtDisplay.Text = $"{btn.Text}(";
            else if (!isnumber)
                txtDisplay.Text += $"{btn.Text}(";

            Stack.push('(');
            arithmeticafterdot = true;
            isnumber = true;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            double a;
            a = Convert.ToDouble(txtDisplay.Text) / Convert.ToDouble(100);
            txtDisplay.Text = "";
            txtStep.Text = Convert.ToString(a);
        }
    }
}
