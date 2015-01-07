using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemiseSite_Groep_B
{
    public partial class Reserveren : System.Web.UI.Page
    {
        DatabaseManager db = DatabaseManager.Instance;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //Panel1.Visible = false;
            String[] temp = DatabaseManager.Instance.GetAllReserveringen();
            lbReserveringen.Items.Clear();
            for (int i = 0; i < temp.Count(); i++)
            {
                lbReserveringen.Items.Add(temp[i]);
            }
        }

        protected void cbReparatie_CheckedChanged(object sender, EventArgs e)
        {
            if (Panel1.Visible == true)
            {
                Panel1.Visible = false;
                this.Response.Redirect("~/Reserveren.aspx");
            }
            else
            {
                Panel1.Visible = true;
                this.Response.Redirect("~/Reserveren.aspx");
            }
        }

        protected void btnBevestig_Click(object sender, EventArgs e)
        {
            Classes.Tram tram = db.ZoekTram(Convert.ToInt32(tbTramnr.Text));//haalt tram op uit de database
            int spoornr = Convert.ToInt32(tbSpoornr.Text);
            if (db.TramReserveren(tram.Id, spoornr))//reserveerd de tram in de database
            {
                lblMessage.Text = "De reservering is aangemaakt.";
            }
            else
            {
                lblMessage.Text = "Er is iets misgegaan met het reserveren van de tram. Probeer het opnieuw.";
            }
            Classes.BeurtType type = Classes.BeurtType.Klein;
            int aantalToegestaandeBeurten = 0;

            //het onderstaande wordt enkel uitgevoerd wanneer er ook is gekozen reparatie
            if (cbReparatie.Checked)
            {
                if (rbGroot.Checked)//voor grote reparatie
                {
                    type = Classes.BeurtType.Groot;
                    aantalToegestaandeBeurten = 1;
                }
                if (rbKlein.Checked)//voor kleine reparatie
                {
                    type = Classes.BeurtType.Klein;
                    aantalToegestaandeBeurten = 4;
                }
                
                DateTime datum = Convert.ToDateTime(Calendar1.SelectedDate);//geseleceteerde datum
                Classes.Onderhoud onderhoud = new Classes.Onderhoud(datum, db.GetInsertID("ID", "TRAM_BEURT") + 1, type, tram, DateTime.Now.AddDays(1.0));//nieuw onderhoud object.

                if (tram != null)
                {
                    if (db.GetAantalBeurten(type.ToString(), "Onderhoud", datum, tram.Id) < aantalToegestaandeBeurten)// kijkt of aantal gebeurde beurten niet het aantaal toegestane beurten overschrijd
                    {
                        db.OnderhoudInvoeren(onderhoud);//maakt reparatie aan in de database
                        lblMessage.Text = "De Tram is gereserveerd voor onderhoud.";
                        Response.Redirect("/Reserveren");
                    }
                    else
                    {
                        lblMessage.Text = "De geselecteerde tram kan niet meer worden ingepland op de geselecteerde dag";
                    }
                }
                else
                {
                    lblMessage.Text = "De ingevoerde tram bestaat niet";
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
        }
    }
}