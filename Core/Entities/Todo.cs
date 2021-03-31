using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Todo: BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
