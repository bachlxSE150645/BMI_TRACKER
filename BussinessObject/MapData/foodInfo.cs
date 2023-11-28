using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject.MapData
{
    public class foodInfo
    {
        public string foodName { get; set; }
        public string foodTag { get; set; }
        public string foodNutrition { get; set; }
        public string foodNotes { get; set; }
        public string foodDesciption { get; set; }
        public string foodPhoto { get; set; }
        public int foodtimeProcess { get; set; }
        public int foodCalorios { get; set; }
        public string foodProcessingVideo { get; set; }
        public Guid categoryId { get; set; }
        public  FoodIngredientDTO[] ingredients{get;set;}
    }
    public class FoodIngredientDTO
    {
        public Guid ingredientId { get; set; }
    }
}
