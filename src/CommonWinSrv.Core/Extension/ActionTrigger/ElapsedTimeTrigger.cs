using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonWinSrv.Core;
using CommonWinSrv.Core.Extension.Property;

namespace CommonWinSrv.Core.Extension.ActionTrigger
{
    public class ElapsedTimeTrigger : ActionTriggerBase
    {
        #region "Fields"

        System.Timers.Timer timer;

        #endregion

        #region "Properties"

        public TimeSpanProperty Time { get; set; }

        #endregion

        #region "Methods"

        public override void Init(System.Action runAction)
        {
            base.Init(runAction);
            timer = new System.Timers.Timer();
            timer.Interval = Time.Time.TotalMilliseconds;
            timer.Elapsed += new System.Timers.ElapsedEventHandler(new Action<object, System.Timers.ElapsedEventArgs>(delegate { RunAction.Invoke(); }));
        }

        public override void Start()
        {
            base.Start();
            timer.Start();
        }

        public override void Stop()
        {
            base.Stop();
            timer.Stop();
        }

        #endregion
    }
}
