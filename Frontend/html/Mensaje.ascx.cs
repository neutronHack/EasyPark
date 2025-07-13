using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EasyPark.Frontend.html
{
    public partial class WebUserControl1 : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnCloseMsg_Click(object sender, EventArgs e)
        {
            pnlMessage.Visible = false;
        }

        public void Title(string title)
        {
            Header.Text = title;
            pnlMessage.Visible = true;

        }

        public void ContentMsg(string content)
        {
            Content.Text = content;
            pnlMessage.Visible = true;

        }
    }
}