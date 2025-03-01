﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Kaenx.Creator.Models.Dynamic
{
    public class DynWhenBlock : IDynWhen, INotifyPropertyChanged
    {
        [JsonIgnore]
        public IDynItems Parent { get; set; }

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; Changed("Name"); }
        }

        private bool _isDefault = false;
        public bool IsDefault
        {
            get { return _isDefault; }
            set { _isDefault = value; Changed("IsDefault"); }
        }

        private string _condition = "";
        public string Condition
        {
            get { return _condition; }
            set { _condition = value; Changed("Condition"); }
        }

        public ObservableCollection<IDynItems> Items { get; set; } = new ObservableCollection<IDynItems>();
        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

}