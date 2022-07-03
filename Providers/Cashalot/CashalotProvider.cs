using CashalotHelper.Models;
using CashalotHelper.Providers.Interfaces;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace CashalotHelper.Providers
{
    public class CashalotProvider : ICashalotProvider
    {
        private List<Cashalot> _programs;
        public List<Cashalot> Programs => _programs ??= new List<Cashalot>();

        public CashalotProvider()
        {
            Initialize();
        }

        private void Initialize()
        {
            bool EmptyUserKey = true;
            bool EmptyMachineKey = true;
            try
            {
                RegistryKey MachineKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE");
                if (MachineKey.GetSubKeyNames().Contains("Cashalot"))
                {
                    MachineKey = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Cashalot");
                    if (MachineKey.SubKeyCount != 0)
                    {
                        foreach (String keyName in MachineKey.GetSubKeyNames())
                        {
                            if (keyName != "Cashalot")
                            {
                                if (Directory.Exists(MachineKey.OpenSubKey(keyName).GetValue("PATH").ToString()))
                                {
                                    Programs.Add(new Cashalot(keyName, MachineKey.OpenSubKey(keyName).GetValue("PATH").ToString(), true));
                                    EmptyMachineKey = false;
                                }
                            }
                        }
                    }

                }
            }
            catch { }

            try
            {
                RegistryKey UserKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE");
                if (UserKey.GetSubKeyNames().Contains("Cashalot"))
                {
                    UserKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\Cashalot");
                    if (UserKey.SubKeyCount != 0)
                    {
                        foreach (String keyName in UserKey.GetSubKeyNames())
                        {
                            if (keyName != "Cashalot")
                            {
                                if (Directory.Exists(UserKey.OpenSubKey(keyName).GetValue("PATH").ToString()))
                                {
                                    Programs.Add(new Cashalot(keyName, UserKey.OpenSubKey(keyName).GetValue("PATH").ToString(), false));
                                    EmptyUserKey = false;
                                }
                            }
                        }
                    }
                }
            }
            catch { }
            if (EmptyMachineKey && EmptyUserKey)
            {
                MessageBox.Show("Cashalot на этом ПК не обнаружен");
            }
        }
    
    }
}
