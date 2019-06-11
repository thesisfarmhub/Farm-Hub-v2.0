namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SEED")]
    public partial class SEED
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SEED()
        {
            PRODUCT_DETAIL = new HashSet<PRODUCT_DETAIL>();
            PURCHASE_OFFER = new HashSet<PURCHASE_OFFER>();
        }

        [Key]
        public int Id_Seed { get; set; }

        public int? Id_Product { get; set; }

        [StringLength(50)]
        public string Name_Seed { get; set; }

        [StringLength(50)]
        public string Code_Seed { get; set; }

        public bool? Is_Deleted { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_DETAIL> PRODUCT_DETAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PURCHASE_OFFER> PURCHASE_OFFER { get; set; }
    }
}
