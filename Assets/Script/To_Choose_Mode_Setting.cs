using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_Choose_Mode_Setting : MonoBehaviour
{
    public void ChooseMode()
    {
        SceneManager.LoadScene("Mode");
    }

    public void Choose_Setting()
    {
        SceneManager.LoadScene("Setting");
    }
}
