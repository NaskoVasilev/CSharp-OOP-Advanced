﻿using System;
using System.Collections.Generic;
using System.Text;
using Heroes;

namespace DelegatesAndEvents.Groups
{
    public class Group : IAttackGroup
    {
        private List<IAttacker> attackers;

        public Group()
        {
            this.attackers = new List<IAttacker>();
        }

        public void AddMember(IAttacker attacker)
        {
            attackers.Add(attacker);
        }

        public void GroupAttack()
        {
            foreach (IAttacker attacker in attackers)
            {
                attacker.Attack();
            }
        }

        public void GroupTarget(ITarget target)
        {
            foreach (IAttacker attacker in attackers)
            {
                attacker.SetTarget(target);
            }
        }

        public void GroupTargetAndAttack(ITarget target)
        {
            this.GroupTarget(target);
            this.GroupAttack();
        }
    }
}
