using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Házi.Models;

namespace Házi.Controllers
{
    public class ExerciseCaloriesController : Controller
    {
        List<Exercise> exercises = new List<Exercise>();

        public ExerciseCaloriesController()
        {
            exercises.Add(new Exercise("Running", 1000));
            exercises.Add(new Exercise("Yoga", 400));
            exercises.Add(new Exercise("Pilates", 472));
            exercises.Add(new Exercise("Hiking", 700));
            exercises.Add(new Exercise("Swimming", 1000));
            exercises.Add(new Exercise("Bicycle", 600));
        }

        // GET: ExerciseCalories/Input
        public ActionResult Input()
        {
            return View("Input");
        }

        // POST: ExerciseCalories/Input
        [HttpPost]
        public ActionResult Input(Inputs inputs)
        {
            if (inputs.Name=="")
            {
                TempData["myWarning"] = "MISSING DATA";
                return this.RedirectToAction(nameof(Input));
            }
            if (inputs.Weight<=0)
            {
                TempData["myWarning"] = "MISSING DATA";
                return this.RedirectToAction(nameof(Input));
            }
            if (inputs.ExerciseLength<=0)
            {
                TempData["myWarning"] = "MISSING DATA";
                return this.RedirectToAction(nameof(Input));
            }

            Outputs output = new Outputs();
            output.Name = inputs.Name;
            output.Weight = inputs.Weight;
            output.ExerciseLength = inputs.ExerciseLength;
            switch (inputs.Exercise)
            {
                case "futás":
                    output.BurntCalories = (((exercises.Find(t => t.Name == "Running").BurntCaloriesPerHour / 60) * output.ExerciseLength) / 100) * output.Weight;
                    break;
                case "jóga":
                    output.BurntCalories = (((exercises.Find(t => t.Name == "Yoga").BurntCaloriesPerHour / 60) * output.ExerciseLength) / 100) * output.Weight;
                    break;
                case "pilátesz":
                    output.BurntCalories = (((exercises.Find(t => t.Name == "Pilates").BurntCaloriesPerHour / 60) * output.ExerciseLength) / 100) *output.Weight;
                    break;
                case "túrázás":
                    output.BurntCalories = (((exercises.Find(t => t.Name == "Hiking").BurntCaloriesPerHour / 60) * output.ExerciseLength) / 100) *output.Weight;
                    break;
                case "úszás":
                    output.BurntCalories = (((exercises.Find(t => t.Name == "Swimming").BurntCaloriesPerHour / 60) * output.ExerciseLength) / 100) *output.Weight;
                    break;
                case "biciklizés":
                    output.BurntCalories = (((exercises.Find(t => t.Name == "Bicycle").BurntCaloriesPerHour / 60) * output.ExerciseLength) / 100) *output.Weight;
                    break;
            }
            return View("Outputs" , output);
        }
    }
}