using System;
using System.Collections.Generic;

namespace CarStorage.DAL.DataModel
{
    public partial class BodyType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Desription { get; set; } = null!;
    }
}
