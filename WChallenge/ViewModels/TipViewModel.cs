using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace WChallenge
{
    public class TipViewModel : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string _tipName;

        public string TipName
        {
            get
            {
                return _tipName;
            }
            set
            {
                if (value != _tipName)
                {
                    _tipName = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private string _tipDescription;

        public string TipDescription
        {
            get
            {
                return _tipDescription;
            }
            set
            {
                if (value != _tipDescription)
                {
                    _tipDescription = value;
                    NotifyPropertyChanged();
                }
            }
        }

        // http://msdn.microsoft.com/en-us/library/system.componentmodel.inotifypropertychanged.aspx

        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property. 
        // The CallerMemberName attribute that is applied to the optional propertyName 
        // parameter causes the property name of the caller to be substituted as an argument. 
        // http://msdn.microsoft.com/query/dev11.query?appId=Dev11IDEF1&l=EN-US&k=k(System.Runtime.CompilerServices.CallerMemberNameAttribute);k(TargetFrameworkMoniker-Silverlight,Version%3Dv4.0);k(DevLang-csharp)&rd=true
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}
