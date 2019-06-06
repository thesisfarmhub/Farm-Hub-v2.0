using Model.Dao.Authentication;
using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FarmHub.Job
{
    public class MyJob : Quartz.IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
           
            var dao = new TransactionScheduleDao();
            //dao.ChangeScheduledTransactions();
            dao.ChangeScheduledUserStatus();
   
        }
    }
    public class Schedule
    {
        async public static void  Start()
        {
            // construct a scheduler factory
            NameValueCollection props = new NameValueCollection
    {
        { "quartz.serializer.type", "binary" }
    };
            StdSchedulerFactory factory = new StdSchedulerFactory(props);

            // get a scheduler
            IScheduler sched = await factory.GetScheduler();
            await sched.Start();

            // define the job and tie it to our HelloJob class
            IJobDetail job = JobBuilder.Create<MyJob>()
                .WithIdentity("myJob", "group1")
                .Build();

            // Trigger the job to run now, and then every 40 seconds
            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("myTrigger", "group1")
                .StartAt(DateTime.UtcNow.AddSeconds(2))
                .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(15)
                    .RepeatForever())
            .Build();

            await sched.ScheduleJob(job, trigger);
        }
    }
}