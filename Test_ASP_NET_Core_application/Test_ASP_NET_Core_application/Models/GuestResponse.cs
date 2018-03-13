using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test_ASP_NET_Core_application.Models
{
    public class GuestResponse
    {
        [Required(ErrorMessage = "Имя где?")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Мыло где?")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Правильное мыло где?")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Телефон где?")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Решение где?")]
        public bool? WillAttend { get; set; }
    }
}
