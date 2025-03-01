﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Kaenx.Creator.Models.Dynamic
{
    public class DynChannel : IDynItems, IDynChannel, INotifyPropertyChanged
    {
        [JsonIgnore]
        public IDynItems Parent { get; set; }

        private string _name = "";
        public string Name
        {
            get { return _name; }
            set { _name = value; Changed("Name"); }
        }

        private string _number = "0";
        public string Number
        {
            get { return _number; }
            set { _number = value; Changed("Number"); }
        }

        public ObservableCollection<Translation> Text {get;set;} = new ObservableCollection<Translation>();

        private bool _transText = false;
        public bool TranslationText
        {
            get { return _transText; }
            set { _transText = value; Changed("TranslationText"); }
        }

        private bool _useTextParam = false;
        public bool UseTextParameter
        {
            get { return _useTextParam; }
            set { _useTextParam = value; Changed("UseTextParameter"); }
        }

        private ParameterRef _parameterRefObject;
        [JsonIgnore]
        public ParameterRef ParameterRefObject
        {
            get { return _parameterRefObject; }
            set { _parameterRefObject = value; Changed("ParameterRefObject"); }
        }

        [JsonIgnore]
        public int _parameter;
        public int ParameterRef
        {
            get { return ParameterRefObject?.UId ?? -1; }
            set { _parameter = value; }
        }


        public ObservableCollection<IDynItems> Items { get; set; } = new ObservableCollection<IDynItems>();

        public event PropertyChangedEventHandler PropertyChanged;

        private void Changed(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
