using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace LB2
{
    enum State
    {
        Idle,
        Move,
        Attack,
        Die
    }
    class Character : Interacteble
    {
        // hero 
        private string name;
        private int live;
        private Animator animator;
        private Rigidbody rigidbody;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.GetKeyUp("Fire1"))
            {
                //animator == State.Attack
            }
        }

        protected override void Interact()
        {
            //Взаємодія
        }

        private void GetDamage()
        {
            if (live > 0)
                live--;
            else Die();
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
