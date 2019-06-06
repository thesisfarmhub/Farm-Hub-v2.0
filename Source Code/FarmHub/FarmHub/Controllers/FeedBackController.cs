using Model.Dao.Authentication;
using Model.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FarmHub.Controllers
{
    public class FeedBackController : Controller
    {
        // GET: FeedBack
        public ActionResult FeedBackCreate(int? topic)
        {
            FeedBackDTO feedBackDTO = new FeedBackDTO();
            feedBackDTO.topic = TopicList();

            return View(feedBackDTO);
           
        }

        public IEnumerable<TopicDTO> TopicList()
        {
            var dao = new FeedBackDao();
            var topiclist = dao.GetListTopic();

            List<TopicDTO> topicDTOs = new List<TopicDTO>();

            foreach (var item in topiclist)
            {
                TopicDTO topic = new TopicDTO();
                topic.topicId = item.Id_Topic;
                topic.topicName = item.Name_Topic;

                topicDTOs.Add(topic);
            }

            return topicDTOs;
        }
    }
}