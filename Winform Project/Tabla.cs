using System;
using System.Collections.Generic;

namespace Winform_Project
{
    public class Tabla : ICloneable

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
            TABLA[1, 9].SetPiesa(new WazirCal(true));
            TABLA[1, 9].SetIsOcupat(true);
            TABLA[8, 9].SetPiesa(new FertzCal(true));
            TABLA[8, 9].SetIsOcupat(true);
            TABLA[1, 0].SetPiesa(new WazirCal(false));
            TABLA[1, 0].SetIsOcupat(true);
            TABLA[8, 0].SetPiesa(new FertzCal(false));
            TABLA[8, 0].SetIsOcupat(true);

            TABLA[0, 9].SetPiesa(new Tura(true));
            TABLA[0, 9].SetIsOcupat(true);
            TABLA[9, 9].SetPiesa(new Tura(true));
            TABLA[9, 9].SetIsOcupat(true);
            TABLA[0, 0].SetPiesa(new Tura(false));
            TABLA[0, 0].SetIsOcupat(true);
            TABLA[9, 0].SetPiesa(new Tura(false));
            TABLA[9, 0].SetIsOcupat(true);

            TABLA[6, 0].SetPiesa(new LoonySnakeTura(false));
            TABLA[6, 0].SetIsOcupat(true);

            TABLA[6, 9].SetPiesa(new LoonySnakeTura(true));
            TABLA[6, 9].SetIsOcupat(true);

            TABLA[3, 0].SetPiesa(new InsaneNebun(false));
            TABLA[3, 0].SetIsOcupat(true);

            TABLA[3, 9].SetPiesa(new InsaneNebun(true));
            TABLA[3, 9].SetIsOcupat(true);

            TABLA[2, 9].SetPiesa(new Nebun(true));
            TABLA[2, 9].SetIsOcupat(true);
            TABLA[7, 9].SetPiesa(new Nebun(true));
            TABLA[7, 9].SetIsOcupat(true);
            TABLA[2, 0].SetPiesa(new Nebun(false));
            TABLA[2, 0].SetIsOcupat(true);
            TABLA[7, 0].SetPiesa(new Nebun(false));
            TABLA[7, 0].SetIsOcupat(true);

            TABLA[4, 9].SetPiesa(new Regina(true));
            TABLA[4, 9].SetIsOcupat(true);
            TABLA[4, 0].SetPiesa(new Regina(false));
            TABLA[4, 0].SetIsOcupat(true);

            TABLA[5, 9].SetPiesa(new Rege(true));
            TABLA[5, 9].SetIsOcupat(true);

            TABLA[5, 0].SetPiesa(new Rege(false));
            TABLA[5, 0].SetIsOcupat(true);

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

        public Dictionary<Pozitie, List<Pozitie>> getAllLegalMoves(bool turn)
        {
            Dictionary<Pozitie, List<Pozitie>> miscariLegale = new Dictionary<Pozitie, List<Pozitie>>();

            for (int i = 0; i < dimensiune; i++)
            {
                for (int j = 0; j < dimensiune; j++)
                {
                    if (TABLA[i, j].GetIsOcupat() == true && TABLA[i, j].GetPiesa().GetisAlb() == turn)
                    {

                        TABLA[i, j].GetPiesa().MiscareLegala(i, j, this);

                        List<Pozitie> listaPozitii = new List<Pozitie>();

                        for (int k = 0; k < dimensiune; k++)
                        {
                            for (int l = 0; l < dimensiune; l++)
                            {
                                if (TABLA[k, l].GetIsLegal() == true)
                                {
                                    listaPozitii.Add(new Pozitie(k, l));

                                }
                            }
                        }
                        miscariLegale.Add(new Pozitie(i, j), listaPozitii);
                        this.CuratareisLegal();
                    }
                }


            }

            return miscariLegale;

        }

        public int GetScoreFromExistingPieces(bool turn)
        {
            int pawnValue = 100;
            int knightValue = 320;
            int bishopValue = 330;
            int rookValue = 500;
            int queenValue = 900;
            int kingValue = 20000;
            int material = 0;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (TABLA[i, j].GetPiesa() != null)
                    {
                        if (TABLA[i, j].GetPiesa().GetType() == typeof(Pion) && TABLA[i, j].GetPiesa().GetisAlb() == turn)
                        {
                            material += (pawnValue); // plus "+ bestPawnPositions[i]" if you want, but it doesn't work well
                        }
                        if (TABLA[i, j].GetPiesa().GetType() == typeof(WazirCal) && TABLA[i, j].GetPiesa().GetisAlb() == turn)
                        {
                            material += (knightValue); // plus "+ bestKnightPositions[i]" if you want, but it doesn't work well
                        }
                        if (TABLA[i, j].GetPiesa().GetType() == typeof(Nebun) && TABLA[i, j].GetPiesa().GetisAlb() == turn)
                        {
                            material += (bishopValue); // plus "+ bestBishopPositions[i]" if you want, but it doesn't work well
                        }
                        if (TABLA[i, j].GetPiesa().GetType() == typeof(Tura) && TABLA[i, j].GetPiesa().GetisAlb() == turn)
                        {
                            material += (rookValue); // plus "+ bestRookPositions[i]" if you want, but it doesn't work well
                        }
                        if (TABLA[i, j].GetPiesa().GetType() == typeof(Regina) && TABLA[i, j].GetPiesa().GetisAlb() == turn)
                        {
                            material += (queenValue); // plus "+ bestQueenPositions[i]" if you want, but it doesn't work well
                        }
                        if (TABLA[i, j].GetPiesa().GetType() == typeof(Rege) && TABLA[i, j].GetPiesa().GetisAlb() == turn)
                        {
                            material += (kingValue); // plus "+ bestKingPositions[i]" if you want, but it doesn't work well
                        }
                    }
                }
            }
            return material;
        }
        public void MovePiece(int xAnte, int yAnte, int xNew, int yNew) {

            TABLA[xNew,yNew].SetPiesa(TABLA[xAnte, yAnte].GetPiesa());
            TABLA[xNew, yNew].SetIsOcupat(true);

            TABLA[xAnte, yAnte].SetPiesa(null);
            TABLA[xAnte, yAnte].SetIsOcupat(false);
        }

        public object Clone()
        {

            return this.MemberwiseClone();

        }
    }
}




