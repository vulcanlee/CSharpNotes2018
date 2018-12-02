using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorEventAggregator.Models
{
    public class ShowLoginEvent : PubSubEvent<ShowLoginEventPayload>
    {

    }

    public class ShowLoginEventPayload
    {
        public bool IsShow { get; set; }
    }
}
