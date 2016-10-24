using System.Collections.Generic;
using System.Linq;

namespace Lab01
{
    public class CarRepairEventArgs : CarFactoryEventArgs
    {
        public List<string> Details { get; set; }

        public CarRepairEventArgs(EventType eventType, string factoryName, string model, IEnumerable<string> details)
            : base(eventType, factoryName, model)
        {
            Details = details.ToList();
        }
    }
}