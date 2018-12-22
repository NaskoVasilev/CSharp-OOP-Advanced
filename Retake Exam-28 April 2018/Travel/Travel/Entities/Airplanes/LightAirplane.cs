namespace Travel.Entities.Airplanes
{
	public class LightAirplane : Airplane
	{
        private const int seats = 5;
        private const int baggageCompartments = 8;

		public LightAirplane()
			: base(seats,baggageCompartments)
		{
		}
	}
}