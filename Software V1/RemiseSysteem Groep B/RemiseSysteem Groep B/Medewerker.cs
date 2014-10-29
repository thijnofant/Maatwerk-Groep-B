using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Medewerker
    {
        private MedewerkerType medewerkerType;
        private int id;
        private string naam;
        private List<Beurt> uitgevoerdeBeurten;

        public MedewerkerType MedewerkerType { get; private set; }
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public List<Beurt> UitgevoerdeBeurten { get; private set; }

        public Medewerker(int id, string naam, MedewerkerType medewerkerType) 
        {
            this.medewerkerType = medewerkerType;
            this.naam = naam;
            this.id = id;

            if (medewerkerType == MedewerkerType.Schoonmaker || medewerkerType == MedewerkerType.Technicus) 
            {
                uitgevoerdeBeurten = new List<Beurt>();
            }
        }
    }
}
