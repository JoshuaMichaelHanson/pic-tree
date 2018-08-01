using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.IO.IsolatedStorage;//for help files
using System.IO;
using System.Windows.Resources;

namespace TreeIDTestProgram
{
    public partial class App : Application
    {
        /// <summary>
        /// Provides easy access to the root frame of the Phone Application.
        /// </summary>
        /// <returns>The root frame of the Phone Application.</returns>
        public PhoneApplicationFrame RootFrame { get; private set; }

        public string currentTreeType {get; set; }//this must be set before calling tree view page
        public string currentPreviewType { get; set; } //this is for previewing trees of a certian type could be all trees available
        public string currentOptionsFile { get; set; } //this is for options page

        public int getHome = 0;
        //eventually I should put this into phone application service for proper use
        //more bad code
        //  smiley LOL
        //public var indicator; 
        public ProgressIndicator picTreeWorking; 
        
        /// <summary>
        /// Constructor for the Application object.
        /// </summary>
        public App()
        {
            // Global handler for uncaught exceptions. 
            UnhandledException += Application_UnhandledException;
           
            // Standard Silverlight initialization
            InitializeComponent();

            // Phone-specific initialization
            InitializePhoneApplication();

            // Show graphics profiling information while debugging.
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // Display the current frame rate counters.
                Application.Current.Host.Settings.EnableFrameRateCounter = true;

                // Show the areas of the app that are being redrawn in each frame.
                //Application.Current.Host.Settings.EnableRedrawRegions = true;

                // Enable non-production analysis visualization mode, 
                // which shows areas of a page that are handed off to GPU with a colored overlay.
                //Application.Current.Host.Settings.EnableCacheVisualization = true;

                // Disable the application idle detection by setting the UserIdleDetectionMode property of the
                // application's PhoneApplicationService object to Disabled.
                // Caution:- Use this under debug mode only. Application that disables user idle detection will continue to run
                // and consume battery power when the user is not using the phone.
                PhoneApplicationService.Current.UserIdleDetectionMode = IdleDetectionMode.Disabled;
            }

        }
       

        //this is the code for the GlobalAppBar
        private void HomeButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Button 1 works!");
            //Do work for your application here.
           if (getHome > 0)
           {
                //we are not on home page
                while (getHome > 1)
                {
                    RootFrame.RemoveBackEntry();
                    --getHome;
                }
                --getHome;
                RootFrame.GoBack();
            }
            //else we already on home page
        }


        private void HelpButton_Click(object sender, EventArgs e)
        {
            //load and save help files, should only need to do this once find way to check
            //if its already been build dont build again just show
            //MessageBox.Show("Next time");
            SaveFilesToIsoStore();
            RootFrame.Navigate(new Uri("/Help.xaml", UriKind.Relative));
            //MessageBox.Show("Next time");
            //Do work for your application here.
        }


        //for help files kinda cool wish was easier but this not too bad
        private void SaveFilesToIsoStore()
        {
            string[] files = { 
                "HTML/HelpFiles/HelpMain.html", "HTML/HelpFiles/HowTo.html", "HTML/HelpFiles/Settings.html",
                "HTML/HelpFiles/Glossary.html", "HTML/HelpFiles/mystyles.css", "HTML/HelpFiles/Coniferous.html",
                //start coniferous pics in html
                "HTML/HelpFiles/Pics/Scalelike.png", "HTML/HelpFiles/Pics/AwlShaped.png", "HTML/HelpFiles/Pics/LinearShaped.png",
                "HTML/HelpFiles/Pics/Singles.png", "HTML/HelpFiles/Pics/Bundles.png", "HTML/HelpFiles/Pics/Clusters.png",
                "HTML/HelpFiles/Pics/WoodySeedCone.png", "HTML/HelpFiles/Pics/FleshySeedCone.png", 
                //start deciduous tree html
                "HTML/HelpFiles/Deciduous.html", "HTML/HelpFiles/Pics/Alternate.png", "HTML/HelpFiles/Pics/Opposite.png",
                "HTML/HelpFiles/Pics/Whorled.png", "HTML/HelpFiles/Pics/Simple.png", "HTML/HelpFiles/Pics/PalmatelyCompound.png",
                "HTML/HelpFiles/Pics/PinnatelyCompound.png", "HTML/HelpFiles/Pics/DoublyCompound.png", "HTML/HelpFiles/Pics/MarginsSmooth.png",
                "HTML/HelpFiles/Pics/MarginsFinelyToothed.png", "HTML/HelpFiles/Pics/MarginsCoarselyToothed.png",
                "HTML/HelpFiles/Pics/MarginsDoublyToothed.png", "HTML/HelpFiles/Pics/MarginsLobed.png", "HTML/HelpFiles/Pics/LobesPalmate.png",
                //start fuits of decidous html
                "HTML/HelpFiles/Pics/Pome.png", "HTML/HelpFiles/Pics/Drupe.png", "HTML/HelpFiles/Pics/MultipleOfDrupes.png",
                "HTML/HelpFiles/Pics/Samara.png", "HTML/HelpFiles/Pics/Capsule.png", "HTML/HelpFiles/Pics/Legume.png",
                "HTML/HelpFiles/Pics/Acorn.png", "HTML/HelpFiles/Pics/Nut.png", "HTML/HelpFiles/Pics/NutletClusters.png",
                //start about
                 "HTML/HelpFiles/About.html"
            };

            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();

            //if (false == isoStore.FileExists(files[0]))
            //{
                foreach (string f in files)
                {
                    StreamResourceInfo sr = Application.GetResourceStream(new Uri(f, UriKind.Relative));

                    using (BinaryReader br = new BinaryReader(sr.Stream))
                    {
                        byte[] data = br.ReadBytes((int)sr.Stream.Length);
                        SaveToIsoStore(f, data);
                    }
                }
            //}
        }


        //again for help files for navigating to local html 
        private void SaveToIsoStore(string fileName, byte[] data)
        {
            string strBaseDir = string.Empty;
            string delimStr = "/";
            char[] delimiter = delimStr.ToCharArray();
            string[] dirsPath = fileName.Split(delimiter);

            //get the IsoStore
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();

            //re-create the dir struct
            for (int i = 0; i < dirsPath.Length - 1; i++)
            {
                strBaseDir = System.IO.Path.Combine(strBaseDir, dirsPath[i]);
                isoStore.CreateDirectory(strBaseDir);
            }

            //remove existing file
            if (isoStore.FileExists(fileName))
            {
                isoStore.DeleteFile(fileName);
            }

            using (BinaryWriter bw = new BinaryWriter(isoStore.CreateFile(fileName)))
            {
                bw.Write(data);
                bw.Close();
            }
        }

        private void HomeMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Menu item 1 works!");
            //Do work for your application here.
            HomeButton_Click(sender, e);
        }

        private void HelpMenuItem_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Menu item 2 works!");
            //Do work for your application here.
            HelpButton_Click(sender, e);
        }



        // Code to execute when the application is launching (eg, from Start)
        // This code will not execute when the application is reactivated
        private void Application_Launching(object sender, LaunchingEventArgs e)
        {
            
        }

        // Code to execute when the application is activated (brought to foreground)
        // This code will not execute when the application is first launched
        private void Application_Activated(object sender, ActivatedEventArgs e)
        {
        }

        // Code to execute when the application is deactivated (sent to background)
        // This code will not execute when the application is closing
        private void Application_Deactivated(object sender, DeactivatedEventArgs e)
        {
            
        }

        // Code to execute when the application is closing (eg, user hit Back)
        // This code will not execute when the application is deactivated
        private void Application_Closing(object sender, ClosingEventArgs e)
        {
        }

        // Code to execute if a navigation fails
        private void RootFrame_NavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // A navigation has failed; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        // Code to execute on Unhandled Exceptions
        private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                // An unhandled exception has occurred; break into the debugger
                System.Diagnostics.Debugger.Break();
            }
        }

        #region Phone application initialization

        // Avoid double-initialization
        private bool phoneApplicationInitialized = false;

        // Do not add any additional code to this method
        private void InitializePhoneApplication()
        {
            if (phoneApplicationInitialized)
                return;

            // Create the frame but don't set it as RootVisual yet; this allows the splash
            // screen to remain active until the application is ready to render.
            RootFrame = new PhoneApplicationFrame();
            RootFrame.Navigated += CompleteInitializePhoneApplication;

            // Handle navigation failures
            RootFrame.NavigationFailed += RootFrame_NavigationFailed;

            // Ensure we don't initialize again
            phoneApplicationInitialized = true;
        }

        // Do not add any additional code to this method
        private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
        {
            // Set the root visual to allow the application to render
            if (RootVisual != RootFrame)
                RootVisual = RootFrame;

            // Remove this handler since it is no longer needed
            RootFrame.Navigated -= CompleteInitializePhoneApplication;
        }

        #endregion
    }
}