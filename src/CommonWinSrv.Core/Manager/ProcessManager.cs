using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommonWinSrv.Core;
using System.Xml.Serialization;
using System.Diagnostics;

namespace CommonWinSrv.Core
{
    [XmlInclude(typeof(ActionBase))]
    [XmlInclude(typeof(ActionTriggerBase))]
    public class ProcessManager
    {
        #region "Properties"

        public List<ProcessBase> Processes { get; set; }

        #endregion

        #region "Methods"

        public void Init()
        {
            EventLog.WriteEntry("MoveDesk Service", string.Format("Process manager init function started."), EventLogEntryType.Information);
            Processes.ForEach(process => process.Initiliaze());
            EventLog.WriteEntry("MoveDesk Service", string.Format("Process manager init function finished."), EventLogEntryType.Information);
        }

        public void Start()
        {
            EventLog.WriteEntry("MoveDesk Service", string.Format("Process manager start function started."), EventLogEntryType.Information);
            Processes.ForEach(process => process.Start());
            EventLog.WriteEntry("MoveDesk Service", string.Format("Process manager start function finished."), EventLogEntryType.Information);
        }

        public void Stop()
        {
            EventLog.WriteEntry("MoveDesk Service", string.Format("Process manager stop function started."), EventLogEntryType.Information);
            Processes.ForEach(process => process.Stop());
            EventLog.WriteEntry("MoveDesk Service", string.Format("Process manager stop function finished."), EventLogEntryType.Information);
        }

        #endregion
    }
}
