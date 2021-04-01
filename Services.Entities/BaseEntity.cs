using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Entities
{
    public class BaseEntity: IBaseEntity
    {
        public int Id { get; set; }
    }

    public interface IBaseEntity
    {
        public int Id { get; set; }
    }
}
