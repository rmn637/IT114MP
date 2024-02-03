using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        public string opt1class { get { return opt1.CssClass; } set { opt1.CssClass = value; } }
        public string opt2class { get { return opt2.CssClass; } set { opt2.CssClass = value; } }
        public string opt3class { get { return opt3.CssClass; } set { opt3.CssClass = value; } }
        public string opt4class { get { return opt4.CssClass; } set { opt4.CssClass = value; } }

        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}