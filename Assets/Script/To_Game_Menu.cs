using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class To_Game_Menu : MonoBehaviour
{
    public void QuickPlay()
    {
        SceneManager.LoadScene("Game");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
