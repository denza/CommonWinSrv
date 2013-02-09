using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Reflection;
using CommonWinSrv.Core;
using System.Diagnostics;

namespace CommonWinSrv.Core.Manager
{
    public class ProcessManagerFactory : IDisposable
    {
        #region "Fields"

        FileSystemWatcher configurationWatcher;
        object syncObject = new object();

        #endregion

        #region "Properties"

        public string Location { get; set; }

        ProcessManager _Instance;
        public ProcessManager Instance
        {
            get
            {
                lock (syncObject)
                {
                    if (_Instance == null)
                    {
                        _Instance = CreateInstance();
                    }
                    return _Instance;
                }
            }
        }

        #endregion

        #region "Public Methods"

        public ProcessManagerFactory(string location)
        {
            this.Location = location;
            SetConfigurationWatcher(location);
            Init();
        }

        public void Dispose()
        {
            configurationWatcher.EnableRaisingEvents = false;
            configurationWatcher.Changed -= new FileSystemEventHandler(OnChanged);
        }

        public void Init()
        {
            EventLog.WriteEntry("CommonWinSrv", string.Format("Process manager factory init function started."), EventLogEntryType.Information);
            this.Instance.Init();
            EventLog.WriteEntry("CommonWinSrv", string.Format("Process manager factory init function finished."), EventLogEntryType.Information);
        }

        public void Start()
        {
            EventLog.WriteEntry("CommonWinSrv", string.Format("Process manager factory start function started."), EventLogEntryType.Information);
            this.Instance.Start();
            EventLog.WriteEntry("CommonWinSrv", string.Format("Process manager factory start function finished."), EventLogEntryType.Information);
        }

        public void Stop()
        {
            EventLog.WriteEntry("CommonWinSrv", string.Format("Process manager factory stop function started."), EventLogEntryType.Information);
            this.Instance.Stop();
            EventLog.WriteEntry("CommonWinSrv", string.Format("Process manager factory stop function finished."), EventLogEntryType.Information);
        }

        #endregion

        #region "Protected Methods"

        protected ProcessManager CreateInstance()
        {
            try
            {
                using (TextReader reader = new StreamReader(Location))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(ProcessManager), GetExtraTypesFromAssemblies());

                    return (ProcessManager)serializer.Deserialize(reader);
            }
                }
            catch (Exception ex)
            {
                EventLog.WriteEntry("CommonWinSrv", string.Format("Process manager factory deserialize configuration error. \n Stack: \n {0}",ex), EventLogEntryType.Error);
                throw ex;
            }
        }

        #endregion

        #region "Private Methods"

        private void ResetInstance()
        {
            this.Instance.Stop();
            _Instance = CreateInstance();
            this.Start();
        }

        void OnChanged(object sender, FileSystemEventArgs e)
        {
            EventLog.WriteEntry("CommonWinSrv", string.Format("Process manager factory configuration changed."), EventLogEntryType.Information);
            this.ResetInstance();
        }

        private void SetConfigurationWatcher(string location)
        {
            var path = location.Substring(0, location.LastIndexOf('\\'));
            var file = location.Substring(location.LastIndexOf('\\') + 1);
            configurationWatcher = new FileSystemWatcher();
            configurationWatcher.Path = path;
            configurationWatcher.Filter = file;
            configurationWatcher.Changed += new FileSystemEventHandler(OnChanged);
            configurationWatcher.NotifyFilter = NotifyFilters.LastWrite;
            configurationWatcher.EnableRaisingEvents = true;
        }

        private Type[] GetExtraTypes(Assembly assembly)
        {
            return assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(ActionBase))
                 || type.IsSubclassOf(typeof(ActionTriggerBase))
                 || type.IsSubclassOf(typeof(PropertyBase))).ToArray();
        }

        private List<Assembly> GetApplicationAssemblies()
        {
            string path = Path.GetDirectoryName(
             System.Reflection.Assembly.GetExecutingAssembly().Location);
            DirectoryInfo directoryInfo = new DirectoryInfo(path);
            return directoryInfo.GetFiles("*.dll")
                                .ToList()
                                .Select(fileInfo => Assembly.LoadFile(fileInfo.FullName))
                                .ToList();
        }

        private Type[] GetExtraTypesFromAssemblies()
        {
            var extraTypes = new List<Type>();

            GetApplicationAssemblies().ForEach(item => extraTypes.AddRange((GetExtraTypes(item))));

            return extraTypes.ToArray();
        }

        #endregion





    }
}
