namespace BeachIsland.Server.Extensions
{
    public static class ImageExtensionHelper
    {
        private static readonly string[] allowedExtensions = new[] { "jpg", "png", "jpeg" };
        private static readonly int ImageMaxSize = 1024 * 1024;

        public static bool IsValidImageFile(this IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName).TrimStart('.').ToLower();

            if (!allowedExtensions.Any(x => extension.EndsWith(x)))
            {
                return false;
            }

            return true;
        }

        public static bool ValidateImageSize(this IFormFile file)
        {
            var fileSize = file.Length;

            if (fileSize > ImageMaxSize)
            {
                return false;
            }

            return true;
        }
    }
}
