﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Xml.Serialization;

namespace CommonWinSrv.Core
{
    public class ActionBase
    {
        #region Properties

        public ActionStatus Status { get; set; }

        public ActionTriggerBase Trigger { get; set; }

        [XmlIgnore]
        public virtual Action RunAction { get; private set; }

        #endregion

        #region "Methods"

        public ActionBase()
        {
            this.Status = ActionStatus.Inactive;
        }

        public virtual void Initilialize()
        {
            Status = ActionStatus.Active;
            Trigger.Init(Run);
        }

        public virtual void Start()
        {
            Status = ActionStatus.Waiting;
            Trigger.Start();
        }

        public virtual void Run()
        {
            if (this.Status == ActionStatus.Waiting)
            {
                Status = ActionStatus.Working;
                EventLog.WriteEntry("CommonWinSrv", string.Format("Running {0} at {1}", this.GetType().Name, DateTime.Now), EventLogEntryType.Information);
                try
                {
                    if (RunAction != null)
                    {
                        throw new Exception("RunAction is null.");
                    }

                    RunAction.Invoke();
                }
                catch (Exception ex)
                {
                    EventLog.WriteEntry("CommonWinSrv", string.Format("Error occured {0} at {1}", ex.Message, DateTime.Now), EventLogEntryType.Error);
                }
                finally
                {
                    Status = ActionStatus.Waiting;
                }
            }
        }

        public virtual void Stop(bool forse = false)
        {
            this.Status = ActionStatus.Inactive;
        }

        #endregion
    }
}
