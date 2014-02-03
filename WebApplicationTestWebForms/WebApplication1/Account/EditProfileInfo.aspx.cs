using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace WebApplication1.Account
{
    public partial class EditProfileInfo : System.Web.UI.Page
    {
      
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                using (var dbContext = new ApplicationDbContext())
                {   
                    var userId=User.Identity.GetUserId();
                    ApplicationUser user= dbContext.Users.Where(x=>x.Id==userId).FirstOrDefault();
                    MyUserInfo info = user.MyUserInfo;
                    this.firstName.Text = info.FirstName;
                    this.lastName.Text = info.LastName;
                }
            }
        }

        protected void EditProfileInfo_Click(object sender, EventArgs e)
        {
            using (var dbContext = new ApplicationDbContext())
            {
                var userId = User.Identity.GetUserId();
                ApplicationUser user = dbContext.Users.Where(x => x.Id == userId).FirstOrDefault();
                MyUserInfo info = user.MyUserInfo;
                info.FirstName = this.firstName.Text;
                info.LastName = this.lastName.Text;
                try
                {
                    dbContext.SaveChanges();
                }
                catch (Exception)
                {
                    
                  
                }

                Response.Redirect("~/Default.aspx");
            }
        }
    }
}