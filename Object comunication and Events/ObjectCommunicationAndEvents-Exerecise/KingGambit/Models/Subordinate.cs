using KingGambit.Contracts;

namespace KingGambit.Models
{
    public abstract class Subordinate : IMortal, INameable
    {
        public Subordinate(string name, int hitPoints)
        {
            Name = name;
            this.HitPoints = hitPoints;
        }

        public string Name { get; }

        public int HitPoints { get; private set; }

        public event SubordinateDieEventHandler SubordinateDie;

        public void Die()
        {
            SubordinateDie?.Invoke(this);
        }

        public abstract void ResponToAttack();

        public void TakeDamage()
        {
            this.HitPoints--;
            if (this.HitPoints <= 0)
            {
                this.Die();
            }
        }
    }
}
