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

        public int Id { get; private set; }
        public List<Sector> Sectoren { get; private set; }
        public List<Lijn> Lijnen { get; private set; }

        public Spoor(int id, List<Sector> sectoren, List<Lijn> lijnen) 
        {
            this.id = id;
            this.sectoren = sectoren;
            this.lijnen = lijnen;
        }

        public void Blokkeren() 
        {
            throw new NotImplementedException();
        }
    }
}
