using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemiseSysteem_Groep_B
{
    /// <summary>
    /// Deze Klasse Becat informatie over een tram type.
    /// </summary>
    class TramType
    {
        /// <summary>
        /// Dit is de naam van het type.
        /// </summary>
        public string Naam { get; private set; }

        /// <summary>
        /// Dit is de lengte in sectoren die een type heeft. Deze is momenteel voor alle types 1 maar dit kan in de toekomst aangepast worden in de Database.
        /// </summary>
        public double Lengte { get; private set; }

        /// <summary>
        /// Dit is een lijst van alle lijnen waar dit type trams op word gebruikt.
        /// </summary>
        public List<Lijn> WordtGebruiktOp { get; private set; }

        /// <summary>
        /// Dit is de Constructor van deze Klasse.
        /// </summary>
        /// <param name="naam">De Naam van het TramType.</param>
        /// <param name="lengte">De Lengte in Sectoren van dit TramType.</param>
        public TramType(string naam, double lengte)
        {
            this.Naam = naam;
            this.Lengte = lengte;
            WordtGebruiktOp = new List<Lijn>();
        }
    }
}
