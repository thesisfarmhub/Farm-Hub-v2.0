namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("FARMER")]
    public partial class FARMER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FARMER()
        {
            FARMs = new HashSet<FARM>();
            FARMER_PREFERENCE = new HashSet<FARMER_PREFERENCE>();
        }

        [Key]
        public int Id_Farmer { get; set; }

        public int? Id_User { get; set; }

        [StringLength(50)]
        public string Name_Farmer { get; set; }

        public DateTime? Birthday_Farmer { get; set; }

        public bool? Gender_Farmer { get; set; }

        [StringLength(200)]
        public string Address_Farmer { get; set; }

        [StringLength(10)]
        public string Telephone_Farmer { get; set; }

        [StringLength(100)]
        public string Email_Farmer { get; set; }

        public bool? Is_Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FARM> FARMs { get; set; }

        public virtual USER_AUTHENTICATION USER_AUTHENTICATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FARMER_PREFERENCE> FARMER_PREFERENCE { get; set; }
    }
}
