using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Empty
{
    public partial class AjaxWebForm_1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AspTimer2_Tick(object sender, EventArgs e)
        {
            AnotherTimer.Text = DateTime.Now.ToString(CultureInfo.CurrentCulture);
        }
    }
}