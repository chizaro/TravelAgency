using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;

namespace TravelAgency.Web.Managers
{
    public static class ImageManager
    {
        private static readonly string imagePath;

        static ImageManager()
        {
            imagePath = ConfigurationManager.AppSettings["imagePath"];
        }

        public static string SaveImage(HttpPostedFileBase image)
        {
            string fileName = string.Concat(Guid.NewGuid().ToString(), Path.GetExtension(image.FileName));
            image.SaveAs(HttpContext.Current.Server.MapPath(string.Concat(imagePath, fileName)));
            return fileName;
        }

        public static void DeleteImage(string imageName)
        {
            if (File.Exists(HttpContext.Current.Server.MapPath(string.Concat(imagePath, imageName))))
                File.Delete(HttpContext.Current.Server.MapPath(string.Concat(imagePath, imageName)));
        }
    }
}