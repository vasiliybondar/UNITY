using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    protected int lives = 4;

    public void SetScale(float x = 0.3f)
    {
        transform.localScale = new Vector3(x, 0.3f, 0f);
    }

    public virtual void RecieveDamage()
    {
        lives--;   
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
