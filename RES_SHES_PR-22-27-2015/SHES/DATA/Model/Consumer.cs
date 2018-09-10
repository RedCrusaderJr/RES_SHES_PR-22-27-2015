using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Data.Model
{
    public class Consumer
    {
        [Key]
        public string ConsumerID { get; set; }
        public double Consumption { get; set; }
        public bool IsConsuming { get; set; }

        public Consumer() { }

        public Consumer(string id)
        {
            ConsumerID = id;
        }

        public Consumer(Consumer c)
        {
            ConsumerID = c.ConsumerID;
            Consumption = c.Consumption;
            IsConsuming = c.IsConsuming;
        }
    }
}
