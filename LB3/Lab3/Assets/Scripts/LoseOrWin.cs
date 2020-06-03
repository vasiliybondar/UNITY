using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseOrWin : MonoBehaviour
{
    public static string loseOrWin = "Check you skill";
    private Text text;

    private void Start()
    {
        text = GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        text.text = loseOrWin;
    }
}
