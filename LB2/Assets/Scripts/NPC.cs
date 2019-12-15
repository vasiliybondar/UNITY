using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LB2
{
    class NPC : Interacteble
    {
        private bool charAttack;
        private bool enemyAttack;

        private void Awake()
        {
            charAttack = true;
            enemyAttack = false;
        }

        private void Update()
        {
            // check animation
            // if (animation == State.Attck && animatorEnemy == stateAttack)
            // Attack()
        }

        protected override void Interact()
        {
            //Взаємодія
        }

        private void Attack()
        {
            // check attack radius
            // {
            //  if( charAttack == true)
            //      GetDamage() - enemy
            //  else
            //      base.GetDamage()
            // }
            ChangeAttack();
        }

        private void ChangeAttack()
        {
            charAttack = !charAttack;
            enemyAttack = !enemyAttack;
        }
    }
}
