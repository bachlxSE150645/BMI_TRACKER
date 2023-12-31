﻿using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class food
    {
       
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
       public Guid foodId { get; set; }
        public string foodName { get; set;}
        public string foodTag {  get; set; }
        public string foodNutrition { get; set; }
        public string foodNotes { get; set; }
        public string foodDesciption { get; set; }
        public string foodPhoto {  get; set; } 
        public int foodtimeProcess { get; set; }
        public int foodCalorios { get; set; }
        public string foodProcessingVideo { get; set; }
        public string status { get; set; }
        [ForeignKey("category")]
        public Guid categoryId { get; set; }
        public Category categorys { get; set; }
        public ICollection<recipe> recipes { get; set; }
        public ICollection<Meal> meals { get; set; }
        [JsonIgnore]
        public ICollection<favoriteFood> favoriteFoods { get; set; }
        

    }
}
