using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using CommonWinSrv.Core.Manager;

namespace CommonWinSrv.Runner
{
    partial class CommonWinSrv : ServiceBase
    {
        ProcessManagerFactory factory;

        public CommonWinSrv()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            var configLocation = System.Configuration.ConfigurationManager.AppSettings["serviceConfigFile"];

            factory = new ProcessManagerFactory(configLocation);
            factory.Start();
        }

        protected override void OnStop()
        {
            factory.Stop();
        }
    }
}
