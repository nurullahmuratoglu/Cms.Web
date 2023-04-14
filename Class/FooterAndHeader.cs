using Cms.Web.Models;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Cms.Web.Class
{
    public static class FooterAndHeader
    {
        public static void AddAdminLayoutInfo(this ViewDataDictionary viewData, AppDbContext context)
        {
            var adminLayout = context.AdminLayouts.FirstOrDefault(x => x.Id == 1);

            if (adminLayout != null)
            {
                viewData["Email"] = adminLayout.Email;
                viewData["PhoneNumber"] = adminLayout.PhoneNumber;
                viewData["Location"] = adminLayout.Location;
                viewData["Twitter"] = adminLayout.Twitter;
                viewData["Facebook"] = adminLayout.Facebook;
                viewData["Linkedn"] = adminLayout.Linkedn;
                viewData["FooterText"] = adminLayout.FooterText;
            }
        }
    }
}