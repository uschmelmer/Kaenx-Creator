﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Kaenx.Creator.Models
{
    public class ParameterRef : INotifyPropertyChanged
    {

        public ParameterRef() {}
        public ParameterRef(Parameter para) {
            IsAutoGenerated = true;
            ParameterObject = para;
            Name = para.Name;
            para.PropertyChanged += Para_PropertyChanged;
        }

        private async void Para_PropertyChanged(object sender, PropertyChangedEventArgs e = null) {
            if (e == null || e.PropertyName != "Name") return;
            Name = (sender as Parameter).Name;
        }


        private string _name = "Kurze Beschreibung";
        public string Name
        {
            get { return _name; }
            set { _name = value; Changed("Name"); }
        }

        public bool IsAutoGenerated {get;set;} = false;

        private Parameter _parameterObject;
        [JsonIgnore]
        public Parameter ParameterObject
        {
            get { return _parameterObject; }
            set { _parameterObject = value; Changed("ParameterObject"); }
        }

        [JsonIgnore]
        public string _parameter;
        public string Parameter
        {
            get { return ParameterObject?.Name; }
            set { _parameter = value; }
        }


        public ParamAccess Access { get; set; } = ParamAccess.Default;
        public string Value { get; set; } = "";
        public string Suffix { get; set; } = "";


        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        //Only used for export
        [JsonIgnore]
        public string RefId { get; set; }
    }
}
