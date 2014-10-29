using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Spoor
    {
        private int id;
        private List<Sector> sectoren;
        private List<Lijn> lijnen;

        public int Id { get { return id; } }
        public List<Sector> Sectoren { get { return sectoren; } }
        public List<Lijn> Lijnen { get { return lijnen; } }

        public Spoor(int id, List<Sector> sectoren, List<Lijn> lijnen)
        {
            this.id = id;
            this.sectoren = sectoren;
            this.lijnen = lijnen;
        }

        public void Blokkeren()
        {

        }
    }
}
