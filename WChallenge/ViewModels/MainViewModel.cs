using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices;
using WChallenge;


namespace WChallenge
{
    public class MainViewModel : INotifyPropertyChanged 
    {
        public ObservableCollection<TechnicViewModel> Items { get; private set; }
        public ObservableCollection<StepViewModel> Steps { get; private set; }

        public MainViewModel()
        {
            this.Items = new ObservableCollection<TechnicViewModel>();
            this.Steps = new ObservableCollection<StepViewModel>();
         }
         

        private string _sampleProperty = "Sample Runtime Property Value"; 
        public string SampleProperty
        {
            get
            {
                return _sampleProperty;
            }
            set
            {
                if (value != _sampleProperty)
                {
                    _sampleProperty = value;
                    NotifyPropertyChanged("SampleProperty");
                }
            }
        }

        public bool IsDataLoaded
        {
            get;
            private set;
        }

 
        public async void LoadData()
        {
            // Sample data; replace with real data
            this.Steps.Add(new StepViewModel() { Description="If a stranger grabbed your hand, raise your other hand", Done=false});
            this.Steps.Add(new StepViewModel() { Description = "Pull your fingers back", Done = false });
            this.Steps.Add(new StepViewModel() { Description = "Strike to a nose", Done = false });
            this.Steps.Add(new StepViewModel() { Description = "3. If the attacker is larger than you try to strike some other sensitive areas like a face", Done = false });
           
            this.Items.Add(new TechnicViewModel() { Id=0, Steps =Steps, Name = "Nose Punch", Description = "Striking the nose.", VideoLink = new Uri("http://www.google.com/url?q=https://www.youtube.com/watch%3Fv%3DAwvfFWDtOZE&usd=2&usg=ALhdy282StejPxMnGxXpl6Gt7ScPUVoakg"), percentageDone = 20, ImageLink = new Uri("http://goo.gl/zDsV3")});

            Steps.Clear();
		    this.Steps.Add(new StepViewModel() { Description="If a stranger grabbed your wrests move your hands towards outside in a small circle", Done=false});
            this.Steps.Add(new StepViewModel() { Description = "Push away in a dirrection of your attacker's stomack", Done = false });
            
            this.Items.Add(new TechnicViewModel() {Id=1, Steps =Steps, Name = "Wrist Lock Getaway", Description = "Getting away if your wrests are kept", percentageDone = 54 });
            
            Steps.Clear();
			 this.Steps.Add(new StepViewModel() { Description="When an arm comes toward you use your forearms to block it putting one hand at a forearm and one hand above the elbow", Done=false});
            this.Steps.Add(new StepViewModel() { Description = "Wrap your hand around the neck", Done = false });
            this.Steps.Add(new StepViewModel() { Description = "Pull it down", Done = false });
            this.Steps.Add(new StepViewModel() { Description = "Grab a wrest", Done = false });
            this.Steps.Add(new StepViewModel() { Description = "Strike with your knee to a stomach or a groin", Done = false });

            
			this.Items.Add(new TechnicViewModel() { Id=2,Name = "Swing Defence", Description = "Defending if someone swings at you.", percentageDone = 60 });

            Steps.Clear();
		    this.Steps.Add(new StepViewModel() { Description="If an attacker has his hands around your neck bring your left hand over his hand.", Done=false});
            this.Steps.Add(new StepViewModel() { Description = "Grab his wrist", Done = false });
            this.Steps.Add(new StepViewModel() { Description = "Use your elbow to push down his elbow", Done = false });
            this.Steps.Add(new StepViewModel() { Description = "Bring your right hand in a circle twisting your body", Done = false });
            this.Steps.Add(new StepViewModel() { Description = "Use your elbow to strike in a face area", Done = false });
          
		   this.Items.Add(new TechnicViewModel() { Id=3,Steps=Steps, Name = "Choke Escape", Description = "Escaping from a choke", percentageDone = 80 });

           Steps.Clear();
			this.Steps.Add(new StepViewModel() { Description="If an attacker has his hands around your neck bring your left hand over his hand.", Done=false});
            this.Steps.Add(new StepViewModel() { Description = "Grab his wrist", Done = false });
            this.Steps.Add(new StepViewModel() { Description = "Use your elbow to push down his elbow", Done = false });
            this.Steps.Add(new StepViewModel() { Description = "Bring your right hand in a circle twisting your body", Done = false });
            this.Steps.Add(new StepViewModel() { Description = "Use your elbow to strike in a face area", Done = false });
          
		   this.Items.Add(new TechnicViewModel() { Id=4,Steps=Steps, Name = "Choke Escape", Description = "Escaping from a choke", percentageDone = 80 });
    
	 
	
	//      await App.MobileService.GetTable<TechnicViewModel>().InsertAsync(Items[1]);
              //Item item = new Item { Text = "Awesome item" }; 
            //await App.MobileService.GetTable<Item>().InsertAsync(item);
             
            this.IsDataLoaded = true;
        }


       // public class Item { public int Id { get; set; } public string Text { get; set; } }
       

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}