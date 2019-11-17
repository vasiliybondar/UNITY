using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CharMovement : Unit
{
    [SerializeField] private float speed = 5.0F;
    [SerializeField] private float jumpForce = 8.0F;
    [SerializeField] LayerMask whatIsGround;


    [SerializeField] new private Rigidbody2D rigidbody;
    [SerializeField] private Animator animator;

    private bool faceLeft = false;
    [SerializeField] private bool isGrounded = false;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }


    private void Start()
    {
        SetScale();
    }

    private void Update()
    {
        if (!gameObject.GetComponent<CharDamage>().Death)
        {
            if (isGrounded)
            {
                animator.SetInteger("State", (int)CharState.Idle);
            }
            if (Input.GetButton("Horizontal")) Run();
            if (isGrounded && Input.GetButtonDown("Jump")) Jump();
            if (isGrounded && Input.GetButtonDown("Fire1")) gameObject.GetComponent<CharDamage>().Attack();
            CheckPosition();
        }
    }

    private void FixedUpdate()
    {
        Flip();
        CheckGround();
    }


    private void Run()
    {
        Vector3 direction = transform.right * Input.GetAxisRaw("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        if (isGrounded)
        {
            animator.SetInteger("State", (int)CharState.Run);
        }
    }


    private void Jump()
    {
        rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }


    private void CheckGround()
    { 
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.3f, whatIsGround);      
    }


    private void Flip()
    {
        if (Input.GetAxis("Horizontal") < 0)
        {
            SetScale(-0.3f);
            faceLeft = true;
        }

        if (Input.GetAxis("Horizontal") > 0)
        {
            SetScale();
            faceLeft = false;
        }
    }

    public void CheckPosition()
    {
        if (transform.position.y <= -50)
        {
            SceneManager.LoadScene(4);
        }
    }
}
