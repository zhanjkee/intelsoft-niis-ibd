using System;

namespace Intelsoft.Niis.Ibd.Entities.Base
{
    public class EntityBase
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte[] RowVersion { get; set; }
    }
}
