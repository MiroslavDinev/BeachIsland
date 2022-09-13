namespace BeachIsland.Server.Services.Implementation
{
    using BeachIsland.Server.Enums;
    using BeachIsland.Server.Services.Interfaces;

    public class ImageService : IImageService
    {
        private string _path;

        public ImageService(string path)
        {
            _path = path;
        }

        public void AddImage(byte[] byteFile, string fileType, int mainEntityId, ImageCategory imageCategory)
        {
            var imagePath = _path + $"\\{imageCategory}";

            var fileName = $"{mainEntityId}.{fileType}";
            var filePath = Path.Combine(imagePath, fileName);

            using (var streamReader = new MemoryStream(byteFile))
            {
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    var buffer = new byte[4096];
                    var bytesRead = 0;
                    while ((bytesRead = streamReader.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, bytesRead);
                    }

                    streamReader.Position = 0;
                }
            }
        }

        public byte[] GetImage(int mainEntityImageId, string fileType, ImageCategory imageCategory)
        {
            var imagePath = _path + $"\\{imageCategory}";

            byte[] buffer = null;

            var imageName = mainEntityImageId + "." + fileType;

            using (FileStream fs = new FileStream($@"{imagePath}\{imageName}", FileMode.Open, FileAccess.Read))
            {
                buffer = new byte[fs.Length];
                fs.Read(buffer, 0, (int)fs.Length);
            }
            return buffer;
        }
    }
}
