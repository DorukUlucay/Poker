using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormUI
{
    public partial class HandCalculator : Form
    {
        public HandCalculator()
        {
            InitializeComponent();
        }

        private void HandCalculator_Load(object sender, EventArgs e)
        {


            foreach (Poker.Suites item in Enum.GetValues(typeof(Poker.Suites)))
            {
                for (int i = 1; i < 14; i++)
                {
                    string Value = string.Empty;

                    //switch (i)
                    //{
                    //    case 1: Value = "Ace"; break;
                    //    case 2: Value = "Deuce"; break;
                    //    case 3: Value = "Three"; break;
                    //    case 4: Value = "Four"; break;
                    //    case 5: Value = "Five"; break;
                    //    case 6: Value = "Six"; break;
                    //    case 7: Value = "Seven"; break;
                    //    case 8: Value = "Eight"; break;
                    //    case 9: Value = "Nine"; break;
                    //    case 10: Value = "Ten"; break;
                    //    case 11: Value = "Jack"; break;
                    //    case 12: Value = "Queen"; break;
                    //    case 13: Value = "King"; break;
                    //}

                    foreach (Control control in this.Controls)
                    {
                        if (control is ComboBox)
                        {

                            (control as ComboBox).Items.Add(string.Format("{0} of {1}", i, item.ToString()));
                            
                        }
                    }
                }
            }
        }
                       
                       

        private void button1_Click(object sender, EventArgs e)
        {
            string Hand = string.Empty;
            foreach (Control control in this.Controls)
            {
                if (control is ComboBox)
                {
                    var itemx = (control as ComboBox).SelectedItem.ToString().Split(new string[] { " of " }, StringSplitOptions.None);

                    int val = int.Parse(itemx[0]);
                    string value = string.Empty;

                    switch (val)
                    {
                        case 1: value = "A"; break;
                        case 13: value = "K"; break;
                        case 12: value = "Q"; break;
                        case 11: value = "J"; break;
                        case 10: value = "0"; break;
                        default: value = val.ToString(); break;
                    }


                    Hand += itemx[1].Substring(0, 1) + value;
                }
            }

            Poker.HandCalculator Calc = new Poker.HandCalculator(false);
            Poker.CalculatedHand C = Calc.CalculateHand(Hand);

            label1.Text = C.Rank.ToString();
        }
    }
}