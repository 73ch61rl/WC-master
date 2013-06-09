/* *************************************************************************
* Class:       TechniqueViewModel.cs
* Made by:     Jalen Ins team (Maimuna Syed, Olga Shakurova, Irina Smirnova)
* Country:     Finland
* Year:        2013
* ------------------------------------------------------------------------
* Application: KIAI!
* Description: Self-defence guide for women
* Competition: Imagine Cup - Women's Athletic App Challenge
* Category:    Sport
* 
************************************************************************* */
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Net;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Ink;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;

    namespace WChallenge
    {
        public class TechniqueViewModel  :INotifyPropertyChanged
        {
            public int Id { get; set; }
            private string _name;

            public string Name
            {
                get
                {
                    return _name;
                }
                set
                {
                    if (value != _name)
                    {
                        _name = value;
             
                    }
                }
            }

            private Uri _videoLink;
            public Uri VideoLink
            {
                get
                {
                    return _videoLink;
                }
                set
                {
                    if (value != _videoLink)
                    {
                        _videoLink = value;
                 
                    }
                }
            }

            private Uri _imageLink;
            public Uri ImageLink
            {
                get
                {
                    return _imageLink;
                }
                set
                {
                    if (value != _imageLink)
                    {
                        _imageLink = value;
                
                    }
                }
            }

            private Uri _thumb;
            public Uri Thumb
            {
                get
                {
                    return _thumb;
                }
                set
                {
                    if (value != _thumb)
                    {
                        _thumb = value;
                
                    }
                }
            }

            private double _percentageDone;
            public double percentageDone
            {
                get
                {
                    return _percentageDone;
                }
                set
                {
                    if (value != _percentageDone)
                    {
                        _percentageDone = value;
                        NotifyPropertyChanged("PercentageDone");
                        onPropertyChanged(this, "PercentageDone");
                  
                    }
                }
            }

            private string _description;

            public string Description
            {
                get
                {
                    return _description;
                }
                set
                {
                    if (value != _description)
                    {
                        _description = value;
                   
                    }
                }
            }

            private ObservableCollection<StepViewModel> _step;

            public ObservableCollection<StepViewModel> Step
            {
                get
                {
                    return _step;
                }
                set
                {
                    if (value != _step)
                    {
                        _step = value;
                        NotifyPropertyChanged("Step");
                        onPropertyChanged(this, "Step");
                 
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(String percentageDone)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (null != handler)
                {
                    handler(this, new PropertyChangedEventArgs(percentageDone));
                }
            }

            private void onPropertyChanged(object sender, string propertyName)
            {
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
                }
            }
        }

        public class StepViewModel : INotifyPropertyChanged
        {
            private string _description;

            public string Description
            {
                get
                {
                    return _description;
                }
                set
                {
                    if (value != _description)
                    {
                        _description = value;
                    }
                }
            }



            private Boolean _done;

            public Boolean Done
            {
                get
                {
                    return _done;
                }
                set
                {
                    if (value != _done)
                    {
                        _done = value;
                        NotifyPropertyChanged("Done");
                       onPropertyChanged(this, "Done");
                    }
                }
            }

            public event PropertyChangedEventHandler PropertyChanged;

            private void NotifyPropertyChanged(String percentageDone)
            {
                PropertyChangedEventHandler handler = PropertyChanged;
                if (null != handler)
                {
                    handler(this, new PropertyChangedEventArgs(percentageDone));
                }
            }

            private void onPropertyChanged(object sender, string propertyName)
            {
                if (this.PropertyChanged != null)
                {
                    PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }