using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LB2
{
    class Enemy : Interacteble
    {

        // enemy
        [SerializeField] string nameEnemy;
        [SerializeField] Animator animatorEnemy;
        [SerializeField] Rigidbody rigidbodyEnemy;
        [SerializeField] int liveEnemy;


        private void Awake()
        {
            animatorEnemy = GetComponent<Animator>();
            rigidbodyEnemy = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKeyUp("Fire1"))
            {
                //animator == State.Attack
            }
        }


        public void GetDamage()
        {
            if (live > 0)
                live--;
            else Die();
        }

        protected virtual void Die()
        {
            Destroy(gameObject);
        }


    }
}
