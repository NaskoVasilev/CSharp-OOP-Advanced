﻿namespace FestivalManager.Entities.Instruments
{
	using Contracts;

    using System;

    public abstract class Instrument : IInstrument
	{
		private double wear;
		private const int MaxWear = 100;

		protected Instrument()
		{
			this.Wear = MaxWear;
		}

		public double Wear
		{
			get
			{
				return this.wear;
			}
			private set
			{
				this.wear = Math.Min(Math.Max(value, 0), MaxWear);
			}
		}

		protected abstract int RepairAmount { get; }

		public void Repair() => this.Wear += this.RepairAmount;

		public void WearDown() => this.Wear -= this.RepairAmount;

		public bool IsBroken => this.Wear <= 0;

		public override string ToString()
		{
			string instrumentStatus = this.IsBroken ? "broken" : $"{this.Wear}%";

			return $"{this.GetType().Name} [{instrumentStatus}]";
		}
	}
}
