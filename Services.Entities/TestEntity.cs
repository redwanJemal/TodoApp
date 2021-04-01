using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Entities
{
    public class TestEntity: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Status { get; set; }
    }
}
