using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace WChallenge
{
    public class FightStyle : INotifyPropertyChanged
    {
        public int id { get; set; }

        private string _fightStyleName;
        private string _fightStyleDesc;
        private Uri _fightStyleLink;
        private bool isNonExpandable = false;

        public bool IsNonExpandable
        {
            get { return isNonExpandable; }
            set
            {
                isNonExpandable = value;
                NotifyPropertyChanged();
            }
        }

        public string FightStyleName
        {
            get
            {
                return _fightStyleName;
            }
            set
            {
                if (value != _fightStyleName)
                {
                    _fightStyleName = value;
                    NotifyPropertyChanged();

                }
            }
        }

        public string FightStyleDesc
        {
            get
            {
                return _fightStyleDesc;
            }
            set
            {
                if (value != _fightStyleDesc)
                {
                    _fightStyleDesc = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public Uri FightStyleLink
        {
            get
            {
                return _fightStyleLink;
            }
            set
            {
                if (value != _fightStyleLink)
                {
                    _fightStyleLink = value;
                    NotifyPropertyChanged();

                }
            }
        }

        public ObservableCollection<FightStyle> FightStyleAsCollection
        {
            get { return new ObservableCollection<FightStyle>() { this }; }
        }

        
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
