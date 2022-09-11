namespace BeachIsland.Server.Services.Interfaces
{
    using BeachIsland.Server.Enums;

    public interface IImageService
    {
        void AddImage(byte[] byteFile, string fileType, int mainEntityId, ImageCategory imageCategory);
    }
}
