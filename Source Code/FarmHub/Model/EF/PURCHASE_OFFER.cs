namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PURCHASE_OFFER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PURCHASE_OFFER()
        {
            PURCHASE_OFFER_DETAIL = new HashSet<PURCHASE_OFFER_DETAIL>();
        }

        [Key]
        public int Id_PurchasesOffer { get; set; }

        public int? Id_Trader { get; set; }

        public byte? Id_MassUnit { get; set; }

        public int? Id_Product { get; set; }

        public int? Id_Seed { get; set; }

        public DateTime? Date_PurchaseOffer { get; set; }

        public int? Price_Purchase { get; set; }

        public int? Quantity_PurchaseOffer { get; set; }

        public int? Remain_PurchaseQuantity { get; set; }

        public bool? Can_Bargain { get; set; }

        public byte? Paying_Time { get; set; }

        public byte? Delivering_Time { get; set; }

        public byte? Number_Of_Orders { get; set; }

        public bool? Is_Deleted { get; set; }

        public virtual MASS_UNIT MASS_UNIT { get; set; }

        public virtual PRODUCT PRODUCT { get; set; }

        public virtual SEED SEED { get; set; }

        public virtual TRADER TRADER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PURCHASE_OFFER_DETAIL> PURCHASE_OFFER_DETAIL { get; set; }
    }
}
