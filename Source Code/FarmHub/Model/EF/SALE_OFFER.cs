namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SALE_OFFER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SALE_OFFER()
        {
            SALE_OFFER_DETAIL = new HashSet<SALE_OFFER_DETAIL>();
        }

        [Key]
        public int Id_SaleOffer { get; set; }

        public int? Id_Farm { get; set; }

        public byte? Id_MassUnit { get; set; }

        public int? Id_ProductDetail { get; set; }

        public DateTime? Date_SaleOffer { get; set; }

        public int? Price_Offer { get; set; }

        public int? Quantity_SaleOffer { get; set; }

        public int? Remain_SaleQuantity { get; set; }

        public bool? Can_Bargain { get; set; }

        public byte? Paying_Time { get; set; }

        public byte? Delivering_Time { get; set; }

        public byte? Number_Of_Orders { get; set; }

        public bool? Is_Deleted { get; set; }

        public virtual FARM FARM { get; set; }

        public virtual MASS_UNIT MASS_UNIT { get; set; }

        public virtual PRODUCT_DETAIL PRODUCT_DETAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALE_OFFER_DETAIL> SALE_OFFER_DETAIL { get; set; }
    }
}
