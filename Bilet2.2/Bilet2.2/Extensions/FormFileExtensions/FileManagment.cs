using Bilet2._2.ViewModels.TeamMemberViewModels;

namespace Bilet2._2.Extensions.FormFileExtensions
{
    public static class FileManagment
    {
        public static bool IsTrueContent(this IFormFile formFile)
        {
            if (formFile.ContentType.Contains("image"))
            {
                return true;
            }
            return false;
        }
        public static bool IsValidLength(this IFormFile formFile)
        {
            if(formFile.Length <= 2 * 1024 * 1024)
            {
                return true;
            }
            return false;
        }
        public static string SaveUrl(this IFormFile formFile, string env, string root)
        {
            string ImageName = $"{Guid.NewGuid().ToString()}{formFile.FileName}";
            string imageUrl = Path.Combine(env,root,ImageName);
            using(FileStream fileStream = new FileStream(imageUrl, FileMode.Create))
            {
               formFile.CopyTo(fileStream);
            }
            return imageUrl;
        }
        public static void DeleteUrl(string env,string folderPath,string imageUrl)
        {
            string existFile = Path.Combine(env,folderPath,imageUrl);
            if (File.Exists(existFile))
            {
                File.Delete(existFile);
            }
        }
    }
}
