using System;
using System.Collections.Generic;
using System.Text;
using Frank.Brewery.Entities;

namespace Frank.Brewery.DataTransferObjects
{
    public class StepDto
    {
        public int Id { get; set; }
        public int Time { get; set; }
        public HopDto Hop { get; set; }
        public int Amount { get; set; }
    }
}
