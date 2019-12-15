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

    abstract class Interacteble : MonoBehaviour
    {
        // hero 
        [SerializeField] protected string name;
        [SerializeField] protected int live;
        [SerializeField] protected Animator animator;
        [SerializeField] protected Rigidbody rigidbody;

        private void Awake()
        {
            animator = GetComponent<Animator>();
            rigidbody = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if(Input.GetKeyUp("Fire1"))
            {
                //animator == State.Attack
            }
        }

        protected virtual void GetDamage()
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
