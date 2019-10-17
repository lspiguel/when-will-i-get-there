using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhenWillIGetThere.Commute
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using(var db = new Entities())
            {
                var userName = User.Identity.Name;

                var query = from c in db.Commutes
                            join r in db.Routes on c.RouteId equals r.Id
                            join u in db.AspNetUsers on r.UserId equals u.Id
                            where u.UserName == userName
                            orderby c.Start
                            select new { RouteName = r.Name, c.Start, c.Stop };

                GridView1.DataSource = query.ToList();
                GridView1.DataBind();
            }
        }
    }
}