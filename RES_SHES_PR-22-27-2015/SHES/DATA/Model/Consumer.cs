using Common.IModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES.Data.Model
{
    public class Consumer : IConsumer
    {
        [Key]
        public string ConsumerID { get; set; }
        public double Consumption { get; set; }
        public bool IsConsuming { get; set; }

        public Consumer() { }

        public Consumer(string id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("ID cannot be null!");
            }

            if (id == "")
            {
                throw new ArgumentException("ID cannot be empty!");
            }

            ConsumerID = id;
        }

        public Consumer(Consumer c)
        {
            if (c == null)
            {
                throw new ArgumentNullException("Consumer cannot be null!");
            }


            ConsumerID = c.ConsumerID;
            Consumption = c.Consumption;
            IsConsuming = c.IsConsuming;
        }
    }
}
