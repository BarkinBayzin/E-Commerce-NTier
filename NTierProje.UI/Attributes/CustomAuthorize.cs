using NTier.Model.Entities;
using NTier.Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NTierProje.UI.Attributes
{
    //Auth işlemlerinin Enum ile gerçekleşebilmesi için bu sınıfı kullanıyoruz.
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, Inherited = true, AllowMultiple = true)]//Allow multiple ile birden fazla rol giriş olabiliyor.
    public class CustomAuthorize:AuthorizeAttribute
    {
        //string dizi rolleri tutmak için
        string[] userProfilesRequired { get; set; }

        public CustomAuthorize(params object[] userProfilersRequired)
        {
            if (userProfilersRequired.Any(p => p.GetType().BaseType != typeof(Enum)))
                throw new ArgumentException("User Profiles Required");

            this.userProfilesRequired = userProfilersRequired.Select(p => Enum.GetName(typeof(Role), p)).ToArray();
        }

        public override void OnAuthorization(AuthorizationContext context)
        {
            bool authorized = false;

            //Kullanıcı rolü yakalanıyor.
            AppUserService service = new AppUserService();

            AppUser user = service.FindByUsername(HttpContext.Current.User.Identity.Name);
            string userRole = Enum.GetName(typeof(Role), user.Role);

            //Kullanıcı belirtilen rollerden birine uyuyorsa devam edebilir.

            foreach (var role in this.userProfilesRequired)
            {
                if(userRole == role)
                {
                    authorized = true;
                    break;
                }
            }

            //Eğer uymuyorsa Home/Index sayfasına yönlendirilir.
            if (!authorized)
            {
                var url = new UrlHelper(context.RequestContext);
                var loginUrl = url.Action("Index", "Home", new { Id = 302, Area = "" });
                context.Result = new RedirectResult(loginUrl);

                return;
            }
        }
    }
}