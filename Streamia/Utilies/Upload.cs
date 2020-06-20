using Microsoft.AspNetCore.Hosting;
using Streamia.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Streamia.Utilies
{
    public static class Upload
    {
        public static string UploadProfilePicture(RegisterViewModel model, IWebHostEnvironment _hostingEnviroment)
        {
            string uniqueFileName = null;
            if (model.ProfilePicture != null)
            {
                // ~/wwwroot/Pictures
                string UploadsFolder = Path.Combine(_hostingEnviroment.WebRootPath, "Pictures");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfilePicture.FileName;
                //~/wwwroot/Pictures/uniqueFileName
                string FilePath = Path.Combine(UploadsFolder, uniqueFileName);

                using (var fileStream = new FileStream(FilePath, FileMode.Create))
                {
                    try
                    {
                        model.ProfilePicture.CopyTo(fileStream);
                    }
                    catch (Exception)
                    {
                        return null;
                    }
                }
            }
            return uniqueFileName;
        }

    }
}
