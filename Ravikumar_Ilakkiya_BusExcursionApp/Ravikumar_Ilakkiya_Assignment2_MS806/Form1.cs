using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ravikumar_Ilakkiya_Assignment2_MS806
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(Nextbtn, "Press to continue");
            toolTip1.SetToolTip(Previous1btn, "Press to go back");
            toolTip1.SetToolTip(Displaybtn, "Press to display the trip Itinerary");
            toolTip1.SetToolTip(Previous2btn, "Press to go back");
            toolTip1.SetToolTip(Bookbtn, "Press to Book");
            toolTip1.SetToolTip(Summarybtn, "Press to view the company summary");
            toolTip1.SetToolTip(Clearbtn, "Press to clear form for next user");
            toolTip1.SetToolTip(Exitbtn, "Press to Exit Application");
        }

        private void Locationcombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Locationcombobox.Text == "Cliffs of Moher")
            {
                Pricetaglabel.Text = "55";
            }
            if (Locationcombobox.Text == "Kylemore Abbey")
            {
                Pricetaglabel.Text = "50";
            }
            if (Locationcombobox.Text == "Bunratty Castle")
            {
                Pricetaglabel.Text = "75";
            }
            if (Locationcombobox.Text == "The Burren")
            {
                Pricetaglabel.Text = "45";
            }
            if (Locationcombobox.Text == "Connemara")
            {
                Pricetaglabel.Text = "75";
            }
            if (Locationcombobox.Text == "Belmullet")
            {
                Pricetaglabel.Text = "99";
            }
            taglabel.Visible = true;
            Pricetaglabel.Visible = true;
            Guesttxtbox.Focus();
            Guesttxtbox.SelectAll();
            
        }
        
        private void Nextbtn_Click_1(object sender, EventArgs e)
        {
            this.Text = "Add-ons";
            Detailspanel.Visible = false;
            Additionalpanel.Visible = true;
            Introductionpanel.Visible = false;
            int Numberguest;
            try
            {
                Numberguest = int.Parse(Guesttxtbox.Text);
                try
                {
                    dateTimePicker1.MinDate = DateTime.Now;
                    if (Locationcombobox.Text == "" | Guesttxtbox.Text == "0"| Nametxtbox.Text == "")
                    {
                        Additionalpanel.Visible = false;
                        MessageBox.Show("Please enter the Required Fields", "Oops!!");
                        Locationcombobox.Focus();
                        Locationcombobox.SelectAll();
                        Introductionpanel.Visible = true;
                    }
                }
                catch
                {
                    Additionalpanel.Visible = true;
                    Nextbtn.Enabled = true;
                }               
            }
            catch
            {
                Additionalpanel.Visible = false;
                MessageBox.Show("Please enter Numerical Value for No. of Guest/s", "Error");
                Introductionpanel.Visible = true;
                Guesttxtbox.Focus();
                Guesttxtbox.SelectAll();
            } 
        }
        private void Previous1btn_Click(object sender, EventArgs e)
        {
            this.Text = "Mild Atlantic Bus Tours";
            Additionalpanel.Visible = false;
            Introductionpanel.Visible = true;
            Detailspanel.Visible = false;
            Guesttxtbox.Focus();
            Guesttxtbox.SelectAll();
        }
        decimal discount;
        string discountstr;
        decimal addon;
        string addonstr;
        decimal price;
        decimal guest;
        decimal total;
        
        private void Displaybtn_Click(object sender, EventArgs e)
        {
            this.Text = "Trip Details";
            Introductionpanel.Visible = false;
            Detailspanel.Visible = true;
            Additionalpanel.Visible = false;
            string location = Locationcombobox.Text;
            string name= Nametxtbox.Text;
            if(Initialcombobox.Text == "Mr.")
            {
                Detailnamelabel.Text = "Mr." + name;
            }
            else
            {
                Detailnamelabel.Text = "Ms." + name;
            }
            Detaillocationdisplaylabel.Text = location;
            Detailguestdisplaylabel.Text = Guesttxtbox.Text;
            Detaildatedisplaylabel.Text = dateTimePicker1.Value.ToString();
            guest = decimal.Parse(Guesttxtbox.Text);
            price = decimal.Parse(Pricetaglabel.Text);
            decimal cost = price * guest;
            try
            {
                if (Time1rbtn.Checked)
                {
                    Detailtimedisplaylabel.Text = "07:00 AM";
                    discount = (cost - (cost * Convert.ToDecimal(0.2)));
                }
                if (Time2rbtn.Checked)
                {
                    Detailtimedisplaylabel.Text = "08:00 AM";
                    discount = (cost - (cost * Convert.ToDecimal(0.1)));
                }
                if (Time3rbtn.Checked)
                {
                    Detailtimedisplaylabel.Text = "09:00 AM";
                    discount = (cost - (cost * Convert.ToDecimal(0.05)));
                }
                if (Time4rbtn.Checked)
                {
                    Detailtimedisplaylabel.Text = "10:00 AM";
                    discount = cost;
                }
                if (Time5rbtn.Checked)
                {
                    Detailtimedisplaylabel.Text = "11:00 AM";
                    discount = cost;
                }
                if (Time6rbtn.Checked)
                {
                    Detailtimedisplaylabel.Text = "01:00 PM";
                    discount = (cost - (cost * Convert.ToDecimal(0.25)));
                }
            }
            catch
            {
                
            }
            discountstr = Convert.ToString(discount);
            Detailtripcostdisplaylabel.Text = "€" + discountstr;
            if (Hotel1rbtn.Checked)
            {
                Detailhotelcheckbox.Text = " Stay in 3 Star Hotel";
                addon = 55 * guest;
            }
           else if (Hotel2rbtn.Checked)
            {
                Detailhotelcheckbox.Text = " Stay in 4 Star Hotel";
                addon = 75 * guest;
            }
           else if (Hotel3rbtn.Checked)
            {
                Detailhotelcheckbox.Text = " Stay in 5 Star Hotel";
                addon = 100 * guest;
            }
           else 
            {
                Detailhotelcheckbox.Checked = false;
                Detailhotelcheckbox.Text = " Hotel Stay is not Reserved";
                addon = 0;
            }
        if(Lunchcheckbox.Checked==true)
            {
                addon += (guest * Convert.ToDecimal(11.50));
                Detaillunchcheckbox.Checked = true;
            }
        else
            {
                Detaillunchcheckbox.Checked = false;
            }
            addonstr = Convert.ToString(addon);
            Detailaddcostdisplaylabel.Text = "€" + addonstr;

            if (guest >=3 && Lunchcheckbox.Checked && (Hotel1rbtn.Checked | Hotel2rbtn.Checked | Hotel3rbtn.Checked))
            {
                total = (addon + discount) - ((addon + discount) * (Convert.ToDecimal(0.075)));
                total = Math.Round(total,2);
                Detailtotaldisplaylabel.Text = "€" + Convert.ToString(total);
                Discountinfolabel.Visible = true;
            }
            else
            {
                Detailtotaldisplaylabel.Text = "€" + Convert.ToString(addon + discount);
                Discountinfolabel.Visible = false;
            }
            Bookbtn.Focus();
        }

        private void Previous2btn_Click(object sender, EventArgs e)
        {
            this.Text = "Add-ons";
            Detailspanel.Visible = false;
            Additionalpanel.Visible = true;
            Introductionpanel.Visible = false;
        }
        Int32 clicks;
        private void Bookbtn_Click(object sender, EventArgs e)
        {
            clicks++;
            StringBuilder MessageText = new StringBuilder();
            MessageText.AppendLine(string.Format("Are you Sure to Proceed Further?"));
            MessageText.AppendLine(string.Format("\nName of Guest\t\t {0}", Detailnamelabel.Text));
            MessageText.AppendLine(string.Format("Number of Guests\t\t {0}", Guesttxtbox.Text));
            MessageText.AppendLine(string.Format("Destination Location\t {0}", Locationcombobox.Text));
            MessageText.AppendLine(string.Format("Departure Time\t\t {0}", Detailtimedisplaylabel.Text));
            MessageText.AppendLine(string.Format("Hotel Stay\t\t {0}", Detailhotelcheckbox.Text));
            MessageText.AppendLine(string.Format("Total Trip Cost\t\t {0}", Detailtotaldisplaylabel.Text));
            if ( MessageBox.Show(MessageText.ToString(),"Booking Confirmation",MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
                this.Text = "Booking Confirmed!";
                MessageBox.Show("Successful !!\nYour Booking has been Confirmed..","Success");
                Successpanel.Visible = true;
                Detailspanel.Visible = false;
                Summarybtn.Focus();
            }
            else
            {
                
            }
        }
        decimal totaltripfees;
        decimal totaladdons;

        private void Summarybtn_Click(object sender, EventArgs e)
        {
            decimal averagerevenue;
            try
            {
                Detailspanel.Visible = false;
                this.Text = "Mild Atlantic Bus Tour Summary Data";
                Transactiondisplaylabel.Text = Convert.ToString(clicks);
                string tripfeestr = Detailtotaldisplaylabel.Text.Substring(1);
                decimal tripfee = decimal.Parse(tripfeestr);
                totaltripfees += tripfee;
                Math.Round(totaltripfees, 2);
                Totaltripfeesdisplaylabel.Text = "€" + totaltripfees.ToString();
                totaladdons += addon;
                Math.Round(totaladdons, 2);
                Valueoptionsdisplaylabel.Text = "€" + totaladdons.ToString();
                averagerevenue = totaltripfees / clicks;
                Math.Round(averagerevenue, 2);
                Averagerevenuedisplaylabel.Text = "€" + averagerevenue.ToString();
            }
            catch(DivideByZeroException t)
            {
                Console.WriteLine("Exception caught: {0}", t);
                MessageBox.Show("Sorry No Transactions were made", "Error");
            }
        }

        private void Clearbtn_Click(object sender, EventArgs e)
        {
            Introductionpanel.Visible = true;
            this.Text = "Mild Atlantic Bus Tours";
            Locationcombobox.Focus();
            Locationcombobox.SelectAll();
            Nametxtbox.Clear();
            Initialcombobox.SelectedIndex = -1;
            Guesttxtbox.Text="1";
            Locationcombobox.SelectedIndex = -1;
            Time4rbtn.Checked=true;
            taglabel.Visible = false;
            Pricetaglabel.Visible = false;
            Hotel1rbtn.Checked = false;
            Hotel2rbtn.Checked = false;
            Hotel3rbtn.Checked = false;
            Hotel4rbtn.Checked = true;
            Lunchcheckbox.Checked = false;
            Transactiondisplaylabel.Clear();
            Totaltripfeesdisplaylabel.Clear();
            Valueoptionsdisplaylabel.Clear();
            Averagerevenuedisplaylabel.Clear();
            Successpanel.Visible = false;
            Discountinfolabel.Visible = false;
        }
        private void Exitbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
   
}
