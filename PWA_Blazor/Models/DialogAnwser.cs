namespace PWA_Blazor.Models
{
    public class DialogAnwser
    {
        /// <summary>
        /// This string is nullable 
        /// 
        /// Because it uses the default contructor
        /// </summary>
        public string? ImageName { get; set; }
        public string? ImageType { get; set; }
        public string? ImageSize { get; set; }
        public bool ButtonClicked { get; set; }
    }
}
