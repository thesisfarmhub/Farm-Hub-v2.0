namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TRADER_PREFERENCE_DETAIL
    {
        [Key]
        public int Id_TraderPreferenceDetail { get; set; }

        public int? Id_TraderPreference { get; set; }

        public int? Id_ProductKind { get; set; }

        public bool? Is_Deleted { get; set; }

        public virtual PRODUCT_KIND PRODUCT_KIND { get; set; }

        public virtual TRADER_PREFERENCE TRADER_PREFERENCE { get; set; }
    }
}
