using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_Project
{
    public class AI
    {
        public int depth;
        public AI(int depth) {
            this.depth = depth;
        }

        public int CalculatePoint(Tabla myTabla,bool turn)
        {
            int scoreWhite = 0;
            int scoreBlack = 0;
            scoreWhite += myTabla.GetScoreFromExistingPieces(true);
            scoreBlack += myTabla.GetScoreFromExistingPieces(false);

            int evaluation = scoreBlack - scoreWhite;

            int prespective = (turn) ? -1 : 1;
            return evaluation * prespective;
        }


        public  Tabla GenerateMovedTabla(Tabla oldBoard, int xAnte, int yAnte, int xNew, int yNew)
        {
            Tabla newTable = new Tabla();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (oldBoard.TABLA[i, j].GetPiesa() != null)
                    {

                        Piesa oldPiece = oldBoard.TABLA[i, j].GetPiesa();
                        var oldBoardPieceType = oldBoard.TABLA[i, j].GetPiesa().GetType();
                        bool oldBoardPieceColor = oldBoard.TABLA[i, j].GetPiesa().GetisAlb();

                        newTable.TABLA[i, j].SetPiesa(oldPiece);
                        newTable.TABLA[i, j].SetIsOcupat(true);
                    }
                }
            }
                    newTable.MovePiece(xAnte, yAnte, xNew, yNew);
            return newTable;
        }


        private int Minimax(Tabla myTabla, int depth,bool turn)
        {
            if (depth == 0)
                return CalculatePoint(myTabla,turn);

            if (turn)
            {
                int bestValue = int.MinValue;

                Dictionary<Pozitie, List<Pozitie>> possibleMoves = myTabla.getAllLegalMoves(turn);

                foreach (var kvp in possibleMoves)
                {
                    int xAnte = kvp.Key.x;
                    int yAnte = kvp.Key.y;
                    List<Pozitie> pozitii = kvp.Value;
                    foreach (Pozitie pozitie in pozitii)
                    {
                        int xNew = pozitie.x;
                        int yNew = pozitie.y;

                        Tabla newTabla = GenerateMovedTabla(myTabla, xAnte, yAnte, xNew, yNew);
                        int value = Minimax(newTabla, depth - 1, false);

                        bestValue = Math.Max(value, bestValue);

                    }

                    return bestValue;
                }
            }
            else
            {
                int bestValue = int.MaxValue;

                Dictionary<Pozitie, List<Pozitie>> possibleMoves = myTabla.getAllLegalMoves(turn);

                foreach (var kvp in possibleMoves)
                {
                    int xAnte = kvp.Key.x;
                    int yAnte = kvp.Key.y;
                    List<Pozitie> pozitii = kvp.Value;
                    foreach (Pozitie pozitie in pozitii)
                    {
                        int xNew = pozitie.x;
                        int yNew = pozitie.y;

                        Tabla newTabla = GenerateMovedTabla(myTabla, xAnte, yAnte, xNew, yNew);
                        int value = Minimax(newTabla, depth - 1, true);

                        bestValue = Math.Min(value, bestValue);

                    }

                    return bestValue;
                }
            }
            return 0;
        }

        public void MoveBestMove(ref Tabla myTabla)
        {
            int bestValue = int.MinValue;
            int bestXAnte=0;
            int bestYAnte=0;
            int bestXNew=0;
            int bestYNew=0;

            Dictionary<Pozitie, List<Pozitie>> possibleMoves = myTabla.getAllLegalMoves(false);

            foreach (var kvp in possibleMoves)
            {
                int xAnte = kvp.Key.x;
                int yAnte = kvp.Key.y;
                List<Pozitie> pozitii = kvp.Value;
                foreach (Pozitie pozitie in pozitii)
                {
                    int xNew = pozitie.x;
                    int yNew = pozitie.y;

                    Tabla newTabla = GenerateMovedTabla(myTabla, xAnte, yAnte, xNew, yNew);
                    int value = Minimax(newTabla, depth - 1, false);

                    if (value >= bestValue)
                    {
                        bestValue = value;

                        bestXAnte = xAnte;
                        bestYAnte = yAnte;
                        bestXNew = xNew;
                        bestYNew = yNew;

                    }

                }

            }
            myTabla.MovePiece(bestXAnte, bestYAnte, bestXNew, bestYNew);
        }
        

    }
}
