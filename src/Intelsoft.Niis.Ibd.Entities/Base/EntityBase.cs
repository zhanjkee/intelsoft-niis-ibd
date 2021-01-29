using System;

namespace Intelsoft.Niis.Ibd.Entities.Base
{
    public class EntityBase
    {
        public EntityBase()
        {
            RowCreatedDate = DateTime.Now;
        }

        public int Id { get; set; }
        public DateTime RowCreatedDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
