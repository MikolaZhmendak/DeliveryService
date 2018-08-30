using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;
using System.Web.UI.WebControls;
using System.Net.Mail;
using System.Net;
using System.Drawing;

namespace DeliveryService
{
    public partial class index : System.Web.UI.Page
    {
        protected void Home (object sender, EventArgs e)
        {
            Response.Redirect("~/Employers/Home");

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            Button2.Style.Add("background-color", "red");

        }

        protected void send_Click(object sender, EventArgs e)
        {
          

            try
            {


                MailMessage ms = new MailMessage(to.Text, from.Text, subject.Text, body.Text);

                if(fileUpload1.HasFile)
                {
                    string FileName = Path.GetFileName(fileUpload1.PostedFile.FileName);
                    ms.Attachments.Add(new Attachment(fileUpload1.PostedFile.InputStream, FileName));
                }
                ms.IsBodyHtml = true;

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential("zhmendakm@gmail.com", "Soccer2018$");
                client.Send(ms);
            }

            catch  (Exception ex)
            {
                status.Text = ex.StackTrace;
            }





            status.Text = "E-mail was send succesfully";
        }
    }
}