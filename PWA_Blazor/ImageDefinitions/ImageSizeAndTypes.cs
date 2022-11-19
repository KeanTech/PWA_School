namespace PWA_Blazor.ImageDefinitions
{
    public class ImageSizeAndTypes
    {
        // This class is used to represent the supported Image types and sizes
        public List<string> ImageSizes { get; set; }
        public List<string> ImageTypes { get; set; }

        public ImageSizeAndTypes()
        {
            ImageTypes = new List<string>()
            {
                ".png",
                ".jpg",
                ".jpeg",
                ".PNG",
                ".JPG",
                ".JPEG"
            };

            ImageSizes = new List<string>()
            {
                "336x280",
                "300x250",
                "250x250",
                "200x200",
                "180x150",
                "125x125",
                "120x90",
                "120x90",
                "120x60",
                "88x31"
            };
        }
    }
}
