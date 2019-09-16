using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScoreMenu : MonoBehaviour
{
    public void GoScoreMenu()
    {
        SceneManager.LoadScene("ScoreMenu");
    }
    public void Continue()
    {
        SceneManager.UnloadSceneAsync("ScoreMenu");
    }
}
