﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Efcore.Domains
{
    public class Pedido : BaseDomain
    {
	   
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

                 
     }
}
