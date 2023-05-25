using System;
using System.Collections.Generic;

namespace CarStorage.DAL.DataModel
{
    public partial class Vehicle
    {
        public int Id { get; set; }
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public int BodyTypeId { get; set; }
        public string RegistrationNumber { get; set; } = null!;
        public string VIN { get; set; } = null!;
        public int ProductionYear { get; set; }
        public int Mileage { get; set; }
        public byte[] Image { get; set; } = null!;
    }
}
