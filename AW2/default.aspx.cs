using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AW2
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Messages by date descending
        protected void btnNew_Click(object sender, EventArgs e)
        {
            listMessages(Convert.ToChar("n"));
        }

        //Messages by date ascending
        protected void btnOld_Click(object sender, EventArgs e)
        {
            listMessages(Convert.ToChar("o"));
        }

        //Messages in random order
        protected void btnRnd_Click(object sender, EventArgs e)
        {
            listMessages(Convert.ToChar("r"));
        }

        //List stored messages to GUI
        void listMessages(char S)
        {
            try
            {
               using (messagesDataClassesDataContext Data = new messagesDataClassesDataContext())
               {
                   //SP to get messages in selected order
                   var msgs = Data.spRnd(S);

                   //Adds messages to GUI with some formatting for readabilty
                   foreach (spRndResult m in msgs)
                   {
                       Literal dynLiteralFirst = new Literal();
                       dynLiteralFirst.ID = "LiteralFirst" + m.messageID.ToString();
                       dynLiteralFirst.Text =   "<div class=\"Container\">"
                                              + "<div class=\"row\">"
                                              + "<div class=\"col-md-3\">"
                                              + "</div>"
                                              + "<div class=\"col-md-3\">";

                       Literal dynLiteralDateTime = new Literal();
                       dynLiteralDateTime.ID = "LiteralDatetime_" + m.messageID.ToString();
                       dynLiteralDateTime.Text = m.messageDateTime.ToString();

                       Literal dynLiteralMid1 = new Literal();
                       dynLiteralMid1.ID = "dynLiteralMid1" + m.messageID.ToString();
                       dynLiteralMid1.Text = "</div>"
                                              + "<div class=\"col-md-5\">";

                       Literal dynLiteralText = new Literal();
                       dynLiteralText.ID = "LiteralText_" + m.messageID.ToString();
                       dynLiteralText.Text = m.messageText;

                       Literal dynLiteralMid2 = new Literal();
                       dynLiteralMid2.ID = "dynLiteralMid2" + m.messageID.ToString();
                       dynLiteralMid2.Text = "</div>"
                                              + "</div>"
                                              + "<div class=\"row\">";

                       Literal dynLiteralHR = new Literal();
                       dynLiteralHR.ID = "Literalhr_" + m.messageID.ToString();
                       dynLiteralHR.Text = "<hr class=\"ruler\">";

                       Literal dynLiteralEnd = new Literal();
                       dynLiteralEnd.ID = "dynLiteralEnd" + m.messageID.ToString();
                       dynLiteralEnd.Text =     "</div>"
                                              + "</div>";

                       panelMessages.Controls.Add(dynLiteralFirst); 
                       panelMessages.Controls.Add(dynLiteralDateTime);
                       panelMessages.Controls.Add(dynLiteralMid1);
                       panelMessages.Controls.Add(dynLiteralText);
                       panelMessages.Controls.Add(dynLiteralMid2);
                       panelMessages.Controls.Add(dynLiteralHR);
                       panelMessages.Controls.Add(dynLiteralEnd);

                   }
               }

            }
            //Some error handling and user feedback in case of error
            catch (Exception e)
            {
                Literal dynLiteralFail = new Literal();
                dynLiteralFail.ID = "dynLiteralFail";
                dynLiteralFail.Text =   "<h3>Något gick fel vid läsning från databasen." 
                                        + " Försök igen! Nedanstående felmeddelande genereras i felsökningssyfte"
                                        + "</h3><br>";

                Literal dynLiteralStackTrace = new Literal();
                dynLiteralFail.ID = "dynLiteralStackTrace";
                dynLiteralFail.Text = "<p>"
                                       + e.StackTrace.ToString()
                                       + "</p>";

                panelMessages.Controls.Add(dynLiteralFail);
                panelMessages.Controls.Add(dynLiteralStackTrace);

            }
        }
    
    }
}