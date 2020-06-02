using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : Attack
{
    private void FixedUpdate()
    {
        isplayerMove = player.GetComponent<Movement>().IsPlayerMove;
        UIHP.fillAmount = HP / 100;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            BringDamage();
        }
    }

    protected override void BringDamage()
    {
        if (!isplayerMove)
        {
            if (player.GetComponent<PlayerAttack>().HP > 0)
            {
                player.GetComponent<PlayerAttack>().HP -= Damage;
                if (CheckHP(player))
                {
                    enemy.GetComponent<EnemyMovement>().StartEndMove();
                }
            }
        }
    }
}
