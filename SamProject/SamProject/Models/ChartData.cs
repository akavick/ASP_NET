﻿using System;
using System.Collections.Generic;





namespace SamProject.Models
{





    public class ChartData<T>
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public IEnumerable<ChartPoint<T>> DataSource { get; set; }
    }





}