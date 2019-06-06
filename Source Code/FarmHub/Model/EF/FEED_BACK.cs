namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FEED_BACK
    {
        [Key]
        public int Id_FeedBack { get; set; }

        public int? Id_User { get; set; }

        public int? Id_Topic { get; set; }

        [StringLength(50)]
        public string Title_FeedBack { get; set; }

        [StringLength(200)]
        public string Description_FeedBack { get; set; }
       
        public int? Id_Transaction { get; set; }

        public bool? Is_Deleted { get; set; }

        public virtual TOPIC TOPIC { get; set; }

        public virtual USER_AUTHENTICATION USER_AUTHENTICATION { get; set; }
    }
}
