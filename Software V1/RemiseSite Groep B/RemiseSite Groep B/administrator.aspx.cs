﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RemiseSite_Groep_B
{
    public partial class administrator : System.Web.UI.Page
    {
        List<Classes.Spoor> Sporen;

        List<Classes.Sector> sectoren;
        List<Classes.Tram> trams;

        protected void Page_Load(object sender, EventArgs e)
        {
            updateData();

            sectoren = new List<Classes.Sector>();
            trams = new List<Classes.Tram>();
            Update1();

            if (Session["LoggedInMedewerker"] == null || (Session["LoggedInMedewerker"] as Classes.Medewerker).MedewerkerType != Classes.MedewerkerType.Beheerder)
            {
                Panel1.Visible = false;
            }
            else
            {
                Panel1.Visible = true;
            }
        }

        private void updateData() 
        {
            List<Classes.Spoor> tempSporen = DatabaseManager.Instance.SporenlijstOpvragen();
            if (tempSporen != null) {
                Sporen = tempSporen;
            }
            foreach (Classes.Spoor s in Sporen) {
                foreach (Classes.Sector sec in s.Sectoren) {
                    int tramid = DatabaseManager.Instance.StaatTramOpSector(sec.Id, s.Id);
                    if (tramid == 0)
                        continue;
                    else
                        sec.Tram = new Classes.Tram(tramid, null);
                }
            }
            lvSporen.DataSource = Sporen;
            lvSporen.DataBind();
        }

        protected void btnPlace_Click(object sender, EventArgs e)
        {
            int tram;
            int spoor;
            int sector;
            try
            {
                tram = Convert.ToInt32(ddTram.SelectedItem.ToString());
            }
            catch
            {
                string script2 = "alert(\"Controleer of er een tram is geselecteerd.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
                return;
            }
            try
            {
                spoor = Convert.ToInt32(ddSpoor.SelectedItem.ToString());
            }
            catch
            {
                string script2 = "alert(\"Controleer of er een Spoor is geselecteerd.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
                return;
            }
            try
            {
                sector = Convert.ToInt32(ddSector.SelectedItem.ToString());
            }
            catch
            {
                string script2 = "alert(\"Controleer of er een Secto/r is geselecteerd.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
                return;
            }

            Classes.Sector s = new Classes.Sector(sector);
            if ((!DatabaseManager.Instance.SectorBezet(sector,spoor)) && DatabaseManager.Instance.CanTramInsert(spoor,sector))
            {
                if (DatabaseManager.Instance.TramVerplaatsen(tram, s, spoor))
                {
                    DatabaseManager.Instance.TramstatusVeranderen(Classes.TramStatus.Remise, tram);
                    string script2 = "alert(\"Tram " + tram + " is verplaatst naar Spoor:" + spoor + "Sector:" + sector + ".\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script2, true);
                    Response.Redirect("/administrator");
                }
                else
                {
                    string script3 = "alert(\"Er is iets misgegaan bij het plaatsen van de tram. Controleer of de sector niet Geblokkeerd is of bezet door een andere tram.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script3, true);
                }
            }
            else
            {
                string script3 = "alert(\"Er is iets misgegaan bij het plaatsen van de tram. Controleer of de sector niet Geblokkeerd is of bezet door een andere tram.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script3, true);
            }
            
        }

        protected void btnDel_Click(object sender, EventArgs e)
        {
            int tramnummer = Convert.ToInt32(ddTram.SelectedItem.ToString());
            if (DatabaseManager.Instance.CanTramMove(tramnummer))
            {
                Classes.Tram gekozenTram = DatabaseManager.Instance.ZoekTram(tramnummer);
                DatabaseManager.Instance.TramRijdUitRemise(tramnummer);

                if (DatabaseManager.Instance.TramstatusVeranderen(Classes.TramStatus.Dienst, gekozenTram.Id))
                {
                    string script = "alert(\"Tram " + tramnummer + " is uit Remise gereden\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    string script = "alert(\"Tram " + tramnummer + " uit remise rijden is mislukt\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            else
            {
                string script = "alert(\"De tram kan niet uitrijden doordat deze geblokkeerd is.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        void UpdateSector()
        {
            ddSector.Items.Clear();

            foreach (Classes.Sector se in sectoren)
            {
                ddSector.Items.Add(se.Id.ToString());
            }
        }

        void Update1()
        {
            trams.Clear();


            trams = DatabaseManager.Instance.AlleTrams();
            
            foreach (Classes.Tram tr in trams)
            {
                ddTram.Items.Add(tr.Nummer.ToString());
            }
            foreach (Classes.Spoor sp in Sporen)
            {
                ddSpoor.Items.Add(sp.Nummer.ToString());
            }
            foreach (Classes.Sector se in sectoren)
            {
                ddSector.Items.Add(se.Id.ToString());
            }
            
        }

        protected void ddSpoor_SelectedIndexChanged(object sender, EventArgs e)
        {
            int temp = Convert.ToInt32(ddSpoor.SelectedIndex.ToString());
            sectoren = Sporen[ddSpoor.SelectedIndex].Sectoren; //DatabaseManager.Instance.GetSectorenFromSpoorNR(temp);
            UpdateSector();
        }

        protected void btnBlok_Click(object sender, EventArgs e)
        {
            //Hier wordt gecheckt of er een sector geselecteerd is, is dit niet het geval dan zullen alle sectoren in het geselecteerde spoor geblokkeerd worden.
            if (ddSector.SelectedItem == null)
            {
                int spoornummer = Convert.ToInt32(ddSpoor.SelectedItem);
                int spoorID = -1;

                //Spoornummer wordt vertaald naar SpoorID
                foreach (Classes.Spoor s in Sporen)
                {
                    if (spoornummer == s.Nummer)
                    {
                        spoorID = s.Id;
                    }
                }

                if (DatabaseManager.Instance.BlokkeerSpoor(Convert.ToString(spoorID)))
                {
                    string script = "alert(\"Spoor is succesvol geblokkeerd\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    string script = "alert(\"Spoor blokkeren mislukt.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                updateData();
                Update1();
                return;
            }

            //SectorID wordt opgehaald uit string.
            string sectorID = Convert.ToString(ddSector.SelectedItem);
            int SpoorID = Convert.ToInt32(ddSpoor.SelectedItem.ToString());

            //Sector wordt geblokkeerd.
            if (DatabaseManager.Instance.BlokkeerSector(sectorID, SpoorID))
            {
                string script = "alert(\"Sector is succesvol geblokkeerd.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                string script = "alert(\"Sector blokkeren mislukt.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

            
            updateData();
            Update1();
        }

        protected void btnDeBlok_Click(object sender, EventArgs e)
        {
            //Hier wordt gecheckt of er een sector geselecteerd is, is dit niet het geval dan zullen alle sectoren in het geselecteerde spoor gedeblokkeerd worden.
            if (ddSector.SelectedItem == null)
            {
                int spoornummer = Convert.ToInt32(ddSpoor.SelectedItem);
                int spoorID = -1;

                //Spoornummer wordt vertaald naar SpoorID
                foreach (Classes.Spoor s in Sporen)
                {
                    if (spoornummer == s.Nummer)
                    {
                        spoorID = s.Id;
                    }
                }

                if (DatabaseManager.Instance.DeblokkeerSpoor(Convert.ToString(spoorID)))
                {
                    string script = "alert(\"Spoor is succesvol gedeblokkeerd.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    string script = "alert(\"Spoor deblokkeren mislukt.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                
                updateData();
                Update1();
                return;
            }

            //SectorID wordt opgehaald uit string.
            string sectorID = Convert.ToString(ddSector.SelectedItem);
            int spoorNR = Convert.ToInt32(ddSpoor.SelectedItem.ToString());

            //Sector wordt gedeblokkeerd.
            if (DatabaseManager.Instance.DeblokkeerSector(sectorID,spoorNR))
            {
                string script = "alert(\"Sector is succesvol gedeblokkeerd\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                string script = "alert(\"Sector deblokkeren mislukt.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }

            
            updateData();
            Update1();
        }
    }
}