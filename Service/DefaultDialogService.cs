﻿using Microsoft.Win32;
using System.Windows;

namespace WorkMVVM
{
    public class DefaultDialogService : IDialogService
    {
        public string FilePath { get; set; }

        public bool OpenFileDialog()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                FilePath = openFileDialog.FileName;
                return true;
            }
            return false;
        }

        public bool SaveFileDialog()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if (saveFileDialog.ShowDialog() == true)
            {
                FilePath = saveFileDialog.FileName;
                return true;
            }
            return false;
        }

        //public void AddAccountsWindow()
        //{
        //    AddAccountWindow addAccountWindow = new AddAccountWindow();
        //    addAccountWindow.ShowDialog();
        //}

        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }
    }
}
