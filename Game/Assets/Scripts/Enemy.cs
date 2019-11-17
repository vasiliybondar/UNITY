using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Unit

{
    Vector2 startPosition;
    [SerializeField] float range = 1.0f;
    [SerializeField] float speed = 1.0f;
    [SerializeField] private Animator animator;
    private bool faceLeft = true;
    private bool death = false;


    public CharState EnemyState
    {
        set { animator.SetInteger("State", (int)value); }
    }


    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        startPosition = transform.position;
        SetScale();
    }

 
    void Update()
    {
        if (!death)
        {
            animator.SetInteger("State", (int)CharState.Run);
            if (transform.position.x > startPosition.x + range && !faceLeft)
            {
                Flip();
                SetScale();
            }
            else if (transform.position.x < startPosition.x - range && faceLeft)
            {
                Flip();
                SetScale(0.3f);

            }
            transform.Translate(Vector2.right * (faceLeft ? speed * -1 : Mathf.Abs(speed)) * Time.deltaTime);
        }
    }


    public void SetScale(float x = -0.3f)
    {
        transform.localScale = new Vector3(x, 0.3f, 0f);
    }


    private void Flip()
    {
            SetScale();
            faceLeft = !faceLeft;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !death)
        {
            collision.gameObject.GetComponent<CharDamage>().RecieveDamage();  
        }
    }

    public bool EnemyDeath
    {
        get { return death; }
    }

    public void StartDeath()
    {
        animator.SetInteger("State", (int)CharState.Death);
        death = true;
        Invoke("Die", 0.7f);
    }


    public override void Die()
    {
        base.Die();
    }
}
