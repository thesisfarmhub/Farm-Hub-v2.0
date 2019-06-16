namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PRODUCT_KIND
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PRODUCT_KIND()
        {
            FARMER_PREFERENCE_DETAIL = new HashSet<FARMER_PREFERENCE_DETAIL>();
            PRODUCTs = new HashSet<PRODUCT>();
            TRADER_PREFERENCE_DETAIL = new HashSet<TRADER_PREFERENCE_DETAIL>();
        }

        [Key]
        public int Id_ProductKind { get; set; }

        [StringLength(50)]
        public string Name_ProductKind { get; set; }

        public bool? Is_Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FARMER_PREFERENCE_DETAIL> FARMER_PREFERENCE_DETAIL { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PRODUCT> PRODUCTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRADER_PREFERENCE_DETAIL> TRADER_PREFERENCE_DETAIL { get; set; }
    }
}
