using System;
using System.Collections.Generic;
using System.Text;

namespace HS.Models
{
	public class Skipper
	{
        public string Name { get; set; }

        public decimal Price { get; set; }

        public byte Expirience { get; set; }

        public byte Rating { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Picture { get; set; }

        public override string ToString()
        {
            return "Name: " + this.Name + " Price: " + this.Price +
                " Expirience: " + this.Expirience + " Rating: " + this.Rating;
        }
    }
}
