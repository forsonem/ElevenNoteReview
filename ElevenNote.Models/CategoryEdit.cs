using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryEdit
    {
        [Display(Name = "Category ID")]
        public int CategoryID { get; set; }
       
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }




    }
}
