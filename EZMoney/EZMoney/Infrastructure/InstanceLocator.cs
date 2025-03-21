
using System;
using System.Collections.Generic;
using System.Text;
using EZMoney.ViewModels;

namespace EZMoney.Infrastructure
{
    public class InstanceLocator
    {
        public MainViewModel Main { get; set; }

        public InstanceLocator()
        {
            this.Main = new MainViewModel();
        }
    }
}
