namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FARMER_PREFERENCE_DETAIL
    {
        [Key]
        public int Id_FarmerPreferenceDetail { get; set; }

        public int? Id_FarmerPreference { get; set; }

        public int? Id_ProductKind { get; set; }

        public bool? Is_Deleted { get; set; }

        public virtual FARMER_PREFERENCE FARMER_PREFERENCE { get; set; }

        public virtual PRODUCT_KIND PRODUCT_KIND { get; set; }
    }
}
