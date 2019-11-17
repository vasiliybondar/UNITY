using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharDamage : Unit
{
    [SerializeField] new private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    private bool faceLeft = false;
    [SerializeField] private bool isGrounded = false;

    private bool attack = false;
    private bool death = false;


    public int Lives
    {
        get { return base.lives; }
        set
        {
            if (value < 5)
                base.lives = value;
            livesBar.Refresh();
        }
    }


    private LivesBar livesBar;

    public bool Death
    {
        get { return death; }
    }

    private void Awake()
    {
        livesBar = FindObjectOfType<LivesBar>();
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }


    public void Attack()
    {
        animator.SetInteger("State", (int)CharState.Attack);
        attack = true;
        Invoke("ResetAttack", 1f);
    }

    private void ResetAttack()
    {
        attack = false;
    }


    private void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            base.SetScale(-0.3f);
            faceLeft = true;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            base.SetScale();
            faceLeft = false;
        }
    }

    public override void RecieveDamage()
    {
        if (Lives > 0)
        {
            Lives--;
            Debug.Log("Lives: " + Lives);
        }
        else
        {
            animator.SetInteger("State", (int)CharState.Death);
            death = true;
            Invoke("Die", 0.7f);
        }
    }

    public override void Die()
    {
        SceneManager.LoadScene(4);
        base.Die();
    }


    public void EatPizza()
    {
        Lives++;
    }

    public bool CheckAttack()
    {
        return attack;
    }
}


public enum CharState
{
    Idle,
    Run,
    Attack,
    Death
}