using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Tombool : MonoBehaviour
{
    public InputField inputField;

    public void GoToLevel()
    {
        SceneManager.LoadScene(int.Parse(inputField.text));
    }
}
