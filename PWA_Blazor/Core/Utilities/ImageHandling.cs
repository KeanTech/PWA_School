using Microsoft.AspNetCore.Components.Forms;
using PWA_Blazor.ImageDefinitions;
using PWA_Blazor.Models;

namespace PWA_Blazor.Core.Utilities
{
    public class ImageHandling
    {
        private static ImageSizeAndTypes imageSizeAndTypes = new ImageSizeAndTypes();

        /// <summary>
        /// User need to select an image from file selection dialog for this to work 
        /// 
        /// dialog anwser in not needed but just a way for user to define the upload..
        /// 
        /// Used to generate the table in the UploadPictures page.
        /// </summary>
        /// <param name="file"></param>
        /// <param name="dialogAnwser"></param>
        /// <returns></returns>
        public static async Task<ImageFile> GetImageFile(IBrowserFile file, DialogAnwser dialogAnwser) 
        {
            ImageFile imageFile = new ImageFile();

            if (string.IsNullOrEmpty(dialogAnwser.ImageName))
                imageFile.FileName = file.Name;

            else
                imageFile.FileName = dialogAnwser.ImageName;

            if (string.IsNullOrEmpty(dialogAnwser.ImageType))
                imageFile.ContentType = file.ContentType;

            else
                imageFile.ContentType = dialogAnwser.ImageType;

            imageFile = await GenerateImageString(file, dialogAnwser, imageFile);

            return imageFile;
        }

        /// <summary>
        /// User have to select an image for this method to work aka IBrowserFile
        /// 
        /// Dialog anwser is used if user wants to change Image Name, Size and Type
        /// 
        /// 
        /// This method is used in ImageHandler GetImage to get the image as base64 and the file size in bytes 
        /// </summary>
        /// <param name="file"></param>
        /// <param name="anwser"></param>
        /// <param name="imageFile"></param>
        /// <returns></returns>
        private static async Task<ImageFile> GenerateImageString(IBrowserFile file, DialogAnwser anwser, ImageFile imageFile) 
        {
            IBrowserFile resizedFile;
            int[] sizes = GetImageSizes(anwser);

            //resize the image and create the thumbnails
            if(string.IsNullOrEmpty(anwser.ImageType))
                resizedFile = await file.RequestImageFileAsync(file.ContentType, sizes[0], sizes[1]); // resize the image file
            else
                resizedFile = await file.RequestImageFileAsync(anwser.ImageType, sizes[0], sizes[1]);

            var buf = new byte[resizedFile.Size]; // allocate a buffer to fill with the file's data
            using (var stream = resizedFile.OpenReadStream())
            {
                await stream.ReadAsync(buf); // copy the stream to the buffer
            }

            imageFile.Base64data = "data:image/png;base64," + Convert.ToBase64String(buf); // convert to a base64 string!!
            imageFile.FileSize = resizedFile.Size;

            return imageFile;
        }

        /// <summary>
        /// Used in ImageHandling to get the Image width and height
        /// 
        /// Uses the Dialog to get the dimentions and have a default size if nothing is selected
        /// 
        /// 
        /// So no need for a preselected size
        /// </summary>
        /// <param name="anwser"></param>
        /// <returns></returns>
        private static int[] GetImageSizes(DialogAnwser anwser) 
        {
            int[] imageSizes = new int[2];
            string[] sizes;
            if (string.IsNullOrEmpty(anwser.ImageSize) == false)
            {
                sizes = anwser.ImageSize.Split('x');
            }
            else
                sizes = imageSizeAndTypes.ImageSizes[0].Split('x');

            imageSizes[0] = int.Parse(sizes[0]);
            imageSizes[1] = int.Parse(sizes[1]);

            return imageSizes;
        }

    }
}
