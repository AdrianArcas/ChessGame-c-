using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_Project
{
    public class Casuta
    {
        private Piesa piesa;
        private bool isOcupat;
        private bool isLegal;
        private bool isAtacat;


        public bool GetisAtacat()
        {
            return isAtacat;
        }

        public void SetisAtacat(bool value)
        {
            isAtacat = value;
        }


        public Piesa GetPiesa()
        {
            return piesa;
        }

        public void SetPiesa(Piesa value)
        {
            piesa = value;
        }


        public bool GetIsOcupat()
        {
            return isOcupat;
        }

        public void SetIsOcupat(bool value)
        {
            isOcupat = value;
        }



        public bool GetIsLegal()
        {
            return isLegal;
        }

        public void SetIsLegal(bool value)
        {
            isLegal = value;
        }

        public Casuta(bool isOcupat = false, bool isLegal = false, Piesa piesa = null, bool isAtacat = false)
        {
            SetPiesa(piesa);
            SetIsLegal(isLegal);
            SetIsOcupat(isOcupat);
            SetisAtacat(isAtacat);

        }


    }
}
