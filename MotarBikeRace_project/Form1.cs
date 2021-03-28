using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MotarBikeRace_project
{
    public partial class Form1 : Form
    {
        
        //here i am goinng to get the name of the interested player 
        String interestedPlayer = "";
        int selectedBike = 0;

        Bike1 bke1 = new Bike1();
        Bike2 bke2 = new Bike2();
        Bike3 bke3 = new Bike3();
        Bike4 bke4 = new Bike4();


        int jolly = 100, punti = 100, gulab = 100;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //here we need to generate the Amount to select 
            for (int x=0;x<=50;x=x+5) {
                cbPayment.Items.Add("" + x);
            }
            play_btn.Visible = false;
        }

        private void jolly_has_CheckedChanged(object sender, EventArgs e)
        {
            if (jolly_has.Checked==true) {
                //here we need to check the plyer interested or not 
                interestedPlayer = "Jolly";
                punti_has.Checked = false;
                gulab_has.Checked = false;


            }
        }

        private void punti_has_CheckedChanged(object sender, EventArgs e)
        {
            if (punti_has.Checked == true)
            {
                //here we need to check the plyer interested or not 
                interestedPlayer = "Punti";
                jolly_has.Checked = false;
                gulab_has.Checked = false;

            }

        }

        private void gulab_has_CheckedChanged(object sender, EventArgs e)
        {
            if (gulab_has.Checked == true)
            {
                //here we need to check the plyer interested or not 
                interestedPlayer = "Gulab";
                punti_has.Checked = false;
                jolly_has.Checked = false;

            }
        }

        private void bike01_CheckedChanged(object sender, EventArgs e)
        {
            if (bike01.Checked==true) {
                selectedBike = 1;
                bike02.Checked = false;
                bike03.Checked = false;
                bike04.Checked = false;

            }
        }


        // when bike 2 is selected
        private void bike02_CheckedChanged(object sender, EventArgs e)
        {
            if (bike02.Checked == true)
            {
                selectedBike = 2;
                bike01.Checked = false;
                bike03.Checked = false;
                bike04.Checked = false;
            }
        }

        private void bike03_CheckedChanged(object sender, EventArgs e)
        {
            if (bike03.Checked == true)
            {
                selectedBike = 3;
                bike02.Checked = false;
                bike01.Checked = false;
                bike04.Checked = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            bike_pic1.Left += bke1.stepJump();
            if (bke1.gameOver(bike_pic1.Left) ==0) {
                timer1.Stop();
                MessageBox.Show("Bike 1 won the race ");
                final(1);
            }

            bike_pic2.Left += bke2.stepJump();
            if (bke2.gameOver(bike_pic2.Left) == 0)
            {
                timer1.Stop();
                MessageBox.Show("Bike 2 won the race ");
                final(2);
            }

            bike_pic3.Left += bke1.stepJump();
            if (bke3.gameOver(bike_pic3.Left) == 0)
            {
                timer1.Stop();
                MessageBox.Show("Bike 3 won the race ");
                final(3);
            }

            bike_pic4.Left += bke4.stepJump();
            if (bke4.gameOver(bike_pic4.Left) == 0)
            {
                timer1.Stop();
                MessageBox.Show("Bike 4 won the race ");
                final(4);
            }


        }

        // final function is made for storing all values 

        public void final(int winner) {
            Result res = new Result();
            String []h=jolly_has.Text.ToString().Split(' ');
            if (h.Length==4) {
                jolly=res.testResult(jolly_has.Text, winner, jolly);
            }
            String[] h1 = punti_has.Text.ToString().Split(' ');
            if (h1.Length == 4)
            {
                punti = res.testResult(punti_has.Text, winner, punti);

            }
            String[] h2 = gulab_has.Text.ToString().Split(' ');
            if (h2.Length == 4)
            {
                gulab = res.testResult(gulab_has.Text, winner, gulab);
            }

            bike_pic1.Left = 0;
            bike_pic2.Left = 0;
            bike_pic3.Left = 0;

            bike_pic4.Left = 0;
            interestedPlayer = "";
            selectedBike = 0;

            play_btn.Visible = false;

            jolly_has.Checked = false;
            punti_has.Checked = false;
            gulab_has.Checked = false;

            bike01.Checked = false;
            bike02.Checked = false;
            bike03.Checked = false;
            bike04.Checked = false;

            jolly_has.Text = "Jolly has " + jolly;
            punti_has.Text = "Punti has " + punti;
            gulab_has.Text = "Gulab has " + gulab;

        }

        // timer starting here
        private void play_btn_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        // if bike 4 selected

        private void bike04_CheckedChanged(object sender, EventArgs e)
        {
            if (bike04.Checked == true)
            {
                selectedBike = 4;
                bike02.Checked = false;
                bike03.Checked = false;
                bike01.Checked = false;
            }
        }

        //for setting bet 

        private void click_btn_set_bet_Click(object sender, EventArgs e)
        {
            if (!interestedPlayer.Equals("") && selectedBike != 0 && !cbPayment.Text.Equals(""))
            {
                switch (interestedPlayer) {
                    case "Jolly":
                        if (selectedBike > 0 && Convert.ToInt32(cbPayment.Text) <= jolly)
                        {
                            jolly_has.Text = "Jolly select " + selectedBike + " " + Convert.ToInt32(cbPayment.Text);
                            play_btn.Visible = true;
                        }
                        else {
                            MessageBox.Show("need to check the details ");
                        }
                    break;
                    case "Punti":
                        if (selectedBike > 0 && Convert.ToInt32(cbPayment.Text) <= punti)
                        {
                            punti_has.Text = "Punti select " + selectedBike + " " + Convert.ToInt32(cbPayment.Text);
                            play_btn.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("need to check the details ");
                        }
                        break;
                    case "Gulab":
                        if (selectedBike > 0 && Convert.ToInt32(cbPayment.Text) <= gulab)
                        {
                            gulab_has.Text = "Gulab select " + selectedBike + " " + Convert.ToInt32(cbPayment.Text);
                            play_btn.Visible = true;
                        }
                        else
                        {
                            MessageBox.Show("need to check the details ");
                        }
                        break;
                    default:
                        MessageBox.Show("Need to select the player ");
                        break;
                }   

            }
            else {
                MessageBox.Show("we need to check all values ");
            }
        }
    }
}
