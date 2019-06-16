namespace Model.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FarmHubDbContext : DbContext
    {
        public FarmHubDbContext()
            : base("name=FarmHubDbContext")
        {
        }

        public virtual DbSet<FARM> FARMs { get; set; }
        public virtual DbSet<FARMER> FARMERs { get; set; }
        public virtual DbSet<FARMER_PREFERENCE> FARMER_PREFERENCE { get; set; }
        public virtual DbSet<FARMER_PREFERENCE_DETAIL> FARMER_PREFERENCE_DETAIL { get; set; }
        public virtual DbSet<FEED_BACK> FEED_BACK { get; set; }
        public virtual DbSet<MASS_UNIT> MASS_UNIT { get; set; }
        public virtual DbSet<PRODUCT> PRODUCTs { get; set; }
        public virtual DbSet<PRODUCT_DETAIL> PRODUCT_DETAIL { get; set; }
        public virtual DbSet<PRODUCT_KIND> PRODUCT_KIND { get; set; }
        public virtual DbSet<PURCHASE_OFFER> PURCHASE_OFFER { get; set; }
        public virtual DbSet<PURCHASE_OFFER_DETAIL> PURCHASE_OFFER_DETAIL { get; set; }
        public virtual DbSet<SALE_OFFER> SALE_OFFER { get; set; }
        public virtual DbSet<SALE_OFFER_DETAIL> SALE_OFFER_DETAIL { get; set; }
        public virtual DbSet<SEED> SEEDs { get; set; }
        public virtual DbSet<STATUS_TRANS> STATUS_TRANS { get; set; }
        public virtual DbSet<TOPIC> TOPICs { get; set; }
        public virtual DbSet<TRADER> TRADERs { get; set; }
        public virtual DbSet<TRADER_PREFERENCE> TRADER_PREFERENCE { get; set; }
        public virtual DbSet<TRADER_PREFERENCE_DETAIL> TRADER_PREFERENCE_DETAIL { get; set; }
        public virtual DbSet<TRANSACTION_ORDER> TRANSACTION_ORDER { get; set; }
        public virtual DbSet<USER_AUTHENTICATION> USER_AUTHENTICATION { get; set; }
        public virtual DbSet<USER_KIND> USER_KIND { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PRODUCT>()
                .Property(e => e.Image_Product)
                .IsUnicode(false);

            modelBuilder.Entity<PRODUCT_DETAIL>()
                .Property(e => e.Image_ProductDetail)
                .IsUnicode(false);

            modelBuilder.Entity<TRANSACTION_ORDER>()
                .Property(e => e.Image_Invoice)
                .IsUnicode(false);

            modelBuilder.Entity<USER_AUTHENTICATION>()
                .Property(e => e.Name_User)
                .IsUnicode(false);

            modelBuilder.Entity<USER_AUTHENTICATION>()
                .Property(e => e.Password_User)
                .IsUnicode(false);
        }
    }
}
