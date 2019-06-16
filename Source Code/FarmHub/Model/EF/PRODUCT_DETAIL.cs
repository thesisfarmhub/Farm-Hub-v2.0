namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    public partial class PRODUCT_DETAIL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT_DETAIL()
        {
            SALE_OFFER = new HashSet<SALE_OFFER>();
            TRANSACTION_ORDER = new HashSet<TRANSACTION_ORDER>();
        }

        [Key]
        public int Id_ProductDetail { get; set; }

        public int? Id_Product { get; set; }

        public int? Id_Farm { get; set; }

        public int? Id_Seed { get; set; }

        [StringLength(50)]
        public string Geography_Location { get; set; }

        [StringLength(200)]
        public string Image_ProductDetail { get; set; }

        public int? Min_Mass { get; set; }

        [StringLength(50)]
        public string Name_Crop { get; set; }

        public DateTime? Harvest_Time { get; set; }

        public int? Quantity_Expected { get; set; }

        public bool? Is_Deleted { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public virtual FARM FARM { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }

        public virtual SEED SEED { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALE_OFFER> SALE_OFFER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRANSACTION_ORDER> TRANSACTION_ORDER { get; set; }
    }
}
