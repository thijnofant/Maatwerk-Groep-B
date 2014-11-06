using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    /// <summary>
    /// 
    /// </summary>
    class Medewerker
    {
        /// <summary>
        /// 
        /// </summary>
        public MedewerkerType MedewerkerType { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string Naam { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Beurt> UitgevoerdeBeurten { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="naam"></param>
        /// <param name="medewerkerType"></param>
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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Id + ". " + Naam;
        }
    }
}
