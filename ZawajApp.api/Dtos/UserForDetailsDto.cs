using System;
using System.Collections.Generic;
using ZawajApp.api.Models;

namespace ZawajApp.api.Dtos
{
    public class UserForDetailsDto
    {
         public int Id { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public String KnownAs { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public String Inroduction { get; set; }
        public string LookingFor { get; set; }
        public string Intersts { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhotoURL { get; set; }
        public ICollection<PhotoForDetailsDto> Photos { get; set; }
    }
}