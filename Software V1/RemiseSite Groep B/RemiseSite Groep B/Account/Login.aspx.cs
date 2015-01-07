using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using RemiseSite_Groep_B.Models;
using RemiseSite_Groep_B.Classes;

namespace RemiseSite_Groep_B.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            // ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
            if (!String.IsNullOrEmpty(returnUrl))
            {
                RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (IsValid)
            {
                int MedID = DatabaseManager.Instance.Inloggen(Username.Text, Password.Text);
                Medewerker tempMed = DatabaseManager.Instance.ZoekMedewerkerOpID(MedID);
                if (!(MedID == 0))
                {
                    Session["LoggedInMedewerker"] = tempMed;
                    lblConfirm.Text = "";
                }
                else
                {
                    lblConfirm.Text = "De combinatie van username en wachtwoord die u heeft ingevult bestaan niet.";
                }
            }
        }
    }
}