using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DTO.Common
{
    public class FeedBackDTO
    {
        public FEED_BACK feedback { get; set; }
        public IEnumerable<TopicDTO> topic { get; set; }
    }
}
