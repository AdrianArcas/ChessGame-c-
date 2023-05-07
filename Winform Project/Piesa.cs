using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_Project
{
    public class Piesa
    {
        protected string nume;
        protected bool isAlb;
        protected bool isMutat;
        public bool GetisMutat()
        {
            return isMutat;
        }

        public void SetisMutat(bool isMutat)
        {
            this.isMutat = isMutat;
        }

        public string Getnume()
        {
            return nume;
        }

        public bool GetisAlb()
        {
            return isAlb;
        }

        public void SetisAlb(bool value)
        {
            isAlb = value;
        }

        public Piesa(bool isAlb = false, string nume = "0")
        {

            this.SetisAlb(isAlb);

        }


        public virtual void MiscareLegala(int x, int y, Tabla TABLA, bool f1 = false)
        {

        }

        public void SetiingisAtacked(int x, int y, Tabla TABLA)
        {
            MiscareLegala(x, y, TABLA, true);


        }


    }




    class Pion : Piesa
    {
        public Pion(bool isAlb)
        {
            this.nume = "Pion";
            this.SetisAlb(isAlb);
        }


        //Marcheaza Casutele in care piesa se poate muta

        public override void MiscareLegala(int x, int y, Tabla TablaMea, bool f1 = false)

        {
            int i;
            bool Culoare_Curenta;

            Culoare_Curenta = TablaMea.TABLA[x, y].GetPiesa().GetisAlb();
            if (Culoare_Curenta == false)
                i = 1;
            else i = -1;
            //Verif daca casuta din fata dreapta a pionului este ocupata iar daca este verificam daca culoarea piesei curente este diferita de ea

            if (!(y + 2 * i > Tabla.dimensiune - 1 || y + 2 * i < 0))
                if ((y == Tabla.dimensiune-2 || y == 1) && TablaMea.TABLA[x, y + i].GetIsOcupat() == false && TablaMea.TABLA[x, y + 2 * i].GetIsOcupat() == false)
                {
                    if (!f1)
                        TablaMea.TABLA[x, y + 2 * i].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x, y + 2 * i].SetisAtacat(true);

                }


            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0 || y + i > Tabla.dimensiune - 1 || y + i < 0))
                if (TablaMea.TABLA[x + 1, y + i].GetIsOcupat() && TablaMea.TABLA[x + 1, y + i].GetPiesa().GetisAlb() != Culoare_Curenta)
                {
                    if (!f1)
                        TablaMea.TABLA[x + 1, y + i].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 1, y + i].SetisAtacat(true);
                }


            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0 || y + i > Tabla.dimensiune - 1 || y + i < 0))
                if (TablaMea.TABLA[x - 1, y + i].GetIsOcupat())
                    if (TablaMea.TABLA[x - 1, y + i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x - 1, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - 1, y + i].SetisAtacat(true);
                    }


            if (!(y + i > Tabla.dimensiune - 1 || y + i < 0))
                if (!TablaMea.TABLA[x, y + i].GetIsOcupat())
                {
                    if (!f1)
                        TablaMea.TABLA[x, y + i].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x, y + i].SetisAtacat(true);
                }



        }
    }


    class Regina : Piesa
    {
        public Regina(bool isAlb)
        {
            this.nume = "Regina";
            this.SetisAlb(isAlb);
        }
        public override void MiscareLegala(int x, int y, Tabla TablaMea, bool f1 = false)
        {
            bool Culoare_Curenta;

            Culoare_Curenta = TablaMea.TABLA[x, y].GetPiesa().GetisAlb();


            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x + i > Tabla.dimensiune - 1 || x + i < 0 || y + i > Tabla.dimensiune - 1 || y + i < 0))
                {
                    if (!TablaMea.TABLA[x + i, y + i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y + i].SetisAtacat(true);
                    }

                    else
                    if (TablaMea.TABLA[x + i, y + i].GetIsOcupat() && TablaMea.TABLA[x + i, y + i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y + i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }



            /////////////////

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x - i > Tabla.dimensiune - 1 || x - i < 0 || y - i > Tabla.dimensiune - 1 || y - i < 0))
                {
                    if (!TablaMea.TABLA[x - i, y - i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y - i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x - i, y - i].GetIsOcupat() && TablaMea.TABLA[x - i, y - i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y - i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }


            ///////////////////

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x - i > Tabla.dimensiune - 1 || x - i < 0 || y + i > Tabla.dimensiune - 1 || y + i < 0))
                {
                    if (!TablaMea.TABLA[x - i, y + i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y + i].SetIsLegal(true);
                        else TablaMea.TABLA[x - i, y + i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x - i, y + i].GetIsOcupat() && TablaMea.TABLA[x - i, y + i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y + i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }

            /////////////////////

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x + i > Tabla.dimensiune - 1 || x + i < 0 || y - i > Tabla.dimensiune - 1 || y - i < 0))
                {
                    if (!TablaMea.TABLA[x + i, y - i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y - i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x + i, y - i].GetIsOcupat() && TablaMea.TABLA[x + i, y - i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y - i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }


            /////////////////////////////////
            /////////////////////////////////


            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x + i > Tabla.dimensiune - 1 || x + i < 0))
                {
                    if (!TablaMea.TABLA[x + i, y].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x + i, y].GetIsOcupat() && TablaMea.TABLA[x + i, y].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }
            ////////////
            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x - i > Tabla.dimensiune - 1 || x - i < 0))
                {
                    if (!TablaMea.TABLA[x - i, y].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x - i, y].GetIsOcupat() && TablaMea.TABLA[x - i, y].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }
            ///////////////////
            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(y + i > Tabla.dimensiune - 1 || y + i < 0))
                {
                    if (!TablaMea.TABLA[x, y + i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x, y + i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x, y + i].GetIsOcupat() && TablaMea.TABLA[x, y + i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x, y + i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }
            /////////////////////

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(y - i > Tabla.dimensiune - 1 || y - i < 0))
                {
                    if (!TablaMea.TABLA[x, y - i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x, y - i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x, y - i].GetIsOcupat() && TablaMea.TABLA[x, y - i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x, y - i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }


        }


    }

    class Nebun : Piesa
    {
        public Nebun(bool isAlb)
        {
            this.nume = "Nebun";
            this.SetisAlb(isAlb);
        }
        public override void MiscareLegala(int x, int y, Tabla TablaMea, bool f1 = false)
        {
            bool Culoare_Curenta;

            Culoare_Curenta = TablaMea.TABLA[x, y].GetPiesa().GetisAlb();

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x + i > Tabla.dimensiune - 1 || x + i < 0 || y + i > Tabla.dimensiune - 1 || y + i < 0))
                {
                    if (!TablaMea.TABLA[x + i, y + i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y + i].SetisAtacat(true);
                    }

                    else
                    if (TablaMea.TABLA[x + i, y + i].GetIsOcupat() && TablaMea.TABLA[x + i, y + i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y + i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }



            /////////////////

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x - i > Tabla.dimensiune - 1 || x - i < 0 || y - i > Tabla.dimensiune - 1 || y - i < 0))
                {
                    if (!TablaMea.TABLA[x - i, y - i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y - i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x - i, y - i].GetIsOcupat() && TablaMea.TABLA[x - i, y - i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y - i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }


            ///////////////////

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x - i > Tabla.dimensiune - 1 || x - i < 0 || y + i > Tabla.dimensiune - 1 || y + i < 0))
                {
                    if (!TablaMea.TABLA[x - i, y + i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y + i].SetIsLegal(true);
                        else TablaMea.TABLA[x - i, y + i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x - i, y + i].GetIsOcupat() && TablaMea.TABLA[x - i, y + i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y + i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }

            /////////////////////

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x + i > Tabla.dimensiune - 1 || x + i < 0 || y - i > Tabla.dimensiune - 1 || y - i < 0))
                {
                    if (!TablaMea.TABLA[x + i, y - i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y - i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x + i, y - i].GetIsOcupat() && TablaMea.TABLA[x + i, y - i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y - i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }





        }
    }





    class Tura : Piesa
    {


        public Tura(bool isAlb)
        {
            this.nume = "Tura";
            this.SetisAlb(isAlb);
        }
        public override void MiscareLegala(int x, int y, Tabla TablaMea, bool f1 = false)
        {

            bool Culoare_Curenta;

            Culoare_Curenta = TablaMea.TABLA[x, y].GetPiesa().GetisAlb();

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x + i > Tabla.dimensiune - 1 || x + i < 0))
                {
                    if (!TablaMea.TABLA[x + i, y].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x + i, y].GetIsOcupat() && TablaMea.TABLA[x + i, y].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y].SetisAtacat(true);

                        break;
                    }
                    else break;
                }
                else break;
            }
            ////////////
            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x - i > Tabla.dimensiune - 1 || x - i < 0))
                {
                    if (!TablaMea.TABLA[x - i, y].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x - i, y].GetIsOcupat() && TablaMea.TABLA[x - i, y].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }
            ///////////////////
            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(y + i > Tabla.dimensiune - 1 || y + i < 0))
                {
                    if (!TablaMea.TABLA[x, y + i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x, y + i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x, y + i].GetIsOcupat() && TablaMea.TABLA[x, y + i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x, y + i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }
            /////////////////////

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(y - i > Tabla.dimensiune - 1 || y - i < 0))
                {
                    if (!TablaMea.TABLA[x, y - i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x, y - i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x, y - i].GetIsOcupat() && TablaMea.TABLA[x, y - i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x, y - i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }





        }
    }



    class Rege : Piesa
    {



        public Rege(bool isAlb, bool isMutat = false)
        {
            this.nume = "Rege";
            this.SetisAlb(isAlb);
        }

        public override void MiscareLegala(int x, int y, Tabla TablaMea, bool f1 = false)
        {

            bool Culoare_Curenta;

            Culoare_Curenta = TablaMea.TABLA[x, y].GetPiesa().GetisAlb();


            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0 || y + 1 > Tabla.dimensiune - 1 || y + 1 < 0))
                if (!TablaMea.TABLA[x + 1, y + 1].GetIsOcupat() || (TablaMea.TABLA[x + 1, y + 1].GetIsOcupat() && TablaMea.TABLA[x + 1, y + 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 1, y + 1].SetIsLegal(true);
                    else TablaMea.TABLA[x + 1, y + 1].SetisAtacat(true);
                }


            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0))
                if (!TablaMea.TABLA[x + 1, y].GetIsOcupat() || (TablaMea.TABLA[x + 1, y].GetIsOcupat() && TablaMea.TABLA[x + 1, y].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 1, y].SetIsLegal(true);
                    else TablaMea.TABLA[x + 1, y].SetisAtacat(true);
                }




            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0))
                if (!TablaMea.TABLA[x - 1, y].GetIsOcupat() || (TablaMea.TABLA[x - 1, y].GetIsOcupat() && TablaMea.TABLA[x - 1, y].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 1, y].SetIsLegal(true);
                    else TablaMea.TABLA[x - 1, y].SetisAtacat(true);
                }


            if (!(y + 1 > Tabla.dimensiune - 1 || y + 1 < 0))
                if (!TablaMea.TABLA[x, y + 1].GetIsOcupat() || (TablaMea.TABLA[x, y + 1].GetIsOcupat() && TablaMea.TABLA[x, y + 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x, y + 1].SetIsLegal(true);
                    else TablaMea.TABLA[x, y + 1].SetisAtacat(true);
                }




            if (!(y - 1 > Tabla.dimensiune - 1 || y - 1 < 0))
                if (!TablaMea.TABLA[x, y - 1].GetIsOcupat() || (TablaMea.TABLA[x, y - 1].GetIsOcupat() && TablaMea.TABLA[x, y - 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x, y - 1].SetIsLegal(true);
                    else TablaMea.TABLA[x, y - 1].SetisAtacat(true);
                }



            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0 || y - 1 > Tabla.dimensiune - 1 || y - 1 < 0))
                if (!TablaMea.TABLA[x + 1, y - 1].GetIsOcupat() || (TablaMea.TABLA[x + 1, y - 1].GetIsOcupat() && TablaMea.TABLA[x + 1, y - 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 1, y - 1].SetIsLegal(true);
                    else TablaMea.TABLA[x + 1, y - 1].SetisAtacat(true);
                }



            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0 || y + 1 > Tabla.dimensiune - 1 || y + 1 < 0))
                if (!TablaMea.TABLA[x - 1, y + 1].GetIsOcupat() || (TablaMea.TABLA[x - 1, y + 1].GetIsOcupat() && TablaMea.TABLA[x - 1, y + 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 1, y + 1].SetIsLegal(true);
                    else TablaMea.TABLA[x - 1, y + 1].SetisAtacat(true);
                }


            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0 || y - 1 > Tabla.dimensiune - 1 || y - 1 < 0))
                if (!TablaMea.TABLA[x - 1, y - 1].GetIsOcupat() || (TablaMea.TABLA[x - 1, y - 1].GetIsOcupat() && TablaMea.TABLA[x - 1, y - 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 1, y - 1].SetIsLegal(true);
                    else TablaMea.TABLA[x - 1, y - 1].SetisAtacat(true);
                }


            // Locada

            if (isMutat == false && TablaMea.TABLA[x + 3, y].GetPiesa() != null)
                if (TablaMea.TABLA[x + 3, y].GetPiesa().Getnume() == "Tura")
                {

                    Tura turaaux = (Tura)TablaMea.TABLA[x + 3, y].GetPiesa();
                    if (turaaux.GetisMutat() == false)
                        if (!TablaMea.TABLA[x + 1, y].GetIsOcupat() && !TablaMea.TABLA[x + 2, y].GetIsOcupat())
                        {
                            if (!f1)
                                TablaMea.TABLA[x + 2, y].SetIsLegal(true);

                        }
                }


            if (isMutat == false && TablaMea.TABLA[x - 4, y].GetPiesa() != null)
            {


                if (TablaMea.TABLA[x - 4, y].GetPiesa().Getnume() == "Tura")
                {
                    Tura turaaux2 = (Tura)TablaMea.TABLA[x - 4, y].GetPiesa();
                    if (turaaux2.GetisMutat() == false)


                        if (!TablaMea.TABLA[x - 1, y].GetIsOcupat() && !TablaMea.TABLA[x - 2, y].GetIsOcupat() && !TablaMea.TABLA[x - 3, y].GetIsOcupat())
                        {
                            if (!f1)
                                TablaMea.TABLA[x - 2, y].SetIsLegal(true);

                        }
                }
            }



        }
    }

    class FertzCal : Piesa
    {
        public FertzCal(bool isAlb)
        {
            this.nume = "FertzCal";
            this.SetisAlb(isAlb);
        }

        public override void MiscareLegala(int x, int y, Tabla TablaMea, bool f1 = false)
        {

            bool Culoare_Curenta;
            Culoare_Curenta = TablaMea.TABLA[x, y].GetPiesa().GetisAlb();


            if (!(x + 2 > Tabla.dimensiune - 1 || x + 2 < 0 || y + 1 > Tabla.dimensiune - 1 || y + 1 < 0))
                if (!TablaMea.TABLA[x + 2, y + 1].GetIsOcupat() || (TablaMea.TABLA[x + 2, y + 1].GetIsOcupat() && TablaMea.TABLA[x + 2, y + 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 2, y + 1].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 2, y + 1].SetisAtacat(true);
                }

            if (!(x - 2 > Tabla.dimensiune - 1 || x - 2 < 0 || y + 1 > Tabla.dimensiune - 1 || y + 1 < 0))
                if (!TablaMea.TABLA[x - 2, y + 1].GetIsOcupat() || (TablaMea.TABLA[x - 2, y + 1].GetIsOcupat() && TablaMea.TABLA[x - 2, y + 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 2, y + 1].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 2, y + 1].SetisAtacat(true);
                }

            if (!(x - 2 > Tabla.dimensiune - 1 || x - 2 < 0 || y - 1 > Tabla.dimensiune - 1 || y - 1 < 0))
                if (!TablaMea.TABLA[x - 2, y - 1].GetIsOcupat() || (TablaMea.TABLA[x - 2, y - 1].GetIsOcupat() && TablaMea.TABLA[x - 2, y - 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 2, y - 1].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 2, y - 1].SetisAtacat(true);
                }

            if (!(x + 2 > Tabla.dimensiune - 1 || x + 2 < 0 || y - 1 > Tabla.dimensiune - 1 || y - 1 < 0))
                if (!TablaMea.TABLA[x + 2, y - 1].GetIsOcupat() || (TablaMea.TABLA[x + 2, y - 1].GetIsOcupat() && TablaMea.TABLA[x + 2, y - 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 2, y - 1].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 2, y - 1].SetisAtacat(true);
                }

            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0 || y + 2 > Tabla.dimensiune - 1 || y + 2 < 0))

                if (!TablaMea.TABLA[x + 1, y + 2].GetIsOcupat() || (TablaMea.TABLA[x + 1, y + 2].GetIsOcupat() && TablaMea.TABLA[x + 1, y + 2].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 1, y + 2].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 1, y + 2].SetisAtacat(true);
                }

            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0 || y + 2 > Tabla.dimensiune - 1 || y + 2 < 0))
                if (!TablaMea.TABLA[x - 1, y + 2].GetIsOcupat() || (TablaMea.TABLA[x - 1, y + 2].GetIsOcupat() && TablaMea.TABLA[x - 1, y + 2].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 1, y + 2].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 1, y + 2].SetisAtacat(true);
                }

            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0 || y - 2 > Tabla.dimensiune - 1 || y - 2 < 0))
                if (!TablaMea.TABLA[x - 1, y - 2].GetIsOcupat() || (TablaMea.TABLA[x - 1, y - 2].GetIsOcupat() && TablaMea.TABLA[x - 1, y - 2].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 1, y - 2].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 1, y - 2].SetisAtacat(true);
                }

            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0 || y - 2 > Tabla.dimensiune - 1 || y - 2 < 0))
                if (!TablaMea.TABLA[x + 1, y - 2].GetIsOcupat() || (TablaMea.TABLA[x + 1, y - 2].GetIsOcupat() && TablaMea.TABLA[x + 1, y - 2].GetPiesa().GetisAlb() != Culoare_Curenta))
                {

                    if (!f1)
                        TablaMea.TABLA[x + 1, y - 2].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 1, y - 2].SetisAtacat(true);

                }

            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0 || y + 1 > Tabla.dimensiune - 1 || y + 1 < 0))
                if (!TablaMea.TABLA[x + 1, y + 1].GetIsOcupat() || (TablaMea.TABLA[x + 1, y + 1].GetIsOcupat() && TablaMea.TABLA[x + 1, y + 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 1, y + 1].SetIsLegal(true);
                    else TablaMea.TABLA[x + 1, y + 1].SetisAtacat(true);
                }
            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0 || y - 1 > Tabla.dimensiune - 1 || y - 1 < 0))
                if (!TablaMea.TABLA[x + 1, y - 1].GetIsOcupat() || (TablaMea.TABLA[x + 1, y - 1].GetIsOcupat() && TablaMea.TABLA[x + 1, y - 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 1, y - 1].SetIsLegal(true);
                    else TablaMea.TABLA[x + 1, y - 1].SetisAtacat(true);
                }



            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0 || y + 1 > Tabla.dimensiune - 1 || y + 1 < 0))
                if (!TablaMea.TABLA[x - 1, y + 1].GetIsOcupat() || (TablaMea.TABLA[x - 1, y + 1].GetIsOcupat() && TablaMea.TABLA[x - 1, y + 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 1, y + 1].SetIsLegal(true);
                    else TablaMea.TABLA[x - 1, y + 1].SetisAtacat(true);
                }

            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0 || y - 1 > Tabla.dimensiune - 1 || y - 1 < 0))
                if (!TablaMea.TABLA[x - 1, y - 1].GetIsOcupat() || (TablaMea.TABLA[x - 1, y - 1].GetIsOcupat() && TablaMea.TABLA[x - 1, y - 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 1, y - 1].SetIsLegal(true);
                    else TablaMea.TABLA[x - 1, y - 1].SetisAtacat(true);
                }

        }


    }
    class WazirCal : Piesa
    {
        public WazirCal(bool isAlb)
        {
            this.nume = "WazirCal";
            this.SetisAlb(isAlb);
        }

        public override void MiscareLegala(int x, int y, Tabla TablaMea, bool f1 = false)
        {

            bool Culoare_Curenta;
            Culoare_Curenta = TablaMea.TABLA[x, y].GetPiesa().GetisAlb();


            if (!(x + 2 > Tabla.dimensiune - 1 || x + 2 < 0 || y + 1 > Tabla.dimensiune - 1 || y + 1 < 0))
                if (!TablaMea.TABLA[x + 2, y + 1].GetIsOcupat() || (TablaMea.TABLA[x + 2, y + 1].GetIsOcupat() && TablaMea.TABLA[x + 2, y + 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 2, y + 1].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 2, y + 1].SetisAtacat(true);
                }

            if (!(x - 2 > Tabla.dimensiune - 1 || x - 2 < 0 || y + 1 > Tabla.dimensiune - 1 || y + 1 < 0))
                if (!TablaMea.TABLA[x - 2, y + 1].GetIsOcupat() || (TablaMea.TABLA[x - 2, y + 1].GetIsOcupat() && TablaMea.TABLA[x - 2, y + 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 2, y + 1].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 2, y + 1].SetisAtacat(true);
                }

            if (!(x - 2 > Tabla.dimensiune - 1 || x - 2 < 0 || y - 1 > Tabla.dimensiune - 1 || y - 1 < 0))
                if (!TablaMea.TABLA[x - 2, y - 1].GetIsOcupat() || (TablaMea.TABLA[x - 2, y - 1].GetIsOcupat() && TablaMea.TABLA[x - 2, y - 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 2, y - 1].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 2, y - 1].SetisAtacat(true);
                }

            if (!(x + 2 > Tabla.dimensiune - 1 || x + 2 < 0 || y - 1 > Tabla.dimensiune - 1 || y - 1 < 0))
                if (!TablaMea.TABLA[x + 2, y - 1].GetIsOcupat() || (TablaMea.TABLA[x + 2, y - 1].GetIsOcupat() && TablaMea.TABLA[x + 2, y - 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 2, y - 1].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 2, y - 1].SetisAtacat(true);
                }

            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0 || y + 2 > Tabla.dimensiune - 1 || y + 2 < 0))

                if (!TablaMea.TABLA[x + 1, y + 2].GetIsOcupat() || (TablaMea.TABLA[x + 1, y + 2].GetIsOcupat() && TablaMea.TABLA[x + 1, y + 2].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 1, y + 2].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 1, y + 2].SetisAtacat(true);
                }

            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0 || y + 2 > Tabla.dimensiune - 1 || y + 2 < 0))
                if (!TablaMea.TABLA[x - 1, y + 2].GetIsOcupat() || (TablaMea.TABLA[x - 1, y + 2].GetIsOcupat() && TablaMea.TABLA[x - 1, y + 2].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 1, y + 2].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 1, y + 2].SetisAtacat(true);
                }

            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0 || y - 2 > Tabla.dimensiune - 1 || y - 2 < 0))
                if (!TablaMea.TABLA[x - 1, y - 2].GetIsOcupat() || (TablaMea.TABLA[x - 1, y - 2].GetIsOcupat() && TablaMea.TABLA[x - 1, y - 2].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 1, y - 2].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 1, y - 2].SetisAtacat(true);
                }

            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0 || y - 2 > Tabla.dimensiune - 1 || y - 2 < 0))
                if (!TablaMea.TABLA[x + 1, y - 2].GetIsOcupat() || (TablaMea.TABLA[x + 1, y - 2].GetIsOcupat() && TablaMea.TABLA[x + 1, y - 2].GetPiesa().GetisAlb() != Culoare_Curenta))
                {

                    if (!f1)
                        TablaMea.TABLA[x + 1, y - 2].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 1, y - 2].SetisAtacat(true);

                }

            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0))
                if (!TablaMea.TABLA[x + 1, y].GetIsOcupat() || (TablaMea.TABLA[x + 1, y].GetIsOcupat() && TablaMea.TABLA[x + 1, y].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 1, y].SetIsLegal(true);
                    else TablaMea.TABLA[x + 1, y].SetisAtacat(true);
                }




            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0))
                if (!TablaMea.TABLA[x - 1, y].GetIsOcupat() || (TablaMea.TABLA[x - 1, y].GetIsOcupat() && TablaMea.TABLA[x - 1, y].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 1, y].SetIsLegal(true);
                    else TablaMea.TABLA[x - 1, y].SetisAtacat(true);
                }


            if (!(y + 1 > Tabla.dimensiune - 1 || y + 1 < 0))
                if (!TablaMea.TABLA[x, y + 1].GetIsOcupat() || (TablaMea.TABLA[x, y + 1].GetIsOcupat() && TablaMea.TABLA[x, y + 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x, y + 1].SetIsLegal(true);
                    else TablaMea.TABLA[x, y + 1].SetisAtacat(true);
                }

            if (!(y - 1 > Tabla.dimensiune - 1 || y - 1 < 0))
                if (!TablaMea.TABLA[x, y - 1].GetIsOcupat() || (TablaMea.TABLA[x, y - 1].GetIsOcupat() && TablaMea.TABLA[x, y - 1].GetPiesa().GetisAlb() != Culoare_Curenta))
                {
                    if (!f1)
                        TablaMea.TABLA[x, y - 1].SetIsLegal(true);
                    else TablaMea.TABLA[x, y - 1].SetisAtacat(true);
                }
        }
    }

    class LoonySnakeTura : Piesa
    {


        public LoonySnakeTura(bool isAlb)
        {
            this.nume = "LoonySnakeTura";
            this.SetisAlb(isAlb);
        }
        public override void MiscareLegala(int x, int y, Tabla TablaMea, bool f1 = false)
        {

            bool Culoare_Curenta;

            Culoare_Curenta = TablaMea.TABLA[x, y].GetPiesa().GetisAlb();

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x + i > Tabla.dimensiune - 1 || x + i < 0))
                {
                    if (!TablaMea.TABLA[x + i, y].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x + i, y].GetIsOcupat() && TablaMea.TABLA[x + i, y].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y].SetisAtacat(true);

                        break;
                    }
                    else break;
                }
                else break;
            }
            ////////////
            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x - i > Tabla.dimensiune - 1 || x - i < 0))
                {
                    if (!TablaMea.TABLA[x - i, y].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x - i, y].GetIsOcupat() && TablaMea.TABLA[x - i, y].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }
            ///////////////////
            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(y + i > Tabla.dimensiune - 1 || y + i < 0))
                {
                    if (!TablaMea.TABLA[x, y + i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x, y + i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x, y + i].GetIsOcupat() && TablaMea.TABLA[x, y + i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x, y + i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }
            /////////////////////

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(y - i > Tabla.dimensiune - 1 || y - i < 0))
                {
                    if (!TablaMea.TABLA[x, y - i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x, y - i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x, y - i].GetIsOcupat() && TablaMea.TABLA[x, y - i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x, y - i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }
             // conditie posdasdasd
            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0 || y - 3 > Tabla.dimensiune - 1 || y - 3< 0))
                if ((!TablaMea.TABLA[x - 1, y - 3].GetIsOcupat() || (TablaMea.TABLA[x - 1, y - 3].GetIsOcupat() && TablaMea.TABLA[x - 1, y - 3].GetPiesa().GetisAlb() != Culoare_Curenta))&& ((!TablaMea.TABLA[x , y - 1].GetIsOcupat()&& !TablaMea.TABLA[x , y - 2].GetIsOcupat()) || (!TablaMea.TABLA[x - 1, y - 1].GetIsOcupat() && !TablaMea.TABLA[x - 1, y - 2].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 1, y - 3].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 1, y - 3].SetisAtacat(true);
                }

            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0 || y - 3 > Tabla.dimensiune - 1 || y - 3 < 0))
                if ((!TablaMea.TABLA[x + 1, y - 3].GetIsOcupat() || (TablaMea.TABLA[x + 1, y - 3].GetIsOcupat() && TablaMea.TABLA[x + 1, y - 3].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x, y - 1].GetIsOcupat() && !TablaMea.TABLA[x, y - 2].GetIsOcupat()) || (!TablaMea.TABLA[x + 1, y - 1].GetIsOcupat() && !TablaMea.TABLA[x + 1, y - 2].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 1, y - 3].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 1, y - 3].SetisAtacat(true);
                }

            if (!(x - 1 > Tabla.dimensiune - 1 || x - 1 < 0 || y + 3 > Tabla.dimensiune - 1 || y + 3 < 0))
                if ((!TablaMea.TABLA[x - 1, y + 3].GetIsOcupat() || (TablaMea.TABLA[x - 1, y + 3].GetIsOcupat() && TablaMea.TABLA[x - 1, y + 3].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x, y + 1].GetIsOcupat() && !TablaMea.TABLA[x, y + 2].GetIsOcupat()) || (!TablaMea.TABLA[x - 1, y + 1].GetIsOcupat() && !TablaMea.TABLA[x - 1, y + 2].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 1, y + 3].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 1, y + 3].SetisAtacat(true);
                }

            if (!(x + 1 > Tabla.dimensiune - 1 || x + 1 < 0 || y + 3 > Tabla.dimensiune - 1 || y + 3 < 0))
                if ((!TablaMea.TABLA[x + 1, y + 3].GetIsOcupat() || (TablaMea.TABLA[x + 1, y + 3].GetIsOcupat() && TablaMea.TABLA[x + 1, y + 3].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x, y + 1].GetIsOcupat() && !TablaMea.TABLA[x, y + 2].GetIsOcupat()) || (!TablaMea.TABLA[x + 1, y + 1].GetIsOcupat() && !TablaMea.TABLA[x + 1, y + 2].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 1, y + 3].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 1, y + 3].SetisAtacat(true);
                }

            //////////////////////////////
            if (!(y - 1 > Tabla.dimensiune - 1 || y - 1 < 0 || x - 3 > Tabla.dimensiune - 1 || x - 3 < 0))
                if ((!TablaMea.TABLA[x - 3, y - 1].GetIsOcupat() || (TablaMea.TABLA[x - 3, y - 1].GetIsOcupat() && TablaMea.TABLA[x - 3, y - 1].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x - 1, y].GetIsOcupat() && !TablaMea.TABLA[x - 2, y].GetIsOcupat()) || (!TablaMea.TABLA[x - 1, y - 1].GetIsOcupat() && !TablaMea.TABLA[x - 2, y - 1].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 3, y - 1].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 3, y - 1].SetisAtacat(true);
                }

            if (!(y + 1 > Tabla.dimensiune - 1 || y + 1 < 0 || x - 3 > Tabla.dimensiune - 1 || x - 3 < 0))
                if ((!TablaMea.TABLA[x - 3, y + 1].GetIsOcupat() || (TablaMea.TABLA[x - 3, y + 1].GetIsOcupat() && TablaMea.TABLA[x - 3, y + 1].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x - 1, y].GetIsOcupat() && !TablaMea.TABLA[x - 2, y].GetIsOcupat()) || (!TablaMea.TABLA[x - 1, y + 1].GetIsOcupat() && !TablaMea.TABLA[x - 2, y + 1].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 3, y + 1].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 3, y + 1].SetisAtacat(true);
                }
            /////////////////////////////////

            if (!(y - 1 > Tabla.dimensiune - 1 || y - 1 < 0 || x + 3 > Tabla.dimensiune - 1 || x + 3 < 0))
                if ((!TablaMea.TABLA[x + 3, y - 1].GetIsOcupat() || (TablaMea.TABLA[x + 3, y - 1].GetIsOcupat() && TablaMea.TABLA[x + 3, y - 1].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x + 1, y].GetIsOcupat() && !TablaMea.TABLA[x + 2, y].GetIsOcupat()) || (!TablaMea.TABLA[x + 1, y - 1].GetIsOcupat() && !TablaMea.TABLA[x + 2, y - 1].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 3, y - 1].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 3, y - 1].SetisAtacat(true);
                }

            if (!(y + 1 > Tabla.dimensiune - 1 || y + 1 < 0 || x + 3 > Tabla.dimensiune - 1 || x + 3 < 0))
                if ((!TablaMea.TABLA[x + 3, y + 1].GetIsOcupat() || (TablaMea.TABLA[x + 3, y + 1].GetIsOcupat() && TablaMea.TABLA[x + 3, y + 1].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x + 1, y].GetIsOcupat() && !TablaMea.TABLA[x + 2, y].GetIsOcupat()) || (!TablaMea.TABLA[x + 1, y + 1].GetIsOcupat() && !TablaMea.TABLA[x + 2, y + 1].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 3, y + 1].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 3, y + 1].SetisAtacat(true);
                }
        }
    }
    class InsaneNebun : Piesa
    {
        public InsaneNebun(bool isAlb)
        {
            this.nume = "InsaneNebun";
            this.SetisAlb(isAlb);
        }
        public override void MiscareLegala(int x, int y, Tabla TablaMea, bool f1 = false)
        {
            bool Culoare_Curenta;

            Culoare_Curenta = TablaMea.TABLA[x, y].GetPiesa().GetisAlb();

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x + i > Tabla.dimensiune - 1 || x + i < 0 || y + i > Tabla.dimensiune - 1 || y + i < 0))
                {
                    if (!TablaMea.TABLA[x + i, y + i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y + i].SetisAtacat(true);
                    }

                    else
                    if (TablaMea.TABLA[x + i, y + i].GetIsOcupat() && TablaMea.TABLA[x + i, y + i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y + i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }



            /////////////////

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x - i > Tabla.dimensiune - 1 || x - i < 0 || y - i > Tabla.dimensiune - 1 || y - i < 0))
                {
                    if (!TablaMea.TABLA[x - i, y - i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y - i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x - i, y - i].GetIsOcupat() && TablaMea.TABLA[x - i, y - i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y - i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }


            ///////////////////

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x - i > Tabla.dimensiune - 1 || x - i < 0 || y + i > Tabla.dimensiune - 1 || y + i < 0))
                {
                    if (!TablaMea.TABLA[x - i, y + i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y + i].SetIsLegal(true);
                        else TablaMea.TABLA[x - i, y + i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x - i, y + i].GetIsOcupat() && TablaMea.TABLA[x - i, y + i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x - i, y + i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x - i, y + i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }

            /////////////////////

            for (int i = 1; i < Tabla.dimensiune; i++)
            {
                if (!(x + i > Tabla.dimensiune - 1 || x + i < 0 || y - i > Tabla.dimensiune - 1 || y - i < 0))
                {
                    if (!TablaMea.TABLA[x + i, y - i].GetIsOcupat())
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y - i].SetisAtacat(true);
                    }
                    else
                    if (TablaMea.TABLA[x + i, y - i].GetIsOcupat() && TablaMea.TABLA[x + i, y - i].GetPiesa().GetisAlb() != Culoare_Curenta)
                    {
                        if (!f1)
                            TablaMea.TABLA[x + i, y - i].SetIsLegal(true);
                        else
                            TablaMea.TABLA[x + i, y - i].SetisAtacat(true);
                        break;
                    }
                    else break;
                }
                else break;
            }

            if (!(x - 2 > Tabla.dimensiune - 1 || x - 2 < 0 || y - 3 > Tabla.dimensiune - 1 || y - 3 < 0))
                if ((!TablaMea.TABLA[x - 2, y - 3].GetIsOcupat() || (TablaMea.TABLA[x - 2, y - 3].GetIsOcupat() && TablaMea.TABLA[x - 2, y - 3].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x - 1, y - 1].GetIsOcupat() && !TablaMea.TABLA[x - 2, y - 2].GetIsOcupat()) || (!TablaMea.TABLA[x , y - 1].GetIsOcupat() && !TablaMea.TABLA[x - 1, y - 2].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 2, y - 3].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 2, y - 3].SetisAtacat(true);
                }

            if (!(x - 3 > Tabla.dimensiune - 1 || x - 3 < 0 || y - 2 > Tabla.dimensiune - 1 || y - 2 < 0))
                if ((!TablaMea.TABLA[x - 3, y - 2].GetIsOcupat() || (TablaMea.TABLA[x - 3, y - 2].GetIsOcupat() && TablaMea.TABLA[x - 3, y - 2].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x - 1, y - 1].GetIsOcupat() && !TablaMea.TABLA[x - 2, y - 2].GetIsOcupat()) || (!TablaMea.TABLA[x - 1, y].GetIsOcupat() && !TablaMea.TABLA[x - 2, y - 1].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 3, y - 2].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 3, y - 2].SetisAtacat(true);
                }

            if (!(x + 2 > Tabla.dimensiune - 1 || x + 2 < 0 || y - 3 > Tabla.dimensiune - 1 || y - 3 < 0))
                if ((!TablaMea.TABLA[x + 2, y - 3].GetIsOcupat() || (TablaMea.TABLA[x + 2, y - 3].GetIsOcupat() && TablaMea.TABLA[x + 2, y - 3].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x + 1, y - 1].GetIsOcupat() && !TablaMea.TABLA[x + 2, y - 2].GetIsOcupat()) || (!TablaMea.TABLA[x, y - 1].GetIsOcupat() && !TablaMea.TABLA[x + 1, y - 2].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 2, y - 3].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 2, y - 3].SetisAtacat(true);
                }

            if (!(x + 3 > Tabla.dimensiune - 1 || x + 3 < 0 || y - 2 > Tabla.dimensiune - 1 || y - 2 < 0))
                if ((!TablaMea.TABLA[x + 3, y - 2].GetIsOcupat() || (TablaMea.TABLA[x + 3, y - 2].GetIsOcupat() && TablaMea.TABLA[x + 3, y - 2].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x + 1, y - 1].GetIsOcupat() && !TablaMea.TABLA[x + 2, y - 2].GetIsOcupat()) || (!TablaMea.TABLA[x + 1, y].GetIsOcupat() && !TablaMea.TABLA[x + 2, y - 1].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 3, y - 2].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 3, y - 2].SetisAtacat(true);
                }
            /////////////////////////
            if (!(x - 2 > Tabla.dimensiune - 1 || x - 2 < 0 || y + 3 > Tabla.dimensiune - 1 || y + 3 < 0))
                if ((!TablaMea.TABLA[x - 2, y + 3].GetIsOcupat() || (TablaMea.TABLA[x - 2, y + 3].GetIsOcupat() && TablaMea.TABLA[x - 2, y + 3].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x - 1, y + 1].GetIsOcupat() && !TablaMea.TABLA[x - 2, y + 2].GetIsOcupat()) || (!TablaMea.TABLA[x, y + 1].GetIsOcupat() && !TablaMea.TABLA[x - 1, y + 2].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 2, y + 3].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 2, y + 3].SetisAtacat(true);
                }

            if (!(x - 3 > Tabla.dimensiune - 1 || x - 3 < 0 || y + 2 > Tabla.dimensiune - 1 || y + 2 < 0))
                if ((!TablaMea.TABLA[x - 3, y + 2].GetIsOcupat() || (TablaMea.TABLA[x - 3, y + 2].GetIsOcupat() && TablaMea.TABLA[x - 3, y + 2].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x - 1, y + 1].GetIsOcupat() && !TablaMea.TABLA[x - 2, y + 2].GetIsOcupat()) || (!TablaMea.TABLA[x - 1, y].GetIsOcupat() && !TablaMea.TABLA[x - 2, y + 1].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x - 3, y + 2].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x - 3, y + 2].SetisAtacat(true);
                }

            if (!(x + 2 > Tabla.dimensiune - 1 || x + 2 < 0 || y + 3 > Tabla.dimensiune - 1 || y + 3 < 0))
                if ((!TablaMea.TABLA[x + 2, y + 3].GetIsOcupat() || (TablaMea.TABLA[x + 2, y + 3].GetIsOcupat() && TablaMea.TABLA[x + 2, y + 3].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x + 1, y + 1].GetIsOcupat() && !TablaMea.TABLA[x + 2, y + 2].GetIsOcupat()) || (!TablaMea.TABLA[x, y + 1].GetIsOcupat() && !TablaMea.TABLA[x + 1, y + 2].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 2, y + 3].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 2, y + 3].SetisAtacat(true);
                }

            if (!(x + 3 > Tabla.dimensiune - 1 || x + 3 < 0 || y + 2 > Tabla.dimensiune - 1 || y + 2 < 0))
                if ((!TablaMea.TABLA[x + 3, y + 2].GetIsOcupat() || (TablaMea.TABLA[x + 3, y + 2].GetIsOcupat() && TablaMea.TABLA[x + 3, y + 2].GetPiesa().GetisAlb() != Culoare_Curenta)) && ((!TablaMea.TABLA[x + 1, y + 1].GetIsOcupat() && !TablaMea.TABLA[x + 2, y + 2].GetIsOcupat()) || (!TablaMea.TABLA[x + 1, y].GetIsOcupat() && !TablaMea.TABLA[x + 2, y + 1].GetIsOcupat())))
                {
                    if (!f1)
                        TablaMea.TABLA[x + 3, y + 2].SetIsLegal(true);
                    else
                        TablaMea.TABLA[x + 3, y + 2].SetisAtacat(true);
                }
        }
    }

}


