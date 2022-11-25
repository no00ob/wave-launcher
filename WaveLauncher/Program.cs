using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace no00ob.WaveLauncher
{
    static class Program
    {
        public const string version = "1.0.0-d";
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            StringBuilder log = new StringBuilder();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            if (File.Exists(path + "/devlauncher.log"))
            {
                File.Delete(path + "/devlauncher.log");
            }
            log.Append("Reading project path...");
            string game = Path.Combine(path, "WaveDev.lnk");
            string gameVersion = File.ReadAllText(path + "/Wave_Data/version");
            INIWorker.SetPath(path);
            /*
            log.Append("\nReading launcher settings file...");
            
            string[] settings = new string[11];
            settings[0] = INIWorker.IniReadValue(INIWorker.Sections.Rendering, INIWorker.Keys.sApi);
            settings[1] = INIWorker.IniReadValue(INIWorker.Sections.Rendering, INIWorker.Keys.sQualityPreset);
            settings[2] = INIWorker.IniReadValue(INIWorker.Sections.Rendering, INIWorker.Keys.iResX);
            settings[3] = INIWorker.IniReadValue(INIWorker.Sections.Rendering, INIWorker.Keys.iResY);
            settings[4] = INIWorker.IniReadValue(INIWorker.Sections.Rendering, INIWorker.Keys.iFullscreen);
            settings[5] = INIWorker.IniReadValue(INIWorker.Sections.Rendering, INIWorker.Keys.iWindowedMode);
            settings[6] = INIWorker.IniReadValue(INIWorker.Sections.Rendering, INIWorker.Keys.iForceGpu);
            settings[7] = INIWorker.IniReadValue(INIWorker.Sections.Rendering, INIWorker.Keys.iForceMonitor);
            settings[8] = INIWorker.IniReadValue(INIWorker.Sections.Rendering, INIWorker.Keys.iNoGraphics);
            settings[9] = INIWorker.IniReadValue(INIWorker.Sections.Game, INIWorker.Keys.iCensoredMode);
            settings[10] = INIWorker.IniReadValue(INIWorker.Sections.Game, INIWorker.Keys.iNoLog);
            
            int i_width = StringToInt(settings[2], false);
            int i_height = StringToInt(settings[3], false);
            int i_fullscreen = StringToInt(settings[4], true);
            int i_windowed = StringToInt(settings[5], true);
            int i_gpu = StringToInt(settings[6], false);
            int i_monitor = StringToInt(settings[7], false);
            int i_noDisplay = StringToInt(settings[8], true);
            int i_censorship = StringToInt(settings[9], true);
            int i_noLog = StringToInt(settings[10], true);
            
            if (INIWorker.INIExists())
            {
                bool isEmptyFile = true;
                string[] loadedSettings = new string[settings.Length];

                for (int i = 0; i < settings.Length; i++)
                {
                    if (!string.IsNullOrEmpty(settings[i]))
                    {
                        isEmptyFile = false;
                        loadedSettings[i] = settings[i];
                    }
                }

                if (!isEmptyFile)
                {
                    log.Append("\nLauncher settings applied!");

                    for (int i = 0; i < loadedSettings.Length; i++)
                    {
                        if (loadedSettings[i] != null)
                        {
                            switch (i)
                            {
                                case 0:
                                    log.Append("\n   Api=" + loadedSettings[0]);
                                    break;
                                case 1:
                                    log.Append("\n   QualityPreset=" + loadedSettings[1]);
                                    break;
                                case 2:
                                    if (i_width > -1)
                                        log.Append("\n   ResolutionWidth=" + i_width.ToString());
                                    break;
                                case 3:
                                    if (i_height > -1)
                                        log.Append("\n   ResolutionHeight=" + i_height.ToString());
                                    break;
                                case 4:
                                    if (i_fullscreen > -1)
                                        log.Append("\n   Fullscreen=" + Convert.ToBoolean(i_fullscreen).ToString());
                                    break;
                                case 5:
                                    if (i_windowed > -1)
                                        if (i_windowed == 0)
                                            log.Append("\n   WindowedMode=exclusive");
                                        else
                                            log.Append("\n   WindowedMode=borderless");
                                    break;
                                case 6:
                                    if (i_gpu > -1)
                                        log.Append("\n   Gpu=" + i_gpu.ToString());
                                    break;
                                case 7:
                                    if (i_monitor > -1)
                                        log.Append("\n   Monitor=" + i_monitor.ToString());
                                    break;
                                case 8:
                                    if (i_noDisplay > -1)
                                        log.Append("\n   NoDisplay=" + Convert.ToBoolean(i_noDisplay).ToString());
                                    break;
                                case 9:
                                    if (i_censorship > -1)
                                        log.Append("\n   CensoredMode=" + Convert.ToBoolean(i_censorship).ToString());
                                    break;
                                case 10:
                                    if (i_noLog > -1)
                                        log.Append("\n   NoLogging=" + Convert.ToBoolean(i_noLog).ToString());
                                    break;
                                default:
                                    // Default handling maybe idk
                                    break;
                            }
                        }
                    }
                }
                else
                {
                    log.Append("\nLauncher settings file is empty!");
                }
            }
            else
            {
                log.Append("\nLauncher settings file does not exist!");
            }
            string launchArguments = "";
            */
            log.Append("\nStarting project...");

            // Maybe allow any additional args but as of right now I have no idea how to elegantly tell which ones are duplicates of built in unity arg handling
            //for (int i = 0; i < args.Length; i++)
            //{
            //    launchArguments = launchArguments + " " + args[i];
            //}
            /*
            switch (settings[0])
            {
                case "dx11":
                    launchArguments = launchArguments + " -force-d3d11";
                    break;
                case "d3d11":
                    launchArguments = launchArguments + " -force-d3d11";
                    break;
                case "dx12":
                    launchArguments = launchArguments + " -force-d3d12";
                    break;
                case "d3d12":
                    launchArguments = launchArguments + " -force-d3d12";
                    break;
                case "vulkan":
                    launchArguments = launchArguments + " -force-vulkan";
                    break;
                default:
                    //Maybe do something if nothing is specified idk
                    break;
            }
            switch (settings[1])
            {
                case "low":
                    launchArguments = launchArguments + " -screen-quality Low";
                    break;
                case "medium":
                    launchArguments = launchArguments + " -screen-quality Medium";
                    break;
                case "high":
                    launchArguments = launchArguments + " -screen-quality High";
                    break;
                case "ultra":
                    launchArguments = launchArguments + " -screen-quality Ultra";
                    break;
            }
            if (i_width > 0)
            {
                launchArguments = launchArguments + string.Format(" -screen-width {0}",i_width);
            }
            if (i_height > 0)
            {
                launchArguments = launchArguments + string.Format(" -screen-height {0}", i_height);
            }
            if (i_fullscreen > -1)
            {
                launchArguments = launchArguments + string.Format(" -screen-fullscreen {0}", i_fullscreen);
            }
            if (i_windowed > -1)
            {
                if (i_windowed == 0)
                    launchArguments = launchArguments + " -window-mode exclusive";
                else if (i_windowed == 1)
                    launchArguments = launchArguments + " -window-mode borderless";
            }
            if (i_gpu > -1)
            {
                launchArguments = launchArguments + string.Format(" -force-device-index {0}",i_gpu);
            }
            if (i_monitor > -1)
            {
                launchArguments = launchArguments + string.Format(" -monitor {0}", i_monitor);
            }
            if (i_noDisplay > -1)
            {
                launchArguments = launchArguments + string.Format(" -nographics {0}", i_noDisplay);
            }
            if (i_noLog > -1)
            {
                launchArguments = launchArguments + string.Format(" -nolog {0}", i_noLog);
            }
            if (i_censorship == 0)
            {
                launchArguments += " -censor-off";
            }
            else if (i_censorship > 0)
            {
                launchArguments += " -censor-on";
            }
            */
            log.Append("\npath=" + game + "\nargs=" /* + launchArguments */ + "\ngameVersion=" + gameVersion + "\nlauncherVersion=" + version);

            try
            {
                System.Diagnostics.Process.Start(string.Format(@"{0}",game)/*, launchArguments*/);
                log.Append("\nProject started!");
            }
            catch (Exception ex)
            {
                log.Append("\nProject failed to start!");
                log.Append("\n"+"Exception occured="+ex.ToString());
                if (ex.Message.Contains("The system cannot find the file specified"))
                    MessageBox.Show("Project shortcut file 'WaveDev.lnk' not found. Make sure the developer environment is setup correctly.", "Error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show(ex.Message + "\n\n" + ex.ToString(), "Error has occured", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            log.Append("\nShutting down the launcher...");
            File.AppendAllText(path + "/devlauncher.log", log.ToString());
            log.Clear();
            System.Environment.Exit(1);
        }

        public static int StringToInt(string str, bool isBoolean)
        {
            if (int.TryParse(str, out int _i))
            {
                if (isBoolean && _i > 1)
                    _i = 1;
                return _i;
            }
            else
            {
                return -1;
            }
        }
    }
}
