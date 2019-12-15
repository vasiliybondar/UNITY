using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class CheckLevel : MonoBehaviour
{
    [SerializeField] private int moweToLevel;
      
    private void OnCollisionEnter2D(Collision2D collision)
    {
        SceneManager.LoadScene(moweToLevel);
    }
}
