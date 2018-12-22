using System;

public abstract class Provider : IProvider
{
    protected const double InitialDurability = 1000;

    private double durability;

    protected Provider(int id, double energyOutput)
    {
        ID = id;
        EnergyOutput = energyOutput;
        this.Durability = InitialDurability;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; protected set; }

    public double Durability
    {
        get
        {
            return this.durability;
        }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException(Constants.DurabilityLessThanZero);
            }

            this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -= Constants.DurabilityLoss;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return string.Format(Constants.EntityInfo,this.GetType().Name, this.Durability);
    }
}