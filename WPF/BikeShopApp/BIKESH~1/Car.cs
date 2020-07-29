using System.Windows.Media;
using System;

namespace BusinessLogic
{
    public class Car : Notifier
    {
        private double speed;
        public double Speed{
            get => Speed; 
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            } 
        }

        private Color color;

        public Color Color{get; set;}

        public Human Driver { get; set; }
    }

    public class Human
    {
        public string Name { get; set; }
        public bool HasDrivingLicense { get; set; }

      
    }
}
