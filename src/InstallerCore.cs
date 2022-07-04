/*
WinWin Installer Lite Core

See LICENSE file for usage permissions. Make sure to read LICENSE file before using code!!!

Copyright (c) 2022 mrfakename. All rights reserved.

Last update: 7-4-2022 11:36 AM PDT
*/
private static void Install(String appName, String appLocation, String appURL, String appNameExe) {
    if (System.IO.Directory.Exists(appLocation)) {
        MessageBox.Show(appName + " is already installed, please uninstall it and run the installer again if you would like to reinstall it. The program folder is located at: " + appLocation + ". Installation canceled.");
    } else {
        if (MessageBox.Show("Install " + appName + "?", "Install?", MessageBoxButtons.YesNo) == DialogResult.Yes) {
            MessageBox.Show("About to download and install. This will take a minute.");
            System.IO.Directory.CreateDirectory(appLocation);
            using(System.Net.WebClient webClient = new System.Net.WebClient()) { webClient.DownloadFile(new Uri(appURL), appLocation + appName); }
            MessageBox.Show("Completely Installed ! Success ! Press OK to start " + appName + " ! ");
            System.Diagnostics.Process.Start(appLocation + appNameExe);
            Environment.Exit(0);
        } else {
            MessageBox.Show(appName + " was not installed!");
        }
    }
}
