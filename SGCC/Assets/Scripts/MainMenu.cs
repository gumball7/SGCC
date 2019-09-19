using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour 
{
    public static int socialPoints = 0;
    public static int physicalPoints = 0;
    public static int emotionalPoints = 0;
    public void PlayGame()
    {
        SceneManager.LoadScene("Buildings", LoadSceneMode.Single);
    }
    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
