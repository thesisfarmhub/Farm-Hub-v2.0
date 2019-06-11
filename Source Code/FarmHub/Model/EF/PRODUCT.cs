namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Web;

    [Table("PRODUCT")]
    public partial class PRODUCT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT()
        {
            FARMER_PREFERENCE_DETAIL = new HashSet<FARMER_PREFERENCE_DETAIL>();
            PRODUCT_DETAIL = new HashSet<PRODUCT_DETAIL>();
            PURCHASE_OFFER = new HashSet<PURCHASE_OFFER>();
            SEEDs = new HashSet<SEED>();
        }

        [Key]
        public int Id_Product { get; set; }

        public int? Id_ProductKind { get; set; }

        [StringLength(50)]
        public string Name_Product { get; set; }

        [StringLength(200)]
        public string Image_Product { get; set; }

        public bool? Is_Deleted { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FARMER_PREFERENCE_DETAIL> FARMER_PREFERENCE_DETAIL { get; set; }

        public virtual PRODUCT_KIND PRODUCT_KIND { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_DETAIL> PRODUCT_DETAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PURCHASE_OFFER> PURCHASE_OFFER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SEED> SEEDs { get; set; }
    }
}
