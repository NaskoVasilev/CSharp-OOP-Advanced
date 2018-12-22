namespace Heroes
{
    using System;
    using DelegatesAndEvents;
    using DelegatesAndEvents.Loggers;
    using DelegatesAndEvents.Commands;
    using DelegatesAndEvents.Groups;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            IHandler combatLogger = new CombatLogger();
            IHandler eventLogger = new CombatLogger();

            combatLogger.SetSuccessor(eventLogger);

            IAttackGroup attackGroup = new Group();

            IAttacker warrior = new Warrior("gosho", 10, combatLogger);
            IAttacker attacker = new Warrior("atanas", 100, combatLogger);
            attackGroup.AddMember(warrior);
            attackGroup.AddMember(attacker);

            ITarget dragon = new Dragon("Peter", 100, 25, combatLogger);

            IExecutor executor = new CommandExecutor();

            ICommand command = new TargetCommand(warrior, dragon);
            ICommand attack = new AttackCommand(warrior);
            ICommand groupTargetCommand = new GroupTargetCommand(attackGroup, dragon);
            ICommand groupAttackCommand = new GroupAttackCommand(attackGroup);
        }
    }
}
