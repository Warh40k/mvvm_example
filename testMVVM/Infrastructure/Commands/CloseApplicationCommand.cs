﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using testMVVM.Infrastructure.Commands.Base;

namespace testMVVM.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        public override bool CanExecute(object parameter) => true;
        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
