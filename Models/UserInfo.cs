using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace MeetingApp.Models
{
    public class UserInfo
    {
        
        public int Id { get; set; }
            [Required(ErrorMessage ="Ad Alanını Doldurunuz")]
        public string? Name { get; set; }
            [Required(ErrorMessage ="Telefon Alanını Doldurunuz")]        
        public string? Phone { get; set; }
            [Required(ErrorMessage ="Email Alanını Doldurunuz")]
            [EmailAddress]
        public string? Email { get; set; }
            [Required(ErrorMessage ="Katılım Durumu Alanını Doldurunuz")]
        public bool?  WillAttend { get; set; }
            
       public string? Image { get; set; }
    }
}