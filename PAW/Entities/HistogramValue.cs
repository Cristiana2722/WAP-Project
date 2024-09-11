using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PAW.Entities
{
    public class HistogramValue
    {
        public string Label { get; set; }
        public float Value { get; set; }
        public HistogramValue(string label, float value)
        {
            Label = label;
            Value = value;
        }
    }
}
