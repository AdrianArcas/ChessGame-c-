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
    public partial class Form1 : Form
    {
        
        public static Form1 Instance;
        public Tabla Mytabla = new Tabla(); //cream o tabla cu celule de forma casuta
        public Button[,] btnTabla = new Button[Tabla.dimensiune, Tabla.dimensiune];//matrice de butoane
        public Casuta piesaPromo = new();


        Image reginan = Image.FromFile("ReginaN.png");
        Image nebunn = Image.FromFile("NebunN.png");
        Image caln = Image.FromFile("CalN.png");
        Image turan = Image.FromFile("TuraN.png");
        Image pionn = Image.FromFile("PionN.png");
        Image regen = Image.FromFile("RegeN.png");
        //de modificat
        Image snake_turan = Image.FromFile("WazirN.png");

        Image wazir = Image.FromFile("Wazir.png");
        Image wazirn = Image.FromFile("WazirN.png");

        Image fertz = Image.FromFile("Fertz.png");
        Image fertzn = Image.FromFile("FertzN.png");

        Image regina = Image.FromFile("Regina.png");
        Image nebun = Image.FromFile("Nebun.png");
        Image cal = Image.FromFile("Cal.png");
        Image tura = Image.FromFile("Tura.png");
        Image pion = Image.FromFile("Pion.png");
        Image rege = Image.FromFile("Rege.png");

        public bool Turn = true;
        int xAnte;
        int yAnte;

        public Form1()
        {
            Mytabla.PlasarePiese();
            InitializeComponent();
            PrintareButoane();
            Instance = this;

        }





        private void PrintareButoane()
        {

            int buttonSize = panel1.Width / Tabla.dimensiune;//dimensiune butoane
            panel1.Width = panel1.Height;

            for (int i = 0; i < Tabla.dimensiune; i++)
            {
                for (int j = 0; j < Tabla.dimensiune; j++)
                {
                    btnTabla[i, j] = new Button();
                    btnTabla[i, j].Height = buttonSize;
                    btnTabla[i, j].Width = buttonSize;


                    //event

                    btnTabla[i, j].Click += EventClick;

                    //adaugam butonul

                    panel1.Controls.Add(btnTabla[i, j]);

                    //plasam butonul

                    btnTabla[i, j].Location = new Point(i * buttonSize, j * buttonSize);

                    //plasam tag pentru buton

                    btnTabla[i, j].Tag = new Point(i, j);

                }

            }
            Coloreaza(btnTabla, Mytabla);

        }

        private void EventClick(object sender, EventArgs e)
        {

            Button ClickedButton = (Button)sender;
            Point location = (Point)ClickedButton.Tag;
            int x = location.X;
            int y = location.Y;
            Casuta Casutacurenta = Mytabla.TABLA[x, y];
            Piesa PiesaCurenta = Casutacurenta.GetPiesa();




            //Cazul 1: Dam click be o casuta care nu are nicio piesa si nu e miscare legala


            if (Casutacurenta.GetIsOcupat() == false && Casutacurenta.GetIsLegal() == false)
            {

                Mytabla.CuratareisLegal();


            }

            //Cazul 2: Dam click pe o casuta pe care e o piesa si nu e miscare legala

            if (Casutacurenta.GetIsOcupat() == true && Casutacurenta.GetIsLegal() == false)
            {

                if (PiesaCurenta.GetisAlb() == Turn)
                {

                    Mytabla.CuratareisLegal();
                    PiesaCurenta.MiscareLegala(x, y, Mytabla);
                    Mytabla.VerifLegal(Casutacurenta, Turn);

                    //Locada

                    if (Mytabla.TABLA[x, y].GetPiesa().Getnume() == "Rege" && !Mytabla.TABLA[x, y].GetPiesa().GetisMutat())

                    {

                        //Daca casuta din dreapta regelui e atacata nu se face locada

                        if (!Mytabla.TABLA[x + 1, y].GetIsLegal())
                            Mytabla.TABLA[x + 2, y].SetIsLegal(false);
                        if (!Mytabla.TABLA[x - 1, y].GetIsLegal())
                            Mytabla.TABLA[x - 2, y].SetIsLegal(false);

                        //Daca regele e in sah nu se face locada

                        if (Mytabla.checkSah(!Turn))
                        {

                            if (Mytabla.TABLA[x + 2, y].GetIsLegal())
                                Mytabla.TABLA[x + 2, y].SetIsLegal(false);
                            if (Mytabla.TABLA[x - 2, y].GetIsLegal())
                                Mytabla.TABLA[x - 2, y].SetIsLegal(false);
                        }


                    }
                    xAnte = x;
                    yAnte = y;
                }

                else
                {
                    Mytabla.CuratareisLegal();

                }


            }
            else

                //Cazul 3:  Dam click pe o casuta care este miscare legala(ulterior am dat click pe o piesa)

                if (Casutacurenta.GetIsLegal() == true)
            {

                if (Mytabla.TABLA[xAnte, yAnte].GetPiesa().Getnume() == "Rege")

                {//Conditie locada

                    if (!Mytabla.TABLA[xAnte, yAnte].GetPiesa().GetisMutat())
                    {
                        //Locada

                        if (!Mytabla.TABLA[xAnte + 1, yAnte].GetIsLegal())
                            Mytabla.TABLA[xAnte + 2, yAnte].SetIsLegal(false);

                        if (x - xAnte == 2)
                        {
                            Mytabla.TABLA[x - 1, y].SetPiesa(Mytabla.TABLA[x + 1, y].GetPiesa());
                            Mytabla.TABLA[x - 1, y].SetIsOcupat(true);

                            Mytabla.TABLA[x + 1, y].SetPiesa(null);
                            Mytabla.TABLA[x + 1, y].SetIsOcupat(false);

                        }

                        if (x - xAnte == -2)
                        {

                            Mytabla.TABLA[x + 1, y].SetPiesa(Mytabla.TABLA[x - 2, y].GetPiesa());
                            Mytabla.TABLA[x + 1, y].SetIsOcupat(true);

                            Mytabla.TABLA[x - 2, y].SetPiesa(null);
                            Mytabla.TABLA[x - 2, y].SetIsOcupat(false);

                        }
                    }

                    Mytabla.TABLA[xAnte, yAnte].GetPiesa().SetisMutat(true);

                }

                //Setam conditia de locada

                if (Mytabla.TABLA[xAnte, yAnte].GetPiesa().Getnume() == "Tura")
                {
                    Mytabla.TABLA[xAnte, yAnte].GetPiesa().SetisMutat(true);

                }




                //Mutare Piese

                Mytabla.CuratareisLegal();
                Casutacurenta.SetPiesa(Mytabla.TABLA[xAnte, yAnte].GetPiesa());
                Casutacurenta.SetIsOcupat(true);
                Mytabla.TABLA[xAnte, yAnte].SetPiesa(null);
                Mytabla.TABLA[xAnte, yAnte].SetIsOcupat(false);

                //Schimbam randul

                Turn = !Turn;



                //Conditie terminare joc



                if (Mytabla.SahMat(Turn))
                {
                    Coloreaza(btnTabla, Mytabla);
                    if (Mytabla.checkSah(!Turn))
                    {
                        if (!Turn)
                            MessageBox.Show("SAHMAT! ALB Castiga");
                        else MessageBox.Show("SAHMAT! NEGRU Castiga");
                    }
                    else MessageBox.Show("STALEMATE");
                    this.Close();
                }

                //Conditie Stalemate



                //Conditie promovare pion
                if (Mytabla.TABLA[x, y].GetPiesa().Getnume() == "Pion" && (y == Tabla.dimensiune-1 && !Mytabla.TABLA[x, y].GetPiesa().GetisAlb() || y == 0 && Mytabla.TABLA[x, y].GetPiesa().GetisAlb()))
                {


                    Form2 form = new Form2();
                    form.ShowDialog();
                    Mytabla.TABLA[x, y].SetPiesa(piesaPromo.GetPiesa());

                }

                Mytabla.CuratareisLegal();

            }

            Coloreaza(btnTabla, Mytabla);

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public void Coloreaza(Button[,] btnTabla, Tabla Mytabla)
        {
            for (int i = 0; i < Tabla.dimensiune; i++)
            {
                for (int j = 0; j < Tabla.dimensiune; j++)
                {
                    if ((j + i) % 2 == 1)
                        btnTabla[i, j].BackColor = Color.BurlyWood;
                    else
                        btnTabla[i, j].BackColor = Color.White;

                  
                    if (Mytabla.TABLA[i, j].GetIsLegal() == true)
                        btnTabla[i, j].BackColor = Color.Green;


                    if (Mytabla.TABLA[i, j].GetPiesa() != null)
                    {
                        if (Mytabla.TABLA[i, j].GetPiesa().GetisAlb() == true)
                        {
                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "Rege")
                                btnTabla[i, j].Image = rege;
                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "Pion")
                                btnTabla[i, j].Image = pion;
                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "Tura")
                                btnTabla[i, j].Image = tura;
                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "WazirCal")
                                btnTabla[i, j].Image = wazir;
                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "FertzCal")
                                btnTabla[i, j].Image = fertz;
                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "Regina")
                                btnTabla[i, j].Image = regina;
                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "Nebun")
                                btnTabla[i, j].Image = nebun;


                        }

                        else
                        {
                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "Rege")
                            {
                                btnTabla[i, j].Image = regen;

                            }
                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "Pion")
                                btnTabla[i, j].Image = pionn;

                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "Tura")
                                btnTabla[i, j].Image = turan;

                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "LoonySnakeTura")
                                btnTabla[i, j].Image = snake_turan;

                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "FertzCal")
                                btnTabla[i, j].Image = fertzn;

                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "WazirCal")
                                btnTabla[i, j].Image = wazirn;

                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "Regina")
                                btnTabla[i, j].Image = reginan;

                            if (Mytabla.TABLA[i, j].GetPiesa().Getnume() == "Nebun")
                                btnTabla[i, j].Image = nebunn;
                        }

                    }
                    else btnTabla[i, j].Image = null;
                }
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
