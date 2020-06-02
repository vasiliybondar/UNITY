using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerAttack : Attack
{

    private bool isPlayerAttack;

    public bool IsPlayerAttack
    {
        get { return isPlayerAttack;  }
        set { isPlayerAttack = value; }
    }

    private void FixedUpdate()
    {
        isplayerMove = player.GetComponent<Movement>().IsPlayerMove;
        UIHP.fillAmount = HP / 100 ;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            BringDamage();
        }
    }

    protected override void BringDamage()
    {
        if (isplayerMove)
        {
            if (enemy.GetComponent<EnemyAttack>().HP > 0 && IsPlayerAttack)
            {
                enemy.GetComponent<EnemyAttack>().HP -= Damage;
                if (CheckHP(enemy))
                {
                    player.GetComponent<Movement>().StartEndMove();
                }
            }
        }
    }
}
