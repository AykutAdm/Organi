namespace Organi.WebUI.DTOs.ProductNutritionDtos
{
    public class CreateProductNutritionDto
    {
        public int ProductId { get; set; }
        public string ServingSize { get; set; }
        public string Energy { get; set; }
        public string Fat { get; set; }
        public bool Carbohydrates { get; set; }
        public decimal Protein { get; set; }
        public string Note { get; set; }
    }
}
