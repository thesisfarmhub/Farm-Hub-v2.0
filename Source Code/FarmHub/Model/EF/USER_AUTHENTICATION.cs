namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class USER_AUTHENTICATION
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER_AUTHENTICATION()
        {
            FARMERs = new HashSet<FARMER>();
            FEED_BACK = new HashSet<FEED_BACK>();
            TRADERs = new HashSet<TRADER>();
        }

        [Key]
        public int Id_User { get; set; }

        public byte? Id_UserKind { get; set; }

        [StringLength(50)]
        public string Name_User { get; set; }

        [StringLength(50)]
        public string Password_User { get; set; }

        public DateTime? Created_Date { get; set; }

        public byte? Penalty { get; set; }

        public byte Status_User { get; set; }

        public bool? Is_Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FARMER> FARMERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FEED_BACK> FEED_BACK { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRADER> TRADERs { get; set; }

        public virtual USER_KIND USER_KIND { get; set; }
    }
}
