using System;
using System.IO;
using System.Web;
using System.Web.Hosting;

namespace HotelWebApp.Helpers
{
    public static class ImageSaveHelper
    {
        public static string SaveImage(HttpPostedFileBase imageData)
        {
            var ext = Path.GetExtension(imageData.FileName);
            var guid = Guid.NewGuid();
            var result = guid + ext;

            var filePathOriginal = HostingEnvironment.MapPath("/Content/Images/Uploads/");
            var savedFileName = Path.Combine(filePathOriginal ?? throw new InvalidOperationException(), result);

            imageData.SaveAs(savedFileName);

            return $"/Content/Images/Uploads/{result}";
        }
    }
}