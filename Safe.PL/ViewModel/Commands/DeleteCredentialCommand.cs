﻿using Safe.BL;
using Safe.BL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Safe.PL.ViewModel.Commands
{
    public class DeleteCredentialCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Credential credential = parameter as Credential;

            Main.Instance.DeleteCredential(credential);
        }
    }
}