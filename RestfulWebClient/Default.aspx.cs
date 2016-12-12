using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Text;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
          
    }

    protected void ButtonGetAnEmployee_Click(object sender, EventArgs e)
    {
        string ResponseStr = "";
        string uri = "http://localhost:8038/EmployeeService/GetAnEmployee/";
        string id = "3550"; //parametreden alinabilir
        try
        {
            string Method = "GET";
            string uriStr = uri + "/" + id;

            HttpWebRequest req = WebRequest.Create(uriStr) as HttpWebRequest;
            req.KeepAlive = false;
            req.Method = Method.ToUpper();

            HttpWebResponse resp = req.GetResponse() as HttpWebResponse;
            Encoding enc = System.Text.Encoding.GetEncoding(1254);
            StreamReader loResponseStream = new StreamReader(resp.GetResponseStream(), enc);

            ResponseStr = loResponseStream.ReadToEnd();

            loResponseStream.Close();
            resp.Close();
            TextBoxExp.Text = ResponseStr;
        }
        catch (Exception ex)
        {

            TextBoxExp.Text = "ERROR : " + ex.Message.ToString();
        }

       
    }
}