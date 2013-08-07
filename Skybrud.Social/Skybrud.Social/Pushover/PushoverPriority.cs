using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Skybrud.Social.Pushover {

    public enum PushoverPriority {
        Normal = 0,
        Silent = -1,
        Low = -1,
        High = 1,
        Confirm = 2
    }

}
