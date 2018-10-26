﻿using System;
using System.Collections.Generic;


namespace Plugin.Jobs
{
    public class JobInfo
    {
        public string Name { get; set; }
        public Type Type { get; set; }

        // TODO: next run time? Date/Time or TimeSpan
        // TODO: priority?
        //public bool RunPeriodic { get; set; }
        //public bool DeviceIdle { get; set; } // this will only work on droid

        public bool Repeat { get; set; } = true;
        public bool DeviceCharging { get; set; }
        public bool BatteryNotLow { get; set; }
        public NetworkType RequiredNetwork { get; set; } = NetworkType.None;
        public DateTime? LastRunUtc { get; set; }
        public IDictionary<string, object> Parameters { get; set; } = new Dictionary<string, object>();
    }
}
