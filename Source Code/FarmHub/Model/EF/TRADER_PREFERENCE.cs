namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRADER_PREFERENCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TRADER_PREFERENCE()
        {
            TRADER_PREFERENCE_DETAIL = new HashSet<TRADER_PREFERENCE_DETAIL>();
        }

        [Key]
        public int Id_TraderPreference { get; set; }

        public int? Id_Trader { get; set; }

        public DateTime? Created_Date { get; set; }

        public virtual TRADER TRADER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TRADER_PREFERENCE_DETAIL> TRADER_PREFERENCE_DETAIL { get; set; }
    }
}
