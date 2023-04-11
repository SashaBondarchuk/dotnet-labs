using System;


namespace LAB2.classes
{
    public class VehicleRegistration
    {
        public int Id { get; set; }
        public int OwnerID { get; set; }
        public string VinId { get; set; }
        public DateTime RegistrationDate { get; set; }
        public override string ToString()
        {
            return $"Зареєстрована {RegistrationDate} на власника {OwnerID}";
        }
    }
}
