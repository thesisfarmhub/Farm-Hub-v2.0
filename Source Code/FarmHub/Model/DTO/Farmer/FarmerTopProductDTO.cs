using System;

namespace Model.DTO.Farmer
{
    public class FarmerTopProductDTO
    {
        // FARMER 

        public int? Id_Farm { get; set; }

        public int? Id_ProductDetail { get; set; }

        public string Name_Product { get; set; }

        public string Name_Seed { get; set; }

        public int? Price_Offer { get; set; }

        public int? Quantity_SaleOffer { get; set; }

        public DateTime? Date_SaleOffer { get; set; }

        public string Image_Product { get; set; }
    }
}
