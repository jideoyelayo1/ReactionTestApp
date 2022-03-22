using System.Diagnostics;

namespace ReactionTestApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ClickButton.Text = "Start";
        }

        public static bool clickOn = false;
        public static bool TimeFin = false;
        public async void Play()
        {
            Random rnd = new Random();
            var rndNum = rnd.Next(50,5000);
            ClickButton.BackColor = Color.Red;
            ClickButton.Text = "Stop";
            clickOn = false;
            TimerDone(rndNum);
            while (!TimeFin)
            {
                if (clickOn)
                {
                    ClickButton.Text = "Too soon\nYou LOSE!";
                    Thread.Sleep(3000);
                    Application.Restart();
                }
                await Task.Delay(1);
            }
           Stopwatch stop = new Stopwatch();
            stop.Start();
            ClickButton.BackColor = Color.Green;
            while (!clickOn)
            {
                await Task.Delay(1);
            }
            stop.Stop();
            TimeSpan ts = stop.Elapsed;
            DisplayButton.Text = Convert.ToString(ts.TotalMilliseconds)+ " milliseconds";



        }

        public async void TimerDone(int time)
        {
            await Task.Delay(time);
            TimeFin = true;
        }

        private void ClickButton_Click(object sender, EventArgs e)
        {
            clickOn = true;
        }

        private async void DisplayButton_Click(object sender, EventArgs e)
        {
            if(ClickButton.Text == "Start")
                Play();
            if(DisplayButton.Text.Contains(" milliseconds"))
                Application.Restart();

        }
    }
}