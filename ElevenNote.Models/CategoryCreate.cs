using ElevenNote.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElevenNote.Models
{
    public class CategoryCreate
    {
        [MaxLength(15, ErrorMessage = "There are too many characters in theis field. (Max 15)")]
        public string CategoryName { get; set; }

        public override string ToString() => CategoryName;
    }
}
