using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebGoD.Models
{
    public class CharacterDto
    {
        public int Id { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }

        public CharacterDto(int id,String firstName,String lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

    }
}