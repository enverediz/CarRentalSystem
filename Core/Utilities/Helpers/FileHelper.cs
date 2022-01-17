using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers
{
    public class FileHelper
    {
        public static (string newPath, string Path2) newPath(IFormFile formFile)
        {
            FileInfo fileInfo = new FileInfo(formFile.FileName);
            string fileExtension = fileInfo.Extension;

            var creatingUniqueFileName = Guid.NewGuid().ToString("N") + "_" + DateTime.Now.Month + "_"
                + DateTime.Now.Day + "_" + DateTime.Now.Year + fileExtension;

            string path = Environment.CurrentDirectory + @"\wwwroot\CarImages";

            string result = $@"{path}\{creatingUniqueFileName}";

            return (result, $"\\CarImages\\{creatingUniqueFileName}");
        }

        public static string Add(IFormFile formFile)
        {
            var result = newPath(formFile);
            try
            {
                var sourcepath = Path.GetTempFileName();
                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(sourcepath, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }
                File.Move(sourcepath, result.newPath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result.Path2;
        }

        public static string Update(string sourcepath, IFormFile formFile)
        {
            var result = newPath(formFile);
            try
            {
                if (sourcepath.Length > 0)
                {
                    using (var stream = new FileStream(result.newPath, FileMode.Create))
                    {
                        formFile.CopyTo(stream);
                    }
                }
                File.Delete(sourcepath);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
            return result.Path2;
        }

        public static IResult Delete(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (Exception exception)
            {
                return new ErrorResult(exception.Message);
            }
            return new SuccessResult();
        }
    }
}
