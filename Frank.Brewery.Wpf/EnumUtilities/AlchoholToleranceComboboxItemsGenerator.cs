using System;
using System.Collections.Generic;
using System.Text;
using Frank.Brewery.Enums;

namespace Frank.Brewery.Wpf.EnumUtilities
{
    public static class AlchoholToleranceComboboxItemsGenerator
    {
        private IEnumerable<Amount> operationsValues = Enum.GetValues(typeof(Operation));
        var operations = operationsValues.OfType<Operation>().Select(o => new ComboBoxItem()
        {
            Name = o.ToString(),
            Content = o,
            Tag = o
        });
    }
}
