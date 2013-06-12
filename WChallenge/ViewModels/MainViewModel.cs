/***************************************************************************
 * Class:       MainViewModel.cs
 * Made by:     Jalen Ins team (Maimuna Syed, Olga Shakurova, Irina Smirnova)
 * Country:     Finland
 * Year:        2013
 * -------------------------------------------------------------------------
 * Application: KIAI!
 * Description: Self-defence guide for women
 * Competition: Imagine Cup - Women's Athletic App Challenge
 * Category:    Sport
 * 
 ***************************************************************************/

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
using System.Windows.Threading;


namespace WChallenge
{
    public class MainViewModel : INotifyPropertyChanged
    {
        
        public ObservableCollection<TechniqueViewModel> Items { get; private set; }
        // public ObservableCollection<StepViewModel> Steps { get; private set; }
        public ObservableCollection<StepViewModel> Steps { get; private set; }
        public ObservableCollection<TipViewModel> Tips { get; private set; }
        public ObservableCollection<TipViewModel> RandomTips { get; private set; }

        private DispatcherTimer dispatcherTimer;



        public MainViewModel()
        {
            this.Items = new ObservableCollection<TechniqueViewModel>();
            // this.Steps = new ObservableCollection<StepViewModel>();
            this.Tips = new ObservableCollection<TipViewModel>();
            this.RandomTips = new ObservableCollection<TipViewModel>();
            this.dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = TimeSpan.FromSeconds(20);
            dispatcherTimer.Tick += dispatcherTimer_Tick;
            dispatcherTimer.Start();
        }

        void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            RandomizeRandomTip();
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
            //1 technic - nose punch
            this.Items.Add(new TechniqueViewModel()
            {
                Id = 1,
                Step = new ObservableCollection<StepViewModel>() {
                                        new StepViewModel() { Description="If a stranger grabbed your hand, raise your other hand", Done=false},
                                        new StepViewModel() { Description = "Pull your fingers back", Done = false },
                                        new StepViewModel() { Description = "Strike to a nose", Done = false },
                                        new StepViewModel() { Description = "If the attacker is larger than you try to strike some other sensitive face area", Done = false }
                            },
                Name = "Face punch",
                Description = "Learn how to strike to a nose or other face area.",
                VideoLink = new Uri("https://www.youtube.com/watch?v=AwvfFWDtOZE"),
                ImageLink = new Uri("Assets/face_punch.jpg", UriKind.Relative),
                Thumb = new Uri("Assets/face_punch.jpg", UriKind.Relative),
                percentageDone = 0
            });

            //2 technic - swing defence
            var technic2Steps = new ObservableCollection<StepViewModel>();
            technic2Steps.Add(new StepViewModel() { Description = "When an arm comes toward you use your forearms to block it putting one hand at a forearm and one hand above the elbow", Done = false });
            technic2Steps.Add(new StepViewModel() { Description = "Wrap your hand around the neck", Done = false });
            technic2Steps.Add(new StepViewModel() { Description = "Pull it down", Done = false });
            technic2Steps.Add(new StepViewModel() { Description = "Grab a wrest", Done = false });
            technic2Steps.Add(new StepViewModel() { Description = "Strike with your knee to a stomach or a groin", Done = false });


            this.Items.Add(new TechniqueViewModel()
            {
                Id = 2,
                Step = technic2Steps,
                Name = "Swing defence",
                Description = "Defending if someone swings at you.",
                VideoLink = new Uri("https://www.youtube.com/watch?v=AwvfFWDtOZE"),
                ImageLink = new Uri("/Assets/swing.jpg", UriKind.Relative),
                Thumb = new Uri("/Assets/swing.jpg", UriKind.Relative),
                percentageDone = 0

            });

            //3 technic - horse stance
            var technic3Steps = new ObservableCollection<StepViewModel>();
            technic3Steps.Add(new StepViewModel() { Description = "Stand with your feet about 2 shoulder widths apart", Done = false });
            technic3Steps.Add(new StepViewModel() { Description = "Lift heels behind your toes", Done = false });
            technic3Steps.Add(new StepViewModel() { Description = "Come down, make sure that you keep your feet parallel and your upper body straight and vertical", Done = false });
            technic3Steps.Add(new StepViewModel() { Description = "Put your fists back next to your side", Done = false });
            technic3Steps.Add(new StepViewModel() { Description = "If you get a bear hug from behind do not panick, just drop in your horse stance to get free", Done = false });

            this.Items.Add(new TechniqueViewModel()
            {
                Id = 3,
                Step = technic3Steps,
                Name = "Horse stance",
                Description = "The basic stance you can meet in all martial arts.",
                VideoLink = new Uri("http://www.youtube.com/watch?v=kTSgnaG3mhg"),
                ImageLink = new Uri("/Assets/horse_stance.jpg", UriKind.Relative),
                Thumb = new Uri("/Assets/horse_stance.jpg", UriKind.Relative),
                percentageDone = 0
            });

            //4 technic - palm heel strike to nose in a horse stance
            var technic4Steps = new ObservableCollection<StepViewModel>();
            technic4Steps.Add(new StepViewModel() { Description = "Get into a horse stance", Done = false });
            technic4Steps.Add(new StepViewModel() { Description = "Open your hands", Done = false });
            technic4Steps.Add(new StepViewModel() { Description = "Push you heels a little forward and pull fingers a little back", Done = false });
            technic4Steps.Add(new StepViewModel() { Description = "Hit an attacker to the nose with one hand", Done = false });
            technic4Steps.Add(new StepViewModel() { Description = "Hit with the ohther hand", Done = false });


            this.Items.Add(new TechniqueViewModel()
            {
                Id = 4,
                Name = "Palm heel strike in a horse stance",
                Description = "Practicing palm heel strike being in horse stance",
                VideoLink = new Uri("http://www.youtube.com/watch?v=SZO9iX1vRsM"),
                ImageLink = new Uri("/Assets/palm_heel.jpg", UriKind.Relative),
                Thumb = new Uri("/Assets/palm_heel.jpg", UriKind.Relative),
                percentageDone = 0,
                Step = technic4Steps
            });

            //5 technic - front choke escape using elbow strike
            var technic5Steps = new ObservableCollection<StepViewModel>();
            technic5Steps.Add(new StepViewModel() { Description = "If an attacker has his hands around your neck bring your left hand over his hand.", Done = false });
            technic5Steps.Add(new StepViewModel() { Description = "Grab his wrist", Done = false });
            technic5Steps.Add(new StepViewModel() { Description = "Use your elbow to push down his elbow", Done = false });
            technic5Steps.Add(new StepViewModel() { Description = "Bring your right hand in a circle twisting your body", Done = false });
            technic5Steps.Add(new StepViewModel() { Description = "Use your elbow to strike in a face area", Done = false });

            this.Items.Add(new TechniqueViewModel()
            {
                Id = 5,
                Step = technic5Steps,
                Name = "Front choke escape with elbow strike",
                Description = "Escaping from a choke",
                VideoLink = new Uri("http://www.youtube.com/watch?v=CD8Sex72UVw"),
                ImageLink = new Uri("/Assets/choke_elbow.jpg", UriKind.Relative),
                Thumb = new Uri("/Assets/chokee_elbow.jpg", UriKind.Relative),
                percentageDone = 0
            });

            /*//5 technic - front choke release move using hammer strike
            var technic3Steps = new ObservableCollection<StepViewModel>();
            technic3Steps.Add(new StepViewModel() { Description = "If an attacker has his hands around your neck bring your left hand over his hand.", Done = false });
            technic3Steps.Add(new StepViewModel() { Description = "Grab his wrist", Done = false });
            technic3Steps.Add(new StepViewModel() { Description = "Use your elbow to push down his elbow", Done = false });
            technic3Steps.Add(new StepViewModel() { Description = "Bring your right hand in a circle twisting your body", Done = false });
            technic3Steps.Add(new StepViewModel() { Description = "Use your elbow to strike in a face area", Done = false });

            this.Items.Add(new TechniqueViewModel()
            {
                Id = 5,
                Step = technic3Steps,
                Name = "Choke Escape",
                Description = "Escaping from a choke",
                VideoLink = new Uri("http://www.youtube.com/watch?v=CD8Sex72UVw"),
                ImageLink = new Uri("http://goo.gl/zDsV3"),
                Thumb = new Uri("http://img.youtube.com/vi/SZO9iX1vRsM/0.jpg"),
                percentageDone = 0
            });*/

            //6 technic - basic kick
            var technic6Steps = new ObservableCollection<StepViewModel>();
            technic6Steps.Add(new StepViewModel() { Description = "Spread your feet apart.", Done = false });
            technic6Steps.Add(new StepViewModel() { Description = "Bend your knees.", Done = false });
            technic6Steps.Add(new StepViewModel() { Description = "Take your hands back.", Done = false });
            technic6Steps.Add(new StepViewModel() { Description = "Lift your knee.", Done = false });
            technic6Steps.Add(new StepViewModel() { Description = "Extend your leg.", Done = false });
            technic6Steps.Add(new StepViewModel() { Description = "Bring your knee back..", Done = false });
            technic6Steps.Add(new StepViewModel() { Description = "Come down.", Done = false });

            this.Items.Add(new TechniqueViewModel()
            {
                Id = 6,
                Step = technic6Steps,
                Name = "Basic Kick",
                VideoLink = new Uri("http://www.youtube.com/watch?v=yKEy3tEhCog"),
                ImageLink = new Uri("/Assets/basic_kick.jpg", UriKind.Relative),
                Thumb = new Uri("/Assets/basic_kick.jpg", UriKind.Relative),
                percentageDone = 0
            });

            //7 technic - defence with high heels and keys
            var technic7Steps = new ObservableCollection<StepViewModel>();
            technic7Steps.Add(new StepViewModel() { Description = "Take your shoes off.", Done = false });
            technic7Steps.Add(new StepViewModel() { Description = "Put  the shoe on your hand to protect yourself around your wrist", Done = false });
            technic7Steps.Add(new StepViewModel() { Description = "Turn the shoe around and use it with your hammer strike (to the eye, groin)", Done = false });
            technic7Steps.Add(new StepViewModel() { Description = "Before going to your car always take your keys out of the purse, so that you are not fumbling for them", Done = false });
            technic7Steps.Add(new StepViewModel() { Description = "Carry a pepper spray on your keychain and in case of an attack shoot at a safe distance", Done = false });

            this.Items.Add(new TechniqueViewModel()
            {
                Id = 7,
                Step = technic7Steps,
                Name = "Self defence with heels and a keychain",
                Description = "Using objects from your lady bag or shoes for defence in everyday life.",
                VideoLink = new Uri("http://www.youtube.com/watch?v=IYjd0pTsqyw"),
                ImageLink = new Uri("/Assets/heels_key_defence.jpg", UriKind.Relative),
                Thumb = new Uri("/Assets/heels_key_defence.jpg", UriKind.Relative),
                percentageDone = 0
            });

            //Safety tips
            //1
            this.Tips.Add(new TipViewModel()
            {
                TipName = "Look confident",
                TipDescription = "Even looking strong and confident can prevent you from being approached"
            });
            //2
            this.Tips.Add(new TipViewModel()
            {
                TipName = "Breathe",
                TipDescription = "If you find yourself in a situation where you have to defend yourself, remember to breathe"
            });
            //3
            this.Tips.Add(new TipViewModel()
            {
                TipName = "Train",
                TipDescription = "Once the body starts dumping adrenaline into your system, all your analytical thinking and motor skills are gone. All you're left with is any repetitive training your body has learned"
            });
            //4
            this.Tips.Add(new TipViewModel()
            {
                TipName = "Fight smart",
                TipDescription = "Use your strengths against vulnerabilities: nose, ears, throat, groin"
            });
            //5
            this.Tips.Add(new TipViewModel()
            {
                TipName = "Yell",
                TipDescription = "Yelling increases power as much as 33 percent and can attract help"
            });
            //6
            this.Tips.Add(new TipViewModel()
            {
                TipName = "Fight!",
                TipDescription = "Women who resist attacks and act quickly are less likely to be raped, than those who are passive"
            });
            //7
            this.Tips.Add(new TipViewModel()
            {
                TipName = "React!",
                TipDescription = "The optimum time to react is in the first 20 seconds when the body releases chemicals in the blood that help to put up a fight. Be cautious if he has a weapon"
            });
            //8
            this.Tips.Add(new TipViewModel()
            {
                TipName = "Run",
                TipDescription = "Only run if there is somewhere safe to run to. If there is no where to go you may aggravate the assailant further by running"
            });
            //9
            this.Tips.Add(new TipViewModel()
            {
                TipName = "Low stances",
                TipDescription = "Low stances, most often seen in traditional karate and in northern styles of Chinese boxing, are very helpful in self-defense but only if understood and practiced well"
            });
            //10
            this.Tips.Add(new TipViewModel()
            {
                TipName = "Kick smart",
                TipDescription = "If you kick someone, kick only their groin, kneecaps or shins to keep a steady balance"
            });

            RandomizeRandomTip();

            ObservableCollection<TechniqueViewModel> Items;
            Items = App.ViewModel.Items;
            float doneNr;
            foreach (TechniqueViewModel t in Items)
            {
                doneNr = 0;
                foreach (StepViewModel s in t.Step)
                {
                    if (s.Done) { doneNr++; }
                }
                t.percentageDone = Convert.ToDouble((doneNr / t.Step.Count) * 100);
            } 

            this.IsDataLoaded = true;
        }

        public void RandomizeRandomTip()
        {
            Random rdm = new Random();
            this.RandomTips.Clear();
            this.RandomTips.Add(Tips[rdm.Next(Tips.Count)]);
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