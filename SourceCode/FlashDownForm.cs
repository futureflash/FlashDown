using AutoUpdaterDotNET;
using Microsoft.Win32;
using FlashDown.Properties;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Windows.Threading;
using System;
using System.Collections.Generic;
using System.IO;

namespace FlashDown
{

    //
    //
    // Created by FutureFlash on 3/17/2021 and released on [3/31/2021]
    //
    //
    // If you're seeing this, just know that I have pretty much no real experience in C#. I'm still learning it, so if my explanations are
    // a little off, I apologize in advance. If that bothers you, try to enjoy it anyway.
    //
    //

    public partial class FlashDownForm : Form
    {
        private static FlashDownForm flashDownForm = null; // Main form is set to null so I can call its controls from any public classes, methods, and/or functions later on
        DispatcherTimer dispatcherTimer; // DispatcherTimer is used so it can tick on another thread
        UdpClient flashDownUdpClient = new UdpClient(7457); // Declares a UDPClient to listen on port 7457
        IPEndPoint flashDownIPEndPoint = new IPEndPoint(IPAddress.Any, 0); // Tells the UDPClient to start on all interfaces (WLAN and Ethernet)
        Settings flashDownSettings = Settings.Default; // Declares the program settings so it can be used later to store some values

        public FlashDownForm()
        {
            InitializeComponent();
            AutoUpdater.CheckForUpdateEvent += AutoUpdaterOnCheckForUpdateEvent; // My own set of instructions to do when the program checks for an update

            flashDownForm = this; // Remember when I set the main form to null? This is the second step to make the form controls accessible publicly
            // The next 3 lines of code hides the form on startup. This makes the application start in the system tray immediately
            ShowInTaskbar = false;
            WindowState = FormWindowState.Minimized;
            Hide();

            flashDownTrayIcon.Icon = Resources.AppIcon;
            flashDownTrayIcon.Visible = true;

            // The next 4 lines of code sets up and starts the DispatcherTimer
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += flashDownUdpListener;
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1); // Makes UDPClient check for incoming packets every second, on a different thread
            dispatcherTimer.Start();
        }

        public static class FlashDownVariables // I created my own class with variables in it so I can call methods easier and more efficiently
        {
            public static string startUpName = "FlashDown"; // This sets the name of the application in the startup Registry
            public static bool isInternetAvailable = true; // Will be used later to check if the user is connected to the internet
            public static RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true); // This is the startup Registry

            public static void ShutdownPC() // Command to shutdown Google™ and NASA servers. Use wisely
            {
                var shutDownCommand = new ProcessStartInfo("shutdown", "/s /t 0");
                shutDownCommand.CreateNoWindow = true;
                shutDownCommand.UseShellExecute = false;
                Process.Start(shutDownCommand);
            }

            public static void RestartPC() // Command to restart life. Wish we all had this one
            {
                var shutDownCommand = new ProcessStartInfo("shutdown", "/r");
                shutDownCommand.CreateNoWindow = true;
                shutDownCommand.UseShellExecute = false;
                Process.Start(shutDownCommand);
            }

            public static void ShowTestMessage() // Command to test if everything works properly by showing a MessageBox
            {
                MessageBox.Show("If you see this, then everything is working properly!", "Test", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
            }

            public static void LockPC() // Command that locks you up for an eternity. Recommended to use when you have a test tomorrow. You can't take a test if you can't go to school. Think smarter, not harder.
            {
                var lockScreenCommand = new ProcessStartInfo(@"C:\WINDOWS\system32\rundll32.exe", "user32.dll,LockWorkStation");
                lockScreenCommand.CreateNoWindow = true;
                lockScreenCommand.UseShellExecute = false;
                Process.Start(lockScreenCommand);
            }

            public static bool IsConnectedToInternet // Remember when I declared that boolean above? This static boolean puts it to use and returns the value
            {
                get
                {
                    return isInternetAvailable;
                }
            }

            public static string[] GetLocalIPAddress(NetworkInterfaceType networkInterfaceType) // This method will get the user's local IP Address. Credit goes to some post on StackOverflow. LOL
            {
                List<string> ipAddressList = new List<string>();
                foreach (NetworkInterface networkInterfaceItem in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (networkInterfaceItem.NetworkInterfaceType == networkInterfaceType && networkInterfaceItem.OperationalStatus == OperationalStatus.Up)
                    {
                        foreach (UnicastIPAddressInformation ip in networkInterfaceItem.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                            {
                                ipAddressList.Add(ip.Address.ToString());
                            }
                        }
                    }
                }
                return ipAddressList.ToArray();
            }

            public static void Exit() // This method makes your girlfriend exit your house. I don't have a girlfriend to begin with, so this method technically worked
            {
                flashDownForm.flashDownTrayIcon.Visible = false; // Hides the icon in the system tray so it doesn't stay there when the program exits
                Environment.Exit(0); // Because of so many different threads running, using 'Environment.Exit(0)' instead of 'Application.Exit()' results in all threads stopping and the applicaiton essentially force quitting
            }

            public static void Help() // This method asks for more information about you, hence why it's called 'About'. It asks for your SSN, home address, IQ, etc. Please note that the IQ value will only be accepted if it's in the negatives. Nice try, Einstein
            {
                flashDownForm.ShowInTaskbar = true;
                flashDownForm.WindowState = FormWindowState.Normal;
                flashDownForm.Show();
            }
        }

        private void RemoteShutdownForm_Load(object sender, EventArgs e) // Will run some code when the form loads. Even though the application starts in the system tray, the form still loads, it's just hidden from the user
        {
            AutoUpdater.Start("https://github.com/future-flash/FlashDown/FlashDownUpdate.xml"); // This is the file the program reads from my GitHub repo to see if there's an update or not
            AutoUpdater.Mandatory = true; // This line of code makes it where the user can't ignore the update prompt, hence why it's mandatory

            if (FlashDownVariables.IsConnectedToInternet == false) // Gives an error if the user is not connected to the internet
            {
                MessageBox.Show("You're not connected to the internet. This is required for FlashDown to work, otherwise it won't be able to listen for incoming packets", "No Internet Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
            }
            else if (FlashDownVariables.IsConnectedToInternet == true)
            {
                // The next part of the code checks if the user is connected via Ethernet or WiFi and gets the local IP Address
                currentIPAddressToolStripMenuItem.Text = "UDP Server: " + FlashDownVariables.GetLocalIPAddress(NetworkInterfaceType.Ethernet).FirstOrDefault() + ":7457";
                currentIPAddressLabel.Text = "IP Address: " + FlashDownVariables.GetLocalIPAddress(NetworkInterfaceType.Ethernet).FirstOrDefault() + "\r\nPort: 7457";

                if (currentIPAddressToolStripMenuItem.Text == "Current IP Address: " && currentIPAddressLabel.Text == "Current IP Address: ")
                {
                    currentIPAddressToolStripMenuItem.Text = "Current IP Address: " + FlashDownVariables.GetLocalIPAddress(NetworkInterfaceType.Wireless80211).FirstOrDefault();
                    currentIPAddressLabel.Text = "Current IP Address: " + FlashDownVariables.GetLocalIPAddress(NetworkInterfaceType.Wireless80211).FirstOrDefault();
                }
            }
        }

        private void RemoteShutdownForm_FormClosing(object sender, FormClosingEventArgs e) // [SECRET] This method minimizes the application to the system tray when the user closes the form
        {
            e.Cancel = true; // Notice how the method has the FormClosing event arguments. This line of code cancels it, preventing the form from closing
            Hide(); // Because I canceled the form from closing, I can now hide it. In other words, I stopped the form from closing to do what I want with it
        }

        private void githubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/future-flash/FlashDown");
        }

        private void notifyIcon1_MouseUp(object sender, MouseEventArgs e) // This method makes the context menu show even if the user left clicks the icon in the system tray
        {
            if (e.Button == MouseButtons.Left)
            {
                MethodInfo methodInfo = typeof(NotifyIcon).GetMethod("ShowContextMenu", BindingFlags.Instance | BindingFlags.NonPublic);
                methodInfo.Invoke(flashDownTrayIcon, null);
            }
        }

        public void flashDownUdpListener(object sender, EventArgs e) // This is the method that listens for incoming packets
        {
            Thread udpListenerThread = new Thread(
            delegate ()
            {
                try
                {
                    Byte[] commandBytes = flashDownUdpClient.Receive(ref flashDownIPEndPoint);
                    string finalCommand = Encoding.ASCII.GetString(commandBytes);

                    Console.WriteLine("Message received: " + finalCommand.ToString());
                    Console.WriteLine("From IP: " + flashDownIPEndPoint.Address.ToString() + " on port: " + flashDownIPEndPoint.Port.ToString());

                    if (finalCommand.Contains("shutdown")) // If a packet with the string 'shutdown' is receieved, the PC shuts down
                    {
                        FlashDownVariables.ShutdownPC();
                    }
                    else if (finalCommand.Contains("test")) // If a packet with the string 'test' is receieved, the system shuts down
                    {
                        FlashDownVariables.ShowTestMessage();
                    }
                    else if (finalCommand.Contains("lock")) // If a packet with the string 'lock' is receieved, the PC shows the lock screen
                    {
                        FlashDownVariables.LockPC();
                    }
                    else if (finalCommand.Contains("restart")) // If a packet with the string 'restart' is receieved, the PC restarts
                    {
                        FlashDownVariables.RestartPC();
                    }
                }
                catch (Exception flashDownUdpClientException)
                {
                    Console.WriteLine(flashDownUdpClientException.ToString());
                }
            });
            udpListenerThread.Start();
        }

        private void AutoUpdaterOnCheckForUpdateEvent(UpdateInfoEventArgs args) // This is what the program does when an update is available
        {
            if (args.Error == null)
            {
                if (args.IsUpdateAvailable)
                {
                    Enabled = false;
                    Hide();
                    AutoUpdater.ShowUpdateForm(args);
                    Application.Exit();
                }
                else
                {

                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlashDownVariables.Exit();
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlashDownVariables.Help();
        }

        private void startWithWindowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!startWithWindowsToolStripMenuItem.Checked)
            {
                flashDownSettings.startWithWindows = true;
                FlashDownVariables.registryKey.SetValue(FlashDownVariables.startUpName, Application.ExecutablePath);
                flashDownSettings.Save();
            }
            else if (startWithWindowsToolStripMenuItem.Checked)
            {
                flashDownSettings.startWithWindows = false;
                FlashDownVariables.registryKey.DeleteValue(FlashDownVariables.startUpName, false);
                flashDownSettings.Save();
            }
        }

        private void flashDownContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (flashDownSettings.startWithWindows == false)
            {
                startWithWindowsToolStripMenuItem.Checked = false;
            }
            else if (flashDownSettings.startWithWindows == true)
            {
                startWithWindowsToolStripMenuItem.Checked = true;
            }
        }

        private void versionLabel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Created by FutureFlash on 3/17/2021 and released on 3/31/2021. This program is open sourced and should always be free. If you paid for this program, you got scammed.\r\n\r\nYou can view the source code at: https://github.com/future-flash/FlashDown", "FlashDown (v1.0)", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}