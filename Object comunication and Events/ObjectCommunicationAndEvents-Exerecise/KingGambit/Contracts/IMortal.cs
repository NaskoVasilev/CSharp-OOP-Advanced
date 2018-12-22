namespace KingGambit.Contracts
{
    public delegate void SubordinateDieEventHandler(IMortal subordinate);

    public interface IMortal : INameable
    {
        int HitPoints { get; }

        void ResponToAttack();

        event SubordinateDieEventHandler SubordinateDie;

        void Die();

        void TakeDamage();
    }
}
