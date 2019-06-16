namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TRADER")]
    public partial class TRADER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRADER()
        {
            PURCHASE_OFFER = new HashSet<PURCHASE_OFFER>();
            TRADER_PREFERENCE = new HashSet<TRADER_PREFERENCE>();
        }

        [Key]
        public int Id_Trader { get; set; }

        public int? Id_User { get; set; }

        [StringLength(50)]
        public string Name_Trader { get; set; }

        public DateTime? Birthday_Trader { get; set; }

        public bool? Gender_Trader { get; set; }

        [StringLength(200)]
        public string Address_Trader { get; set; }

        [StringLength(10)]
        public string Telephone_Trader { get; set; }

        [StringLength(100)]
        public string Email_Trader { get; set; }

        public int? Number_Of_Successful_Trans { get; set; }

        public int? Number_Of_Cancelled_Trans { get; set; }

        public double? Prestige_Point { get; set; }

        public byte? Status_Trader { get; set; }

        public bool? Is_Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PURCHASE_OFFER> PURCHASE_OFFER { get; set; }

        public virtual USER_AUTHENTICATION USER_AUTHENTICATION { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRADER_PREFERENCE> TRADER_PREFERENCE { get; set; }
    }
}
