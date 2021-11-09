namespace Samson.Web.Application.Infrastructure.ViewModels
{
    /// <summary>
    /// View model to store 2D values.
    /// </summary>
    public class DimensionViewModel
    {
        public int Height { get; set; }
        public int Width { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="height">Height dimension</param>
        /// <param name="width">Width dimension</param>
        public DimensionViewModel(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
