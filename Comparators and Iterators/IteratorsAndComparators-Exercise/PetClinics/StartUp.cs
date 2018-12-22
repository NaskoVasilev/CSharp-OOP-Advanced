using PetClinics.Core;
using System;

namespace PetClinics
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            ClinicController clinicController = new ClinicController();
            Engine engine = new Engine(clinicController);
            engine.Run();
        }
    }
}
