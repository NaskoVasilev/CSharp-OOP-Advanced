using DelegatesAndEvents.Groups;

namespace DelegatesAndEvents.Commands
{
    public class GroupAttackCommand : ICommand
    {
        private IAttackGroup attackGroup;

        public GroupAttackCommand(IAttackGroup attackGroup)
        {
            this.attackGroup = attackGroup;
        }

        public void Execute()
        {
            attackGroup.GroupAttack();
        }
    }
}
