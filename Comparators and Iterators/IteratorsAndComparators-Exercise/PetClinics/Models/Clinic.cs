using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetClinics.Models
{
    public class Clinic : IEnumerable<Pet>
    {
        private int roomsCount;
        private Pet[] pets;
        private int middleIndex;

        public Clinic(string name, int roomsCount)
        {
            this.Name = name;
            this.RoomsCount = roomsCount;
            middleIndex = this.RoomsCount / 2;
            this.pets = new Pet[this.RoomsCount];
        }

        public bool HasEmptyRoom => this.pets.Any(x => x == null);

        public string Name { get; private set; }

        public int RoomsCount
        {
            get { return roomsCount; }
            set
            {
                if (value % 2 == 0)
                {
                    throw new ArgumentException("Invalid Operation!");
                }
                roomsCount = value;
            }
        }

        public bool AddPet(Pet pet)
        {
            if (pet == null)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            if(!this.HasEmptyRoom)
            {
                return false;
            }

            bool isRight = true;

            for (int i = 0; i <= middleIndex; i++)
            {
                int targetIndex = 0;

                if (isRight)
                {
                    targetIndex = middleIndex + i;
                }
                else
                {
                    targetIndex = middleIndex - i;
                    i--;
                }

                if (this.pets[targetIndex] == null)
                {
                    this.pets[targetIndex] = pet;
                    return true;
                }

                isRight = !isRight;
            }

            return false;
        }

        public bool RemovePet()
        {
            for (int i = middleIndex; i < this.pets.Length; i++)
            {
                if (this.pets[i] != null)
                {
                    this.pets[i] = null;
                    return true;
                }
            }

            for (int i = 0; i < middleIndex; i++)
            {
                if (this.pets[i] != null)
                {
                    this.pets[i] = null;
                    return true;
                }
            }

            return false;
        }

        public string GetPetInfo(int roomNumber)
        {
            roomNumber--;
            Pet pet = this.pets[roomNumber];
            if (pet == null)
            {
                return "Room empty";
            }
            return pet.ToString();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var pet in this)
            {
                if (pet == null)
                {
                    sb.AppendLine("Room empty");
                }
                else
                {
                    sb.AppendLine(pet.ToString());
                }
            }

            return sb.ToString();
        }

        public IEnumerator<Pet> GetEnumerator()
        {
            foreach (Pet pet in this.pets)
            {
                yield return pet;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
