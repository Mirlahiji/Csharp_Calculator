namespace Csharp_Calculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        char UserOp = '\0';
        bool IsSecend = false;


        string GetNumbers(int number)
        {
            string NumberStr = number.ToString();
            return NumberStr;
        }
        void UserOpratorManager(int NumberUp)
        {
            if (IsSecend)
            {
                Stat2.Text += GetNumbers(NumberUp);
            }
            else
            {
                Stat1.Text += GetNumbers(NumberUp);
            }
        }

        void Oprators(char opr)
        {
            IsSecend = true;
            VisibleManager();
            UserOp = opr;
        }

        void VisibleManager()
        {
            if (IsSecend)
            {
                Stat1.Visible = false;
                Stat2.Visible = true;
            }
            else
            {
                Stat1.Visible = true;
                Stat2.Visible = false;
            }
        }


        private void Number1_Click(object sender, EventArgs e)
        {

            UserOpratorManager(1);
        }

        private void Number2_Click(object sender, EventArgs e)
        {
            UserOpratorManager(2);
        }

        private void Number3_Click(object sender, EventArgs e)
        {
            UserOpratorManager(3);
        }

        private void Number4_Click(object sender, EventArgs e)
        {
            UserOpratorManager(4);
        }

        private void Number5_Click(object sender, EventArgs e)
        {
            UserOpratorManager(5);
        }

        private void Number6_Click(object sender, EventArgs e)
        {
            UserOpratorManager(6);
        }

        private void Number7_Click(object sender, EventArgs e)
        {
            UserOpratorManager(7);
        }

        private void Number8_Click(object sender, EventArgs e)
        {
            UserOpratorManager(8);
        }

        private void Number9_Click(object sender, EventArgs e)
        {
            UserOpratorManager(9);
        }

        private void Zero_Click(object sender, EventArgs e)
        {
            UserOpratorManager(0);
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
            IsSecend = false;
            VisibleManager();

            double S1 = Double.Parse(Stat1.Text);
            double S2 = Double.Parse(Stat2.Text);
            double Answer = 0;

            switch (UserOp)
            {
                case '+':
                    Answer = S1 + S2;
                    break;
                case '-':
                    Answer = S1 - S2; ;
                    break;
                case '*':
                    Answer = S1 * S2; ;
                    break;
                case '/':
                    Answer = S1 / S2;
                    break;
                default:
                    Stat1.Text = "ERORR";
                    break;
            }
            Stat1.Text = Answer.ToString();
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            Oprators('+');
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Stat1.Text = "";
            Stat2.Text = "";

            IsSecend = false;
            VisibleManager();

        }

        private void Minus_Click(object sender, EventArgs e)
        {
            Oprators('-');
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            Oprators('/');
        }

        private void Multipluy_Click(object sender, EventArgs e)
        {
            Oprators('*');
        }
    }
}