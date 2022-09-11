namespace BeachIsland.Server.Infrastructure.Exceptions
{
    public class ImageSizeExceedException : Exception
    {
        public ImageSizeExceedException(string message)
            : base(message)
        { }

        public ImageSizeExceedException()
            : base("The maximum allowed image size is 1 MB")
        { }
    }
}
