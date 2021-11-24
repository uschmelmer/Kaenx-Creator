﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Kaenx.Creator.Models
{
    public class ComObjectRef : INotifyPropertyChanged
    {

        public ComObjectRef() {}
        public ComObjectRef(ComObject com) {
            IsAutoGenerated = true;
            ComObjectObject = com;
            com.PropertyChanged += Com_PropertyChanged;
        }


        private async void Com_PropertyChanged(object sender, PropertyChangedEventArgs e = null) {
            if (e == null || e.PropertyName != "Name") return;
            Name = (sender as ComObject).Name;
        }

        public bool IsAutoGenerated {get;set;} = false;
        
        private int _id = -1;
        public int Id
        {
            get { return _id; }
            set { _id = value; Changed("Id"); }
        }

        private string _name = "Kurze Beschreibung";
        public string Name
        {
            get { return _name; }
            set { _name = value; Changed("Name"); }
        }

        private string _func = "";
        public string FunctionText
        {
            get { return _func; }
            set { _func = value; Changed("FunctionText"); }
        }

        private bool _overFunc = false;
        public bool OverwriteFunctionText
        {
            get { return _overFunc; }
            set { _overFunc = value; Changed("OverwriteFunctionText"); }
        }

        private string _desc = "";
        public string Description
        {
            get { return _desc; }
            set { _desc = value; Changed("Description"); }
        }

        private bool _overDesc = false;
        public bool OverwriteDescription
        {
            get { return _overDesc; }
            set { _overDesc = value; Changed("OverwriteDescription"); }
        }

        private bool _overDpt = false;
        public bool OverwriteDpt
        {
            get { return _overDpt; }
            set { _overDpt = value; Changed("OverwriteDpt"); }
        }

        private bool _overDpst = false;
        public bool OverwriteDpst
        {
            get { return _overDpst; }
            set { _overDpst = value; Changed("OverwriteDpst"); }
        }

        private ComObject _comObjectObject;
        [JsonIgnore]
        public ComObject ComObjectObject
        {
            get { return _comObjectObject; }
            set { _comObjectObject = value; Changed("ComObjectObject"); }
        }


        private string _typeValue;
        public string TypeValue
        {
            get { return _typeValue; }
            set { if (value == null) return;  _typeValue = value; Changed("TypeValue"); }
        }

        private string _typeParentValue;
        public string TypeParentValue
        {
            get { return _typeParentValue; }
            set { _typeParentValue = value; Changed("TypeParentValue"); }
        }

        private DataPointSubType _type;
        public DataPointSubType Type
        {
            get { return _type; }
            set { if (value == null) return; _type = value; Changed("Type"); }
        }



        [JsonIgnore]
        public string _comObject;
        public string ComObject
        {
            get { return ComObjectObject?.Name; }
            set { _comObject = value; }
        }

        private FlagType _flagRead = FlagType.Default;
        public FlagType FlagRead
        {
            get { return _flagRead; }
            set { _flagRead = value; Changed("FlagRead"); }
        }

        private FlagType _flagWrite =  FlagType.Default;
        public FlagType FlagWrite
        {
            get { return _flagWrite; }
            set { _flagWrite = value; Changed("FlagWrite"); }
        }

        private FlagType _flagTrans = FlagType.Default;
        public FlagType FlagTrans
        {
            get { return _flagTrans; }
            set { _flagTrans = value; Changed("FlagTrans"); }
        }

        private FlagType _flagComm = FlagType.Default;
        public FlagType FlagComm
        {
            get { return _flagComm; }
            set { _flagComm = value; Changed("FlagComm"); }
        }

        private FlagType _flagUpdate = FlagType.Default;
        public FlagType FlagUpdate
        {
            get { return _flagUpdate; }
            set { _flagUpdate = value; Changed("FlagUpdate"); }
        }

        private FlagType _flagOnInit = FlagType.Default;
        public FlagType FlagOnInit
        {
            get { return _flagOnInit; }
            set { _flagOnInit = value; Changed("FlagOnInit"); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void Changed(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
