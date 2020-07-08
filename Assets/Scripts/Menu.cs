using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void OnButton01Clicked()
    {
        SceneManager.LoadScene("Level01");
    }

    public void OnButton02Clicked()
    {
        SceneManager.LoadScene("Level02");
    }

    public void OnButton03Clicked()
    {
        SceneManager.LoadScene("Level03");
    }
}
