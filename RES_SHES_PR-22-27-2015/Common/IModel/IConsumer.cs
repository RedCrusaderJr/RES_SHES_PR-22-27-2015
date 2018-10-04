using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.IModel
{
    public interface IConsumer
    {
        string ConsumerID { get; set; }
        double Consumption { get; set; }
        bool IsConsuming { get; set; }   
    }
}