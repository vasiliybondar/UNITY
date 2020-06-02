using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextController : MonoBehaviour
{
    public Text text_Profile;
    public InputField InputField;

    void Start()
    {
        text_Profile.text = My_Text.my_Text;
    }

   public void LoadText()
    {
        My_Text.my_Text = InputField.text;
    }
}
