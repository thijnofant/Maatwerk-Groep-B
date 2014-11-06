using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    class Medewerker
    {
        public MedewerkerType MedewerkerType { get; private set; }
        public int Id { get; private set; }
        public string Naam { get; private set; }
        public List<Beurt> UitgevoerdeBeurten { get; private set; }

        public Medewerker(int id, string naam, MedewerkerType medewerkerType) 
        {
            this.MedewerkerType = medewerkerType;
            this.Naam = naam;
            this.Id = id;

            if (medewerkerType == MedewerkerType.Schoonmaker || medewerkerType == MedewerkerType.Technicus) 
            {
                UitgevoerdeBeurten = new List<Beurt>();
            }
        }

        public override string ToString()
        {
            return Id + ". " + Naam;
        }
    }
}
