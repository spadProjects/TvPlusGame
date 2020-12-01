using System;
using System.Collections.Generic;
using System.Text;

namespace TvPlusGame.Model.Entity
{
    public interface IBaseEntity
    {
        int Id { get; set; }
        bool IsDeleted { get; set; }
    }
    public abstract class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }

    }
}
