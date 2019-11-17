using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public void MoweToScene(int Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
