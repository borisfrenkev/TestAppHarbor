using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;

namespace WebApplication1.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = new UserManager();
            byte[] imgArr = null;
            
          //  FileUpload fu = this.Fileupload as FileUpload;
            if (this.Fileupload.HasFile)
            {
                int length = this.Fileupload.PostedFile.ContentLength;
                byte[] temp = new byte[length];
                HttpPostedFile img= this.Fileupload.PostedFile;
                img.InputStream.Read(temp, 0, length);
                imgArr = temp;
            }
            MyUserInfo userInfo = new MyUserInfo
            {
                FirstName=this.FirstName.Text,
                LastName=this.LastName.Text,
                Image = imgArr
            };

            var user = new ApplicationUser() { UserName = UserName.Text, MyUserInfo = userInfo };
            IdentityResult result = manager.Create(user, Password.Text);
        
            if (result.Succeeded)
            {
                IdentityHelper.SignIn(manager, user, isPersistent: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}