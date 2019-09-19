using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreMenu : MonoBehaviour
{
    public void GoScoreMenu()
    {
        SceneManager.LoadScene("ScoreMenu", LoadSceneMode.Single);
    }
    public void Continue()
    {
        SceneManager.LoadScene("Buildings", LoadSceneMode.Single);
    }
}
