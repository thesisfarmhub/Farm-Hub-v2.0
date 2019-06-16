namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MASS_UNIT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MASS_UNIT()
        {
            PURCHASE_OFFER = new HashSet<PURCHASE_OFFER>();
            SALE_OFFER = new HashSet<SALE_OFFER>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public byte Id_MassUnit { get; set; }

        [StringLength(10)]
        public string Name_MassUnit { get; set; }

        public int? Weight_To_Kg { get; set; }

        public bool? Is_Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PURCHASE_OFFER> PURCHASE_OFFER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SALE_OFFER> SALE_OFFER { get; set; }
    }
}
