namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TOPIC")]
    public partial class TOPIC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TOPIC()
        {
            FEED_BACK = new HashSet<FEED_BACK>();
        }

        [Key]
        public int Id_Topic { get; set; }

        [StringLength(50)]
        public string Name_Topic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FEED_BACK> FEED_BACK { get; set; }
    }
}
