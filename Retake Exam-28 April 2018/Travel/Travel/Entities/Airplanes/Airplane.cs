namespace Travel.Entities.Airplanes
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Entities.Contracts;
    using System.Linq;

    public abstract class Airplane : IAirplane
    {
        private readonly List<IBag> baggageCompartment;
        private readonly List<IPassenger> passengers;

        public Airplane(int seats, int baggageCompartments )
        {
            this.Seats = seats;
            this.BaggageCompartments = baggageCompartments;

            this.baggageCompartment = new List<IBag>();
            this.passengers = new List<IPassenger>();
        }

        public int BaggageCompartments { get; private set; }

        public IReadOnlyCollection<IBag> BaggageCompartment => this.baggageCompartment.AsReadOnly();

        public bool IsOverbooked => this.Passengers.Count > this.Seats;

        public IReadOnlyCollection<IPassenger> Passengers => passengers.AsReadOnly();

        public int Seats { get; private set; }

        public void AddPassenger(IPassenger passenger)
        {
            this.passengers.Add(passenger);
        }

        public IEnumerable<IBag> EjectPassengerBags(IPassenger passenger)
        {
            List<IBag> bags = baggageCompartment.Where(x => x.Owner == passenger).ToList();
            baggageCompartment.RemoveAll(x => x.Owner == passenger);

            return bags;
        }

        public void LoadBag(IBag bag)
        {
            if(this.BaggageCompartment.Count > BaggageCompartments)
            {
                throw new InvalidOperationException($"No more bag room in {this.GetType().Name}!");
            }

            this.baggageCompartment.Add(bag);
        }

        public IPassenger RemovePassenger(int seat)
        {
            IPassenger passenger = this.passengers[seat];
            this.passengers.RemoveAt(seat);
            return passenger;
        }
    }
}
