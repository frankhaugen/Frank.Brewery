using System;
using System.Collections.Generic;
using System.Text;

namespace Frank.Brewery.DataTransferObjects
{
    public class FermentableDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Uri Link { get; set; }
        public double Price { get; set; }
        public int Amount { get; set; }
        public double Lovibond { get; set; }
        public int Ppg { get; set; }
    }
}
