using System.Diagnostics;

namespace ReactionTestApp
{
    public partial class Reaction : Form
    {
        public Reaction()
        {
            InitializeComponent();
            DisplayButton.Text = "Click here to start";
            ClickButton.Text = "";
        }

        public static bool clickOn = false,TimeFin = false, Restart = false;

        public async void Play()
        {
            DisplayButton.Text = "";
            Restart = false;
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
            ClickButton.Text = "";
            while (!clickOn)
            {
                await Task.Delay(1);
            }
            stop.Stop();
            TimeSpan ts = stop.Elapsed;
            DisplayButton.Text = Convert.ToString(ts.TotalMilliseconds)+ " milliseconds";
            if (ts.TotalMilliseconds > 1500)
                DisplayButton.Text += "\nWere You sleeping? You must be tired";
            else if(ts.TotalMilliseconds > 1000)
                DisplayButton.Text += "\nYou're really bad at this";
            else if(ts.TotalMilliseconds > 6000)
                DisplayButton.Text += "\nTry Again! you can't actual be this bad";
            else if(ts.TotalMilliseconds > 300)
                DisplayButton.Text += "\nNot bad for a monkey like you";
            else if(ts.TotalMilliseconds > 200)
                DisplayButton.Text += "\nYou are showing some talent";
            else
                DisplayButton.Text += "\nOkay Okay Not bad";
            Restart = true;



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

        private void DisplayButton_Click(object sender, EventArgs e)
        {
            if (ClickButton.Text == "")
                Play();
            if (Restart)
            {
                ClickButton.Text = "";
            }
            if (DisplayButton.Text.Contains(" milliseconds"))
                Application.Restart();

        }
    }
}