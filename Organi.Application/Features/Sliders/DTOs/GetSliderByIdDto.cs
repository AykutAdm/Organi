namespace Organi.Application.Features.Sliders.DTOs
{
    public class GetSliderByIdDto
    {
        public int SliderId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
