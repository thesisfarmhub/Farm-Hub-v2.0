namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FARMER_PREFERENCE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FARMER_PREFERENCE()
        {
            FARMER_PREFERENCE_DETAIL = new HashSet<FARMER_PREFERENCE_DETAIL>();
        }

        [Key]
        public int Id_FarmerPreference { get; set; }

        public int? Id_Farmer { get; set; }

        public DateTime? Created_Date { get; set; }

        public virtual FARMER FARMER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FARMER_PREFERENCE_DETAIL> FARMER_PREFERENCE_DETAIL { get; set; }
    }
}
