using System;

namespace LAB1.classes
{
    class ChauffeurRegistration
    {
        public int Id { get; set; }
        public int VechileRegistrationID { get; set; }
        public int ChauffeurID { get; set; }
        public DateTime Date { get; set; }
        public override string ToString()
        {
            return $"Шофер #{ChauffeurID} закріплений за машиною з # реєстрації: {VechileRegistrationID}";
        }
    }
}
