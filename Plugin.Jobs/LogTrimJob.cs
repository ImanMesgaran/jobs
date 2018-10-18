﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Plugin.Jobs
{
    public class LogTrimJob : IJob
    {
        const string ARG_KEY = "MaxAgeInDays";
        internal static Task Schedule(IJobManager jobManager, TimeSpan maxAge) => jobManager.Schedule(new JobInfo
        {
            Name = nameof(LogTrimJob),
            Type = typeof(LogTrimJob),
            BatteryNotLow = true,
            Parameters = new Dictionary<string, object>
            {
                { ARG_KEY, maxAge.TotalSeconds }
            }
        });


        public Task Run(JobInfo jobInfo, CancellationToken cancelToken)
        {
            var maxAgeInSeconds = jobInfo.GetValue<double>(ARG_KEY);
            var maxAge = TimeSpan.FromSeconds(maxAgeInSeconds);
            CrossJobs.Current.PurgeLogs(null, maxAge);
            return Task.CompletedTask;
        }
    }
}
