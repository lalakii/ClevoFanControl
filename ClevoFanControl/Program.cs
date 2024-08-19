using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace ClevoFanControl
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            new Mutex(true, "ClevoFanControl_LALAKI_PORT", out bool isSingleton);
            if (!isSingleton)
            {
                MessageBox.Show("Clevo Fan Control is already running.", "Clevo Fan Control", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Environment.Exit(1);
            }
            Dictionary<string, Assembly> dllItems = new Dictionary<string, Assembly>();
            var main = typeof(Program).Assembly;
            foreach (string resName in main.GetManifestResourceNames())
            {
                var res = main.GetManifestResourceStream(resName);
                using (res)
                {
                    if (resName.EndsWith(".dll"))
                    {
                    }
                    else if (resName.EndsWith(".gz"))
                    {
                        var gzDll = new GZipStream(res, CompressionMode.Decompress);
                        var ms = new MemoryStream();
                        gzDll.CopyTo(ms);
                        if (resName.Contains("EcInfo"))
                        {
                            var dllPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Windows), "System32\\ClevoEcInfo.dll");
                            if (!File.Exists(dllPath))
                            {
                                File.WriteAllBytes(dllPath, ms.ToArray());
                            }
                        }
                        else
                        {
                            var dll = Assembly.Load(ms.ToArray());
                            dllItems[dll.FullName] = dll;
                        }
                    }
                }
            }
            AppDomain.CurrentDomain.AssemblyResolve += (_, e) => dllItems[e.Name];
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMain());
        }
    }
}