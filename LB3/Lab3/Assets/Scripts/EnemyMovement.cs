using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyMovement : Unit
{
    private GameObject target;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");
    }


    protected override void Move()
    {
        fence = 0;
       
        rb.AddForce(target.GetComponent<Transform>().gameObject.transform.position.x - transform.position.x,
              target.GetComponent<Transform>().gameObject.transform.position.y - transform.position.y,
             target.GetComponent<Transform>().gameObject.transform.position.z - transform.position.z,
             ForceMode.Impulse);
    }


    public override void StartEndMove()
    {
        StartCoroutine(CoroutineEndMove());
    }


    protected override void EndMove()
    {
        if (!target.GetComponent<Movement>().IsPlayerMove)
        {
            fence = 0;
            rb.velocity = Vector3.zero;
            target.GetComponent<Rigidbody>().velocity = Vector3.zero;
            target.GetComponent<Movement>().IsPlayerMove = true;
            target.GetComponent<Movement>().CanPlayerMove = true;
            target.GetComponent<Movement>().JoystickUI.SetActive(true);
        }
    }


    IEnumerator CoroutineEndMove()
    {
        yield return new WaitForSeconds(3);
        EndMove();
    }

    private void OnCollisionExit(Collision collision)
    {     
        if (collision.gameObject.tag == "Fence")
        {
            fence++;
        }

        if (fence >= 2 && !target.GetComponent<Movement>().IsPlayerMove)
        {
            StartEndMove();
        }
    }
}