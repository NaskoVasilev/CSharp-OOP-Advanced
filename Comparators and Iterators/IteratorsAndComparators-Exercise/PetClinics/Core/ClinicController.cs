using PetClinics.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetClinics.Core
{
    public class ClinicController
    {
        private Dictionary<string, Pet> pets;
        private Dictionary<string, Clinic> clinics;

        public ClinicController()
        {
            this.pets = new Dictionary<string, Pet>();
            this.clinics = new Dictionary<string, Clinic>();
        }

        public void CreateClinic(string name, int roomsCount)
        {
            Clinic clinic = new Clinic(name, roomsCount);
            clinics.Add(clinic.Name, clinic);
        }

        public void CreatePet(string name, int age, string kind)
        {
            Pet pet = new Pet(name, age, kind);
            this.pets.Add(pet.Name, pet);
        }

        public bool AddPet(string petName, string clinicName)
        {
            Pet pet = this.GetPet(petName);
            Clinic clinic = GetClinic(clinicName);
            bool result = clinic.AddPet(pet);
            return result;
        }

        public bool HasEmptyRooms(string clinicName)
        {
            Clinic clinic = this.GetClinic(clinicName);
            return clinic.HasEmptyRoom;
        }

        public bool ReleasePet(string clinicName)
        {
            Clinic clinic = GetClinic(clinicName);
            bool result = clinic.RemovePet();
            return result;
        }

        public string PrintPet(string clinicRoom,int roomNumber)
        {
            Clinic clinic = GetClinic(clinicRoom);
            return clinic.GetPetInfo(roomNumber);
        }

        public string PrintClinic(string clinicName)
        {
            Clinic clinic = GetClinic(clinicName);
            return clinic.ToString();
        }

        private Pet GetPet(string petName)
        {
            if (pets.ContainsKey(petName))
            {
                return this.pets[petName];
            }

            return null;
        }

        private Clinic GetClinic(string clinicName)
        {
            if (clinics.ContainsKey(clinicName))
            {
                return clinics[clinicName];
            }

            throw new ArgumentException("There is no clinic with this name!");
        }
    }
}
