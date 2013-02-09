using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommonWinSrv.Core
{
    public class ActionTriggerBase
    {
        #region "Fields"

        protected Action RunAction;

        #endregion

        #region "Methods"

        public virtual void Init(Action runAction)
        {
            this.RunAction = runAction;
        }

        public virtual void Start()
        {

        }

        public virtual void Stop()
        {

        }

        #endregion
    }
}
