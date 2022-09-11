namespace BeachIsland.Server.Extensions
{
    public static class GetByteArrayExtension
    {
        public static byte[] GetByteFromFileStream(this IFormFile file)
        {
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                var fileBytes = ms.ToArray();
                return fileBytes;
            }
        }
    }
}
