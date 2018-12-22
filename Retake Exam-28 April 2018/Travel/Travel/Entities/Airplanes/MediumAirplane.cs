namespace Travel.Entities.Airplanes
{
    public class MediumAirplane : Airplane
    {
        private const int seats = 10;
        private const int baggageCompartments = 14;

        public MediumAirplane()
            : base(seats, baggageCompartments)
        {
        }
    }
}