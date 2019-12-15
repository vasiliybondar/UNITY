using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesBar : MonoBehaviour
{
    [SerializeField] private Transform[] hearts = new Transform[5];

    private CharDamage charDamage;

    private void Awake()
    {
        charDamage = FindObjectOfType<CharDamage>();

        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i] = transform.GetChild(i);
            Debug.Log(hearts[i]);
        }
    }

    public void Refresh()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i <= charDamage.Lives)
                hearts[i].gameObject.SetActive(true);
            else
                hearts[i].gameObject.SetActive(false);
        }
    }

}
