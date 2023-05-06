﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_Project
{
    public class Tabla
    {
        public Casuta[,] TABLA;
        public static int dimensiune = 10;

        public Tabla()
        {

            TABLA = new Casuta[dimensiune, dimensiune];
            for (int i = 0; i < dimensiune; i++)
            {
                for (int j = 0; j < dimensiune; j++)
                {
                    TABLA[i, j] = new Casuta();
                }

            }
        }




        public void CuratareisLegal()
        {
            for (int i = 0; i < dimensiune; i++)

                for (int j = 0; j < dimensiune; j++)

                    TABLA[i, j].SetIsLegal(false);



        }
        public void CuratareAtacat()
        {
            for (int i = 0; i < dimensiune; i++)

                for (int j = 0; j < dimensiune; j++)

                    TABLA[i, j].SetisAtacat(false);



        }

        public void PlasarePiese()
        {
            for (int i = 0; i < dimensiune; i++)
            {
                TABLA[i, dimensiune - 2].SetPiesa(new Pion(true));
                TABLA[i, dimensiune - 2].SetIsOcupat(true);
            }
            for (int i = 0; i < dimensiune; i++)
            {
                TABLA[i, 1].SetPiesa(new Pion(false));
                TABLA[i, 1].SetIsOcupat(true);
            }
            TABLA[1, 9].SetPiesa(new Cal(true));
            TABLA[1, 9].SetIsOcupat(true);
            TABLA[6, 9].SetPiesa(new Cal(true));
            TABLA[6, 9].SetIsOcupat(true);
            TABLA[1, 0].SetPiesa(new Cal(false));
            TABLA[1, 0].SetIsOcupat(true);
            TABLA[6, 0].SetPiesa(new Cal(false));
            TABLA[6, 0].SetIsOcupat(true);

            TABLA[0, 9].SetPiesa(new Tura(true));
            TABLA[0, 9].SetIsOcupat(true);
            TABLA[9, 9].SetPiesa(new Tura(true));
            TABLA[9, 9].SetIsOcupat(true);
            TABLA[0, 0].SetPiesa(new Tura(false));
            TABLA[0, 0].SetIsOcupat(true);
            TABLA[9, 0].SetPiesa(new Tura(false));
            TABLA[9, 0].SetIsOcupat(true);
            TABLA[2, 9].SetPiesa(new Nebun(true));
            TABLA[2, 9].SetIsOcupat(true);
            TABLA[5, 9].SetPiesa(new Nebun(true));
            TABLA[5, 9].SetIsOcupat(true);
            TABLA[2, 0].SetPiesa(new Nebun(false));
            TABLA[2, 0].SetIsOcupat(true);
            TABLA[5, 0].SetPiesa(new Nebun(false));
            TABLA[5, 0].SetIsOcupat(true);

            TABLA[3, 9].SetPiesa(new Regina(true));
            TABLA[3, 9].SetIsOcupat(true);
            TABLA[3, 0].SetPiesa(new Regina(false));
            TABLA[3, 0].SetIsOcupat(true);
            TABLA[4, 9].SetPiesa(new Rege(true));
            TABLA[4, 9].SetIsOcupat(true);
            TABLA[4, 0].SetPiesa(new Rege(false));
            TABLA[4, 0].SetIsOcupat(true);

        }

        public bool checkSah(bool turn)
        {

            {//setam casutele atacate
                for (int i = 0; i < dimensiune; i++)
                    for (int j = 0; j < dimensiune; j++)
                    {
                        if (TABLA[i, j].GetIsOcupat())
                            if (TABLA[i, j].GetPiesa().GetisAlb() == turn)
                                TABLA[i, j].GetPiesa().SetiingisAtacked(i, j, this);
                    }
            }

            //verificam daca casuta regelui e atacata
            for (int i = 0; i < dimensiune; i++)
                for (int j = 0; j < dimensiune; j++)
                {
                    if (TABLA[i, j].GetIsOcupat() && TABLA[i, j].GetPiesa().Getnume() == "Rege")
                        if (TABLA[i, j].GetPiesa().GetisAlb() != turn && TABLA[i, j].GetisAtacat())
                        {
                            CuratareAtacat();
                            return true;
                        }
                }


            CuratareAtacat();
            return false;
        }

        //Funtie care sterge miscarile legale care pun regele in sah ( un fel de backtracking )
        public void VerifLegal(Casuta Casutacurenta, bool CuloarePiesa)
        {
            Piesa aux = null;
            bool auxo;
            for (int i = 0; i < dimensiune; i++)
            {
                for (int j = 0; j < dimensiune; j++)
                {

                    if (TABLA[i, j].GetIsLegal() == true)
                    {

                        aux = TABLA[i, j].GetPiesa();
                        auxo = TABLA[i, j].GetIsOcupat();
                        TABLA[i, j].SetPiesa(Casutacurenta.GetPiesa());
                        TABLA[i, j].SetIsOcupat(true);
                        Casutacurenta.SetIsOcupat(false);
                        Casutacurenta.SetPiesa(null);
                        if (checkSah(!CuloarePiesa))
                        {

                            TABLA[i, j].SetIsLegal(false);

                        }
                        Casutacurenta.SetPiesa(TABLA[i, j].GetPiesa());
                        Casutacurenta.SetIsOcupat(true);
                        TABLA[i, j].SetPiesa(aux);
                        TABLA[i, j].SetIsOcupat(auxo);
                        CuratareAtacat();

                    }

                }

            }
        }


        //Conditie sahmat regele nu mai are unde muta
        public bool SahMat(bool turn)
        {
            for (int i = 0; i < dimensiune; i++)
            {
                for (int j = 0; j < dimensiune; j++)
                {
                    if (TABLA[i, j].GetIsOcupat() == true && TABLA[i, j].GetPiesa().GetisAlb() == turn)
                    {
                        TABLA[i, j].GetPiesa().MiscareLegala(i, j, this);
                        VerifLegal(TABLA[i, j], turn);
                        for (int k = 0; k < dimensiune; k++)
                            for (int l = 0; l < dimensiune; l++)
                                if (TABLA[k, l].GetIsLegal() == true)
                                    return false;
                    }
                }
            }


            return true;
        }


    }


}

