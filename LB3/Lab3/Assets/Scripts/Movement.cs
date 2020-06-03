using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class Movement : Unit
{
    protected Joystick joystick;
    private GameObject joystickUI;
    private GameObject enemy;
    private bool isPlayerMove;
    private bool canPlayerMove;
    

    public bool IsPlayerMove
    {
        get { return isPlayerMove; }
        set { isPlayerMove = value; }
    }

    public GameObject JoystickUI
    {
        get { return joystickUI; }
        set { joystickUI = value; }
    }

    public bool CanPlayerMove
    {
        get { return canPlayerMove; }
        set { canPlayerMove = value; }
    }

    private void Start()
    { 
        rb = GetComponent<Rigidbody>();
        joystick = FindObjectOfType<Joystick>();
        joystickUI = GameObject.Find("Fixed Joystick") as GameObject;
        enemy = GameObject.FindGameObjectWithTag("Enemy");

        CanPlayerMove = true;
        IsPlayerMove = true;
    }


    private void FixedUpdate()
    {
        if (IsPlayerMove && canPlayerMove)
        {
            if (Input.GetMouseButtonUp(0))
            {
                fence = 0;
                GetComponent<AttackController>().IsPlayerAttack = true;
                Move();
            }
        }

        else if (!IsPlayerMove && rb.velocity == Vector3.zero)
        { 
            enemy.GetComponent<EnemyMovement>().Invoke("Move", 0f);
        }
    }

    protected override void Move()
    {
        rb.AddForce(joystick.Horizontal * acceleration, rb.velocity.y, joystick.Vertical * acceleration, ForceMode.Impulse);
        _ = rb.velocity != Vector3.zero ? CanPlayerMove = false : CanPlayerMove = true;
    }


    protected override void EndMove()
    {
        if (isPlayerMove && GetComponent<AttackController>().IsPlayerAttack == true)
        {
            fence = 0;

            rb.velocity = Vector3.zero;
            enemy.GetComponent<Rigidbody>().velocity = Vector3.zero;
            
            joystickUI.SetActive(false);
            IsPlayerMove = false;
            GetComponent<AttackController>().IsPlayerAttack = false;
        }
    }


    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Fence" )
        {
            fence++;
        }

        if (fence >= 2 && IsPlayerMove)
        {
            StartEndMove();
        }
    }
}