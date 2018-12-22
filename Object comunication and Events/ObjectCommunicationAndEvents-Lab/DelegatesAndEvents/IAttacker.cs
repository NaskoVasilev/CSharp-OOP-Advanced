namespace Heroes
{
    public interface IAttacker
    {
        void Attack();

        void SetTarget(ITarget target);
    }
}