namespace CommonWinSrv.Runner
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CommonWinSrvProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.CommonWinSrvInstaller = new System.ServiceProcess.ServiceInstaller();
            // 
            // CommonWinSrvProcessInstaller
            // 
            this.CommonWinSrvProcessInstaller.Password = null;
            this.CommonWinSrvProcessInstaller.Username = null;
            // 
            // CommonWinSrvInstaller
            // 
            this.CommonWinSrvInstaller.Description = "General purpose Windows Service";
            this.CommonWinSrvInstaller.DisplayName = "CommonWinSrvInstaller";
            this.CommonWinSrvInstaller.ServiceName = "CommonWinSrv";
            this.CommonWinSrvInstaller.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.CommonWinSrvProcessInstaller,
            this.CommonWinSrvInstaller});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller CommonWinSrvProcessInstaller;
        private System.ServiceProcess.ServiceInstaller CommonWinSrvInstaller;
    }
}