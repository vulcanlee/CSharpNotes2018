using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEventAggregator.Models
{
    public class ShowLogoutEvent : PubSubEvent<ShowLogoutEventPayload>
    {

    }

    public class ShowLogoutEventPayload
    {
        public bool IsShow { get; set; }
    }
}
