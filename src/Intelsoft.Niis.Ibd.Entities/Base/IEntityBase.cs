using System;

namespace Intelsoft.Niis.Ibd.Entities.Base
{
    public interface IEntityBase<TKey> where TKey : IEquatable<TKey>
    {
        TKey Id { get; set; }
    }

    public abstract class EntityBase : IEntityBase<int>
    {
        protected EntityBase()
        {
            RowCreatedDate = DateTime.Now;
        }

        public DateTime RowCreatedDate { get; set; }
        public byte[] RowVersion { get; set; }

        public int Id { get; set; }
    }
}