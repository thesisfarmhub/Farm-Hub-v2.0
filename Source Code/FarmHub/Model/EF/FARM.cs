namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FARM")]
    public partial class FARM
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FARM()
        {
            PRODUCT_DETAIL = new HashSet<PRODUCT_DETAIL>();
            SALE_OFFER = new HashSet<SALE_OFFER>();
        }

        [Key]
        public int Id_Farm { get; set; }

        public int? Id_Farmer { get; set; }

        [StringLength(50)]
        public string Name_Farm { get; set; }

        [StringLength(200)]
        public string Address_Farm { get; set; }

        [StringLength(50)]
        public string City_Farm { get; set; }

        public int? Acreage { get; set; }

        [StringLength(250)]
        public string Description_Farm { get; set; }

        public bool? Is_Deleted { get; set; }

        public virtual FARMER FARMER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT_DETAIL> PRODUCT_DETAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALE_OFFER> SALE_OFFER { get; set; }
    }
}
