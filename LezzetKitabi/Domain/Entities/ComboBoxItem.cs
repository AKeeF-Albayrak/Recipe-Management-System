using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LezzetKitabi.Domain.Entities
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public Guid Value { get; set; }
        public string Unit { get; set; }
    }
}
