using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonWinSrv.Core
{
    public class ProcessBase
    {
        public List<ActionBase> Actions { get; set; }

        public virtual void Initiliaze()
        {
            Actions.ForEach(action => action.Initilialize());
        }

        public virtual void Start()
        {
            Actions.ForEach(action => action.Start());
        }

        public virtual void Stop(bool force=false)
        {
            Actions.ForEach(action => action.Stop(force));
        }
    }
}
