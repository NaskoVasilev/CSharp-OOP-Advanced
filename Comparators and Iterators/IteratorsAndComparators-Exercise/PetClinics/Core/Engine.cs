using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinics.Core
{
    public class Engine
    {
        private ClinicController clinicController;

        public Engine(ClinicController clinicController)
        {
            this.clinicController = clinicController;
        }

        public void Run()
        {
            StringBuilder sb = new StringBuilder();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] data = Console.ReadLine().Split();
                string commandType = data[0];
                string petName = "";
                string clinicName = "";
                string result = "";

                try
                {
                    switch (commandType)
                    {
                        case "Create":
                            string type = data[1];
                            if (type == "Clinic")
                            {
                                clinicName = data[2];
                                int roomsCount = int.Parse(data[3]);
                                clinicController.CreateClinic(clinicName, roomsCount);
                            }
                            else
                            {
                                petName = data[2];
                                int age = int.Parse(data[3]);
                                string kind = data[4];
                                clinicController.CreatePet(petName, age, kind);
                            }
                            break;
                        case "Add":
                            petName = data[1];
                            clinicName = data[2];
                            result = clinicController.AddPet(petName, clinicName).ToString();
                            break;
                        case "Release":
                            clinicName = data[1];
                            result = clinicController.ReleasePet(clinicName).ToString();
                            break;
                        case "HasEmptyRooms":
                            clinicName = data[1];
                            result = clinicController.HasEmptyRooms(clinicName).ToString();
                            break;
                        case "Print":
                            clinicName = data[1];
                            if (data.Length > 2)
                            {
                                int roomNumber = int.Parse(data[2]);
                                result = clinicController.PrintPet(clinicName, roomNumber);
                            }
                            else
                            {
                                result = clinicController.PrintClinic(clinicName);
                            }
                            break;
                        default:
                            throw new ArgumentException("Invalid command");
                    }
                }
                catch (ArgumentException ex)
                {
                    result = ex.Message;
                }

                if (string.IsNullOrEmpty(result) == false)
                {
                    sb.AppendLine(result);
                }
            }

            Console.WriteLine(sb.ToString());
        }
    }
}
