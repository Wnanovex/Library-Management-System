using LibraryManagementSystem.BLL;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows.Forms;

namespace DVLD.Global_Classes
{
    internal static class clsGlobal {

        public static clsUser CurrentUser;

        private static string registryPath = @"SOFTWARE\LibrarySystem";

        public static void RememberUsernameAndPassword(string username, string password) {
            try {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(registryPath);

                if (key != null) {
                    key.SetValue("Username", username);
                    key.SetValue("Password", password);
                    key.Close();
                }
            }catch (Exception ex) {
                // Handle exception (optional)
                Console.WriteLine("Error saving credentials: " + ex.Message);
            }
        }

        public static void GetRememberedUsernameAndPassword(out string username, out string password) {
            username = "";
            password = "";

            try {
                RegistryKey key = Registry.CurrentUser.OpenSubKey(registryPath);
                if (key != null) {
                    username = key.GetValue("Username", "").ToString();
                    password = key.GetValue("Password", "").ToString();
                    key.Close();
                }
            }catch (Exception ex) {
                Console.WriteLine("Error retrieving credentials: " + ex.Message);
            }
        }

        //public static bool RememberUsernameAndPassword(string Username, string Password) {
        //    try {
        //        //this will get the current project directory folder.
        //        string currentDirectory = System.IO.Directory.GetCurrentDirectory();

        //        // Define the path to the text file where you want to save the data
        //        string filePath = currentDirectory + "\\data.txt";

        //        //incase the username is empty, delete the file
        //        if (Username=="" && File.Exists(filePath)) { 
        //             File.Delete(filePath);
        //            return true;
        //        }

        //        // concatonate username and passwrod withe seperator.
        //        string dataToSave = Username + "#//#"+Password ;

        //        // Create a StreamWriter to write to the file
        //        using (StreamWriter writer = new StreamWriter(filePath)) {
        //            // Write the data to the file
        //            writer.WriteLine(dataToSave);                  
        //            return true;
        //        }
        //    }catch (Exception ex){
        //       MessageBox.Show ($"An error occurred: {ex.Message}");
        //        return false;
        //    }
        //}

        public static bool GetStoredCredential(ref string Username, ref string Password) {
            //this will get the stored username and password and will return true if found and false if not found.
            try {
                //gets the current project's directory
                string currentDirectory = System.IO.Directory.GetCurrentDirectory();

                // Path for the file that contains the credential.
                string filePath  = currentDirectory + "\\data.txt";

                // Check if the file exists before attempting to read it
                if (File.Exists(filePath)) {
                    // Create a StreamReader to read from the file
                    using (StreamReader reader = new StreamReader(filePath)) {
                        // Read data line by line until the end of the file
                        string line;
                        while ((line = reader.ReadLine()) != null) {
                            Console.WriteLine(line); // Output each line of data to the console
                            string[] result = line.Split(new string[] { "#//#" }, StringSplitOptions.None);

                            Username = result[0];
                            Password = result[1];
                        }
                        return true;
                    }
                }else
                    return false;
            }catch (Exception ex){
                MessageBox.Show ($"An error occurred: {ex.Message}");
                return false;   
            }
        }

    }
}
