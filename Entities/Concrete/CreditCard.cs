using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard:IEntity
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string CustomerNameAndSurname { get; set; }
        public string CardNumber { get; set; }
        public string DateMonth { get; set; }
        public string DateYear { get; set; }
        public string CVV { get; set; }


    }
}
