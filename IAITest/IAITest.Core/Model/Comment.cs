﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IAITest.Core.Model
{
    public class Comment
    {

        public int Id { get; set; }
        public int AdId { get; set; }
        public string Text { get; set; }
        public DateTime? Created { get;set; }
    }
}
