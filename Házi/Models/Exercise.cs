using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Házi.Models
{
    public class Exercise
    {
        public string Name { get;}
        public double BurntCaloriesPerHour { get;}

        public Exercise(string name, double bcph)
        {
            this.Name = name;
            this.BurntCaloriesPerHour = bcph;
        }
    }
}