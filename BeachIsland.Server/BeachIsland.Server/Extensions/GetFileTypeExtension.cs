namespace BeachIsland.Server.Extensions
{
    public static class GetFileTypeExtension
    {
        public static string GetFileType(this IFormFile file)
        {
            var startIndex = file.FileName.IndexOf(".");

            var endIndex = file.FileName.Length - startIndex - 1;

            return file.FileName.Substring(startIndex + 1, endIndex);

        }
    }
}
