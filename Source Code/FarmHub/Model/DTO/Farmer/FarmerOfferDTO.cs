using Model.EF;

using PagedList;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.Farmer
{
    public class FarmerOfferDTO
    {
        public SALE_OFFER saleOffer { get; set; }

        public IEnumerable<ProductDetailDTO> productDetails { get; set; }
        public IEnumerable<UnitMassDTO> units { get; set; }
        public IEnumerable<FarmDTO> farms { get; set; }
     

    }
}
