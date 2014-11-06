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
    class TramType
    {
        /// <summary>
        /// 
        /// </summary>
        public string Naam { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public double Lengte { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<Lijn> WordtGebruiktOp { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="naam"></param>
        /// <param name="lengte"></param>
        public TramType(string naam, double lengte)
        {
            this.Naam = naam;
            this.Lengte = lengte;
            WordtGebruiktOp = new List<Lijn>();
        }
    }
}
