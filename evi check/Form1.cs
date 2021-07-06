using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace evi_check
{
    public partial class Form1 : Form
    {
        string evi1 = null;
        string evi2 = null;
        string evi3 = null;
        Dictionary<string, List<string>> ghostlist = new Dictionary<string, List<string>>();
        




        public Form1()
        {
            InitializeComponent();
            monsterlist();
            Show_output();
            
        }

        public Dictionary<string, List<string>> monsterlist()
            {

          //  Dictionary<string, Dictionary<string,string>> biglist = new Dictionary<string, Dictionary<string, string>>();
            Dictionary<string, List<string>> smalllist = new Dictionary<string, List<string>>();

            List<string> Banshee = new List<string> {"EMF5","FingerPrints","Cold" };
            List<string> Demon = new List<string> {"GhostWriting","SpiritBox","Cold" };
            List<string> Jinn = new List<string> {"EMF5","SpiritBox","GhostOrb" };
            List<string> Mare = new List<string> {"SpiritBox","Cold","GhostOrb" };
            List<string> Onie = new List<string> {"EMF5","GhostWriting","SpiritBox" };
            List<string> Phantom = new List<string> {"EMF5","Cold","GhostOrb" };
            List<string> Poltergeist = new List<string> {"FingerPrints","SpiritBox","GhostOrb" };
            List<string> Revenant = new List<string> {"EMF5","GhostWriting","FingerPrints" };
            List<string> Shade = new List<string> {"EMF5","GhostWriting","GhostOrb" };
            List<string> Spirit = new List<string> {"GhostWriting","FingerPrints","SpiritBox" };
            List<string> Wraith = new List<string> {"FingerPrints","SpiritBox","Cold"};
            List<string> Yurei = new List<string> {"GhostWriting","Cold","GhostOrb" };


            smalllist.Add("Banshee", Banshee);
            smalllist.Add("Demon", Demon);
            smalllist.Add("Jinn", Jinn);
            smalllist.Add("Mare", Mare);
            smalllist.Add("Onie", Onie);
            smalllist.Add("Phantom", Phantom);
            smalllist.Add("Poltergeist", Poltergeist);
            smalllist.Add("Revnant", Revenant);
            smalllist.Add("Shade", Shade);
            smalllist.Add("Spirit", Spirit);
            smalllist.Add("Wraith", Wraith);
            smalllist.Add("Yurei", Yurei);

            ghostlist = smalllist;
            return smalllist;
        }
        
        public void PosssibleOutcome()
        {
            bool nolist = false;
            this.listBox1.Items.Clear();
            List<string> possible = new List<string>();

            foreach(KeyValuePair<string, List<string>> entry in ghostlist)
            {


                if (entry.Value.Contains(evi1) && entry.Value.Contains(evi2))
                {

                    List<string> items = new List<string>(entry.Value);
                    items.Remove(evi1);
                    items.Remove(evi2);
              //      string nextstep = items.
                    string needed = entry.Key + " -- needs -- " + string.Join("",items);
                    possible.Add(needed);
                }

                if (entry.Value.Contains(evi1) && entry.Value.Contains(evi2) && entry.Value.Contains(evi3))
                {
                    nolist = true;
                    break;
                }
                else { 

                }
            }

            List<string> cleanfinal = possible.Distinct().ToList();


            if(nolist != true)
            {
                foreach (string monster in cleanfinal)
                {
                    this.listBox1.Items.Add(monster);
                }
            }

           // this.listBox1.Items.Add(cleanfinal.ToString());



        }

        public void Show_output()
        {
           List<string> evidance = new List<string>();

            string test1 = evi1;
            string test2 = evi2;
            string test3 = evi3;


            if(evi1 != null)
            {
                evidance.Add(evi1);
            }
            if (evi2 != null)
            {
                evidance.Add(evi2);
            }
            if (evi3 != null)
            {
                evidance.Add(evi3);
            }

            PosssibleOutcome();

            if(evidance.Count() == 3)
            {
                if (evidance.Contains("EMF5") && (evidance.Contains("FingerPrints") && (evidance.Contains("Cold"))))
                {
                    this.output.Text = "Banshee";

                }  else if ((evidance.Contains("GhostWriting")) && (evidance.Contains("SpiritBox") && (evidance.Contains("Cold"))))
                {
                    this.output.Text = "Demon";
                }

                else if ((evidance.Contains("EMF5")) && (evidance.Contains("SpiritBox") && (evidance.Contains("GhostOrb"))))
                {
                    this.output.Text = "Jinn";
                }

                else if ((evidance.Contains("SpiritBox")) && (evidance.Contains("Cold") && (evidance.Contains("GhostOrb"))))
                {
                    this.output.Text = "Mare";
                }

                else if ((evidance.Contains("EMF5")) && (evidance.Contains("GhostWriting") && (evidance.Contains("SpiritBox"))))
                {
                    this.output.Text = "oni";
                }

                else if ((evidance.Contains("EMF5")) && (evidance.Contains("Cold") && (evidance.Contains("GhostOrb"))))
                {
                    this.output.Text = "phantom";
                }

                else if ((evidance.Contains("FingerPrints")) && (evidance.Contains("SpiritBox") && (evidance.Contains("GhostOrb"))))
                {
                    this.output.Text = "poltergeist";
                }

                else if ((evidance.Contains("EMF5")) && (evidance.Contains("GhostWriting") && (evidance.Contains("FingerPrints"))))
                {
                    this.output.Text = "revenant";
                }

                else if ((evidance.Contains("EMF5")) && (evidance.Contains("GhostWriting") && (evidance.Contains("GhostOrb"))))
                {
                    this.output.Text = "shade";
                }

                else if ((evidance.Contains("GhostWriting")) && (evidance.Contains("FingerPrints") && (evidance.Contains("SpiritBox"))))
                {
                    this.output.Text = "spirit";
                }

                else if ((evidance.Contains("FingerPrints")) && (evidance.Contains("SpiritBox") && (evidance.Contains("Cold"))))
                {
                    this.output.Text = "wraith";
                }

                else if ((evidance.Contains("GhostWriting")) && (evidance.Contains("Cold") && (evidance.Contains("GhostOrb"))))
                {
                    this.output.Text = "yurei";
                }
                else
                {
                    this.output.Text = "Need more evidance";
                }
            }
            else
            {
                this.output.Text = "Need more evidence";
            }
        }

        public void Resetevibutton(string pressed, int group)
        {
            string[] buttonarray = { "Cold", "GhostOrb", "EMF5", "GhostWriting", "FingerPrints", "SpiritBox" };
            List<string> buttonlist = new List<string>(buttonarray);
            buttonlist.Remove(pressed);

            string[] removechecked = buttonlist.ToArray();

            foreach (string button in removechecked)
            {
                    switch (button)
                    {
                    case "Cold":
                        if(group == 1)
                        {
                            this.Evi1Cold.Checked = false;
                        }else if (group == 2)
                        {
                            this.Evi2Cold.Checked = false;
                        }else if (group == 3)
                        {
                            this.Evi3Cold.Checked = false;
                        }
                        
                        break;

                    case "GhostOrb":
                        if (group == 1)
                        {
                            this.Evi1GhostOrb.Checked = false;
                        }
                        else if (group == 2)
                        {
                            this.Evi2GhostOrb.Checked = false;
                        }
                        else if (group == 3)
                        {
                            this.Evi3GhostOrb.Checked = false;
                        }
                        break;

                    case "EMF5":
                        if (group == 1)
                        {
                            this.Evi1EMF5.Checked = false;
                        }
                        else if (group == 2)
                        {
                            this.Evi2EMF5.Checked = false;
                        }
                        else if (group == 3)
                        {
                            this.Evi3EMF5.Checked = false;
                        }
                        break;

                    case "GhostWriting":
                        if (group == 1)
                        {
                            this.Evi1GhostWriting.Checked = false;
                        }
                        else if (group == 2)
                        {
                            this.Evi2GhostWriting.Checked = false;
                        }
                        else if (group == 3)
                        {
                            this.Evi3GhostWriting.Checked = false;
                        }
                        break;

                    case "FingerPrints":
                        if (group == 1)
                        {
                            this.Evi1FingerPrints.Checked = false;
                        }
                        else if (group == 2)
                        {
                            this.Evi2FingerPrints.Checked = false;
                        }
                        else if (group == 3)
                        {
                            this.Evi3FingerPrints.Checked = false;
                        }
                        break;

                    case "SpiritBox":
                        if (group == 1)
                        {
                            this.Evi1SpiritBox.Checked = false;
                        }
                        else if (group == 2)
                        {
                            this.Evi2SpiritBox.Checked = false;
                        }
                        else if (group == 3)
                        {
                            this.Evi3SpiritBox.Checked = false;
                        }
                       // this.Evi1SpiritBox.Checked = false;
                        break;
                }
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Evi1Cold_click(object sender, EventArgs e)
        {

            if (this.Evi1Cold.Checked == true)
            {
                evi1 = null;
                Resetevibutton("", 1);
            }
            else
            {
                evi1 = "Cold";
                Resetevibutton("Cold", 1);
                this.Evi1Cold.Checked = true;
                // Show_output();
            }
            Show_output();
        }
      
        private void Evi1GhostOrb_click(object sender, EventArgs e)
        {
            if (this.Evi1GhostOrb.Checked == false)
            {
                evi1 = "GhostOrb";
                Resetevibutton("GhostOrb", 1);
                this.Evi1GhostOrb.Checked = true;
                // Show_output();
            }
            else
            {
                evi1 = null;
                Resetevibutton("", 1);
            }
            Show_output();
        }

        private void Evi1GhostWriting_click(object sender, EventArgs e)
        {
            if (this.Evi1GhostWriting.Checked == false)
            {
                evi1 = "GhostWriting";
                Resetevibutton("GhostWriting", 1);
                this.Evi1GhostWriting.Checked = true;
                // Show_output();
            }
            else
            {
                evi1 = null;
                Resetevibutton("", 1);

            }
            Show_output();
        }

        private void Evi1EMF5_click(object sender, EventArgs e)
        {
            if (this.Evi1EMF5.Checked == false)
            {
                evi1 = "EMF5";
                Resetevibutton("EMF5", 1);
                this.Evi1EMF5.Checked = true;
                // Show_output();
            }
            else
            {
                evi1 = null;
                Resetevibutton("", 1);
            }
            Show_output();
        }

        private void Evi1SpiritBox_click(object sender, EventArgs e)
        {
            if (this.Evi1SpiritBox.Checked == false)
            {
                evi1 = "SpiritBox";
                Resetevibutton("SpiritBox", 1);
                this.Evi1SpiritBox.Checked = true;
                // Show_output();
            }
            else
            {
                evi1 = null;
                Resetevibutton("", 1);
            }
            Show_output();
        }

        private void Evi1FingerPrints_click(object sender, EventArgs e)
        {
            if (this.Evi1FingerPrints.Checked == false)
            {
                evi1 = "FingerPrints";
                Resetevibutton("FingerPrints", 1);
                this.Evi1FingerPrints.Checked = true;
                // Show_output();
            }
            else
            {
                evi1 = null;
                Resetevibutton("", 1);
            }
            Show_output();
        }

        private void Evi2Cold_click(object sender, EventArgs e)
        {
            if (this.Evi2Cold.Checked == false)
            {
                evi2 = "Cold";
                Resetevibutton("Cold", 2);
                this.Evi2Cold.Checked = true;
                // Show_output();
            }
            else
            {
                evi2 = null;
                Resetevibutton("", 2);
            }
            Show_output();
        }

        private void Evi2GhostOrb_click(object sender, EventArgs e)
        {
            if (this.Evi2GhostOrb.Checked == false)
            {
                evi2 = "GhostOrb";
                Resetevibutton("GhostOrb", 2);
                this.Evi2GhostOrb.Checked = true;
                // Show_output();
            }
            else
            {
                evi2 = null;
                Resetevibutton("", 2);
            }
            Show_output();
        }

        private void Evi2GhostWriting_click(object sender, EventArgs e)
        {
            if (this.Evi2GhostWriting.Checked == false)
            {
                evi2 = "GhostWriting";
                Resetevibutton("GhostWriting", 2);
                this.Evi2GhostWriting.Checked = true;
                // Show_output();
            }
            else
            {
                evi2 = null;
                Resetevibutton("", 2);
            }
            Show_output();
        }

        private void Evi2EMF5_click(object sender, EventArgs e)
        {
            if (this.Evi2EMF5.Checked == false)
            {
                evi2 = "EMF5";
                Resetevibutton("EMF5", 2);
                this.Evi2EMF5.Checked = true;
                // Show_output();
            }
            else
            {
                evi2 = null;
                Resetevibutton("", 2);
            }
            Show_output();
        }

        private void Evi2SpiritBox_click(object sender, EventArgs e)
        {
            if (this.Evi2SpiritBox.Checked == false)
            {
                evi2 = "SpiritBox";
                Resetevibutton("SpiritBox", 2);
                this.Evi2SpiritBox.Checked = true;
                // Show_output();
            }
            else
            {
                evi2 = null;
                Resetevibutton("", 2);
            }
            Show_output();
        }

        private void Evi2FingerPrints_click(object sender, EventArgs e)
        {
            if (this.Evi2FingerPrints.Checked == false)
            {
                evi2 = "FingerPrints";
                Resetevibutton("FingerPrints", 2);
                this.Evi2FingerPrints.Checked = true;
                // Show_output();
            }
            else
            {
                evi2 = null;
                Resetevibutton("", 2);
            }
            Show_output();
        }

        private void Evi3Cold_click(object sender, EventArgs e)
        {
            if (this.Evi3Cold.Checked == false)
            {
                evi3 = "Cold";
                Resetevibutton("Cold", 3);
                this.Evi3Cold.Checked = true;
                // Show_output();
            }
            else
            {
                evi3 = null;
                Resetevibutton("", 3);
            }
            Show_output();
        }

        private void Evi3GhostOrb_click(object sender, EventArgs e)
        {
            if (this.Evi3GhostOrb.Checked == false)
            {
                evi3 = "GhostOrb";
                Resetevibutton("GhostOrb", 3);
                this.Evi3GhostOrb.Checked = true;
                // Show_output();
            }
            else
            {
                evi3 = null;
                Resetevibutton("", 3);
            }
            Show_output();
        }

        private void Evi3GhostWriting_click(object sender, EventArgs e)
        {
            if (this.Evi3GhostWriting.Checked == false)
            {
                evi3 = "GhostWriting";
                Resetevibutton("GhostWriting", 3);
                this.Evi3GhostWriting.Checked = true;
                // Show_output();
            }
            else
            {
                evi3 = null;
                Resetevibutton("", 3);
            }
            Show_output();
        }

        private void Evi3EMF5_click(object sender, EventArgs e)
        {
            if (this.Evi3EMF5.Checked == false)
            {
                evi3 = "EMF5";
                Resetevibutton("EMF5", 3);
                this.Evi3EMF5.Checked = true;
                // Show_output();
            }
            else
            {
                evi3 = null;
                Resetevibutton("", 3);
            }
            Show_output();
        }

        private void Evi3SpiritBox_click(object sender, EventArgs e)
        {
            if (this.Evi3SpiritBox.Checked == false)
            {
                evi3 = "SpiritBox";
                Resetevibutton("SpiritBox", 3);
                this.Evi3SpiritBox.Checked = true;
                // Show_output();
            }
            else
            {
                evi3 = null;
                Resetevibutton("", 3);
            }
            Show_output();
        }

        private void Evi3FingerPrints_click(object sender, EventArgs e)
        {
            if (this.Evi3FingerPrints.Checked == false)
            {
                evi3 = "FingerPrints";
                Resetevibutton("FingerPrints", 3);
                this.Evi3FingerPrints.Checked = true;
                // Show_output();
            }
            else
            {
                evi3 = null;
                Resetevibutton("", 3);
            }
            Show_output();
        }

        private void resetoption_Click(object sender, EventArgs e)
        {
            Resetevibutton("", 1);
            Resetevibutton("", 2);
            Resetevibutton("", 3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 questions = new Form2();

            questions.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
