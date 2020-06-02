using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public abstract class Attack : MonoBehaviour
{
    protected GameObject player;
    protected GameObject enemy;

    [SerializeField] private float hp;
    [SerializeField] private int damage;

    [SerializeField] protected Image UIHP;

    protected bool isplayerMove;

    public float HP
    {
        get { return hp; }
        set { hp = value; }
    }

    public int Damage
    {
        get { return damage; }
    }


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    protected virtual void BringDamage() {}

    protected virtual bool CheckHP(GameObject gameObject)
    {
        if (gameObject.GetComponent<Attack>().HP <= 0)
        {
            Die(gameObject);
            return false;
        }
        else
            return true;
    }

    protected virtual void Die(GameObject gameObject)
    {
        SceneManager.LoadScene(3);
        if(gameObject.tag == "Player")
        {
            LoseOrWin.loseOrWin = "You lose(";
        }
        else if(gameObject.tag == "Enemy")
        {
            LoseOrWin.loseOrWin = "You win!!";
        }

        Destroy(gameObject);
    }
}
