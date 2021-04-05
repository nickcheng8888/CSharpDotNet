using System;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesPokemon.Models
{
    public class Pokemon
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }
        public string Weaknesses { get; set; }
    }
}