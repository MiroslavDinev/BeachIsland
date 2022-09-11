namespace BeachIsland.Server.Infrastructure.Exceptions
{
    public class ImageNotSupportedFormatException : Exception
    {
        public ImageNotSupportedFormatException(string message)
            : base(message)
        { }

        public ImageNotSupportedFormatException()
            : base("The supported image formats are .jpg, .jpeg and .png")
        { }
    }
}
