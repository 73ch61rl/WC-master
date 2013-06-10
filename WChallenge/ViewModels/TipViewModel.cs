using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WChallenge
{
    public class TipViewModel
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

                }
            }
        }
    }
}
