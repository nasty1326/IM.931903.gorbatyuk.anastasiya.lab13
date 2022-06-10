using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _931903.gorbatyuk.anastasiya.lab13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (firstIn == true)
            {
                doll = (double)numDoll.Value;
                euro = (double)numEuro.Value;

                chart1.Series[0].Points.Clear();
                chart1.Series[0].Points.AddXY(0, doll);
                chart1.Series[1].Points.Clear();
                chart1.Series[1].Points.AddXY(0, euro);

                firstIn = false;
            }
            timer1.Enabled = !timer1.Enabled;
        }


        const double mu = 0.2, s = 0.35;
        int d = 0;
        bool firstIn = true;
        Random rnd = new Random();
        double W1 = 0, W2 = 0;
        double normalRV1, normalRV2;
        double p1, p2;
        const double k = 0.1;
        double euro, doll;
        

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            d += 1;
            p1 = rnd.NextDouble();
            p2 = rnd.NextDouble();
            normalRV1 = Math.Sqrt((-2) * Math.Log(p1)) * Math.Sin(2 * Math.PI * p2);
            W1 = (double)(Math.Sqrt(k) * normalRV1 * 0.25);
            doll = doll * Math.Exp((mu - (double)((s * s) / 2)) * k * 0.25 + (double)(s * W1));
            normalRV2 = Math.Sqrt((-2) * Math.Log(p1)) * Math.Cos(2 * Math.PI * p2);
            W2 = (double)(Math.Sqrt(k) * normalRV2 * 0.25);
            euro = euro * Math.Exp((mu - (double)((s * s) / 2)) * k * 0.25 + (double)(s * W2));
            chart1.Series[0].Points.AddXY(d, doll);
            chart1.Series[1].Points.AddXY(d, euro);
        }
    }
}
