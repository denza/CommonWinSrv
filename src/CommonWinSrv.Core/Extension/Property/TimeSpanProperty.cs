using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonWinSrv.Core;
using System.Xml.Serialization;

namespace CommonWinSrv.Core.Extension.Property
{
    public class TimeSpanProperty:PropertyBase
    {
        /// <summary>
        /// ticks: A time period expresed in 100-nanosecond units
        /// </summary>
        public long Ticks { get; set; }

        [XmlIgnore]
        public TimeSpan Time
        {
            get
            {
                return new TimeSpan(Ticks);
            }
        }
    }
}
