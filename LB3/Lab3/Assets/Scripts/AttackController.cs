using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class AttackController : Attack
{
    private bool isPlayerAttack;

    public bool IsPlayerAttack
    {
        get { return isPlayerAttack; }
        set { isPlayerAttack = value; }
    }

    private void FixedUpdate()
    {
        isplayerMove = player.GetComponent<Movement>().IsPlayerMove;
        UIHP.fillAmount = HP / 100;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Player")
        {
            BringDamage();
        }
    }

    protected override void BringDamage()
    {
        if (isplayerMove)
        {
            if (enemy.GetComponent<Attack>().HP > 0 && IsPlayerAttack && player.GetComponent<Attack>().CanAttack)
            {
                enemy.GetComponent<Attack>().HP -= player.GetComponent<Attack>().Damage;
                if (CheckHP(enemy))
                {
                    player.GetComponent<Movement>().StartEndMove();
                }
            }
        }

        if (!isplayerMove)
        {
            if (player.GetComponent<Attack>().HP > 0 && enemy.GetComponent<Attack>().CanAttack)
            {
                player.GetComponent<Attack>().HP -= enemy.GetComponent<Attack>().Damage;
                if (CheckHP(player))
                {
                    enemy.GetComponent<EnemyMovement>().StartEndMove();
                }
            }
        }
    }
}
