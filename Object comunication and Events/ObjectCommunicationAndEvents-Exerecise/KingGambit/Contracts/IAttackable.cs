namespace KingGambit.Contracts
{
    public delegate void AttackEvenetHandler();

    public interface IAttackable
    {
        event AttackEvenetHandler OnAttack;

        void Attack();

        void RespondToAttack();
    }
}
