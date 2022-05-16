using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab4.Models
{
    public class FriendModel
    {
        [Required]
        [Range(0, 200)]
        [Display(Name = "Friend ID")]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Friend Name")]
        public string Ime { get; set; }
        [Required]
        [Display(Name = "Place")]
        public string MestoZiveenje { get; set; }
    }
}