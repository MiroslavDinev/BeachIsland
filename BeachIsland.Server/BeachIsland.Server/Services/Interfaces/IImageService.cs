namespace BeachIsland.Server.Services.Interfaces
{
    using BeachIsland.Server.Enums;

    public interface IImageService
    {
        void AddImage(byte[] byteFile, string fileType, int mainEntityId, ImageCategory imageCategory);
        void DeleteImages(int mainEntityImageId, ImageCategory imageCategory);
        byte[] GetImage(int mainEntityImageId, string fileType, ImageCategory imageCategory);
    }
}
