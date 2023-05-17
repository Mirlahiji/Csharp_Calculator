using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using System.Diagnostics;
using static System.Windows.Forms.AxHost;

namespace Csharp_Calculator
{
    public partial class Form1 : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;
        [DllImport("User32.dll")] public static extern bool ReleaseCapture(); [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRctRgn(
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = Region.FromHrgn(CreateRoundRctRgn(0, 0, Width, Height, 40, 40));
        }

        private void onMouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        char UserOp = '\0';
        public double S2;
        public double S1;
        public bool IsSecend = false;

        string NumberToStr(int number)
        {
            string NumberStr = number.ToString();
            return NumberStr;
        }

        //Just Show Number on Screen then if any operation happens statement will be change to next
        void UserOpratorManager(int NumberUp)
        {
            Stat1.Text += NumberToStr(NumberUp);
            if (IsSecend)
            {
                Stat1.Text = "";
                Stat1.Text += NumberToStr(NumberUp);
            }
        }

        //Keep Operators and Save previse statement
        void Operators(char opr)
        {
            IsSecend = true;
            UserOp = opr;
            S1 = double.Parse(Stat1.Text);
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
            S2 = double.Parse(Stat1.Text);

            //Clear for show answer
            Stat1.Text = "";
            double Answer = 0;

            //Do Operation
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
                case 'p':
                    Answer = Math.Pow(S1, S2);
                    break;
                case 's':
                    Answer = Math.Sqrt(S1);
                    break;
                case 'l':
                    Answer = Math.Log10(S1);
                    break;
                case 'n':
                    Answer = Math.Log(S1);
                    break;
                default:
                    Stat1.Text = "ERROR";
                    break;
            }


            Stat1.Text = Answer.ToString();
            IsSecend = false;
            S1 = 0; S2 = 0;
        }

        private void Plus_Click(object sender, EventArgs e)
        {
            Operators('+');
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Stat1.Text = "";

        }

        private void Minus_Click(object sender, EventArgs e)
        {
            Operators('-');
        }

        private void Divide_Click(object sender, EventArgs e)
        {
            Operators('/');
        }

        private void Multipluy_Click(object sender, EventArgs e)
        {
            Operators('*');
        }

        private void power_Click(object sender, EventArgs e)
        {
            Operators('p');
        }

        private void Square_Click(object sender, EventArgs e)
        {
            Operators('s');
        }


        private void Nlog_Click(object sender, EventArgs e)
        {
            Operators('n');
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Operators('l');
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void srcCodeLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var ps = new ProcessStartInfo("https://github.com/Mirlahiji/Csharp_Calculator")
            {
                UseShellExecute = true,
                Verb = "open"
            };
            Process.Start(ps);
        }

    }
}