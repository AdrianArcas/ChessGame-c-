using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_Project
{
    public class AI
    {
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
    }
}
