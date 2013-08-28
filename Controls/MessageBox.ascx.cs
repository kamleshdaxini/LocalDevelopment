using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    // To set message to display
    public String Msg
    {
        get;//to get message
        set;// to set proper message
    }

    // To dispay message on popup
    public void showmsg()
    {
        lblmsg.Text = Msg;
        mpop.Show();
    }

    // To hide popup on cancel button  
    protected void btnok_Click(object sender, EventArgs e)
    {
        mpop.Hide();
    }
}