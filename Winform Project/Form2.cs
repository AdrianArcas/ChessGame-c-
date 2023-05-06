using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Project
{
    public partial class Form2 : Form
    {
        Image cal = Image.FromFile("CalF2.png");
        Image reginan = Image.FromFile("ReginaNF2.png");
        Image nebunn = Image.FromFile("NebunNF2.png");
        Image caln = Image.FromFile("CalNF2.png");
        Image turan = Image.FromFile("TuraNF2.png");
        Image regina = Image.FromFile("ReginaF2.png");
        Image nebun = Image.FromFile("NebunF2.png");
        Image tura = Image.FromFile("TuraF2.png");




        public Form2()
        {
            InitializeComponent();
            PrintareButoane();
        }


        private void PrintareButoane()
        {

            Button Regbut = new Button();
            Button Turabut = new Button();
            Button Nebunbut = new Button();
            Button Calbut = new Button();

            Regbut.Width = 200;
            Regbut.Height = 200;
            Regbut.Location = new Point(0, 0);
            Regbut.Click += Reg_Click;
            Controls.Add(Regbut);


            Turabut.Width = 200;
            Turabut.Height = 200;
            Turabut.Location = new Point(200, 0);
            Turabut.Click += Tura_Click;
            Controls.Add(Turabut);

            Nebunbut.Width = 200;
            Nebunbut.Height = 200;
            Nebunbut.Location = new Point(400, 0);
            Nebunbut.Click += Nebun_Click;
            Controls.Add(Nebunbut);


            Calbut.Width = 200;
            Calbut.Height = 200;
            Calbut.Location = new Point(600, 0);
            Calbut.Click += Cal_Click;
            Controls.Add(Calbut);


            if (!Form1.Instance.Turn)
            {
                Regbut.Image = regina;
                Turabut.Image = tura;
                Nebunbut.Image = nebun;
                Calbut.Image = cal;
            }
            else
            {
                Regbut.Image = reginan;
                Turabut.Image = turan;
                Nebunbut.Image = nebunn;
                Calbut.Image = caln;
            }



        }



        private void Tura_Click(object sender, EventArgs e)
        {
            Tura a = new(!Form1.Instance.Turn);
            Form1.Instance.piesaPromo.SetPiesa(a);
            this.Close();
        }

        private void Nebun_Click(object sender, EventArgs e)
        {
            Nebun a = new(!Form1.Instance.Turn);
            Form1.Instance.piesaPromo.SetPiesa(a);
            this.Close();
        }

        private void Cal_Click(object sender, EventArgs e)
        {
            FertzCal a = new(!Form1.Instance.Turn);
            Form1.Instance.piesaPromo.SetPiesa(a);
            this.Close();
        }

        private void Reg_Click(object sender, EventArgs e)
        {
            Regina a = new(!Form1.Instance.Turn);
            Form1.Instance.piesaPromo.SetPiesa(a);
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
