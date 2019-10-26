using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WhenWillIGetThere.Commute
{
    public partial class StartStop : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            using (var db = new Entities())
            {
                var userName = User.Identity.Name;

                var defaultRoute = from r in db.Routes
                                   join u in db.AspNetUsers on r.UserId equals u.Id
                                   where u.UserName == userName
                                   select new { RouteId = r.Id };

                var c = new Commutes();
                c.RouteId = defaultRoute.First().RouteId;
                c.Start = DateTime.Now;
                db.Commutes.Add(c);
                db.SaveChanges();
            }
            Refresh();
        }

        protected void btnStop_Click(object sender, EventArgs e)
        {
            if (hidCommuteId.Value != string.Empty)
            {
                using (var db = new Entities())
                {
                    var c = db.Commutes.Find(int.Parse(hidCommuteId.Value));
                    c.Stop = DateTime.Now;
                    db.SaveChanges();
                }
                Refresh();
            }
        }

        private void Refresh()
        {
            using (var db = new Entities())
            {
                var userName = User.Identity.Name;

                var startedCommutes = from c in db.Commutes
                                      join r in db.Routes on c.RouteId equals r.Id
                                      join u in db.AspNetUsers on r.UserId equals u.Id
                                      where u.UserName == userName && c.Stop.HasValue == false
                                      orderby c.Start
                                      select new { CommuteId = c.Id, r.Name, c.Start };

                if (startedCommutes.Any())
                {
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    var r = startedCommutes.First();
                    hidCommuteId.Value = r.CommuteId.ToString();
                    lblRoute.Text = "Route: " + System.Web.HttpUtility.HtmlEncode(r.Name);
                    lblStart.Text = "An commute counter is currently running, started on " + r.Start.ToString();
                }
                else
                {
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    hidCommuteId.Value = string.Empty;
                    lblRoute.Text = string.Empty;
                    lblStart.Text = string.Empty;
                }
            }
        }
    }
}