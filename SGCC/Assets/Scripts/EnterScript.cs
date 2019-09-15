using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterScript : MonoBehaviour
{
    // Start is called before the first frame update\

    public Transform player;
    public float speed;
    public Vector2 baseScale;
    public string scene;

    private bool isActive = false;
    private float state = 0;

    void Start()
    {
        if (scene.Length == 0)
        {
            Debug.LogWarning("Target scene is not set in "+transform.parent.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            state += speed;
        }
        else
        {
            state = 0;
        }

        float scaleNum = 1 - Mathf.Sin(state) / state;
        if (state == 0) scaleNum = 0;

        Vector3 textScale = this.transform.GetChild(0).transform.localScale;
        textScale.x = scaleNum * baseScale.x;
        textScale.y = scaleNum * baseScale.y;
        this.transform.GetChild(0).transform.localScale = textScale;

        if (Input.GetKeyDown("return") && isActive)
        {
            Debug.Log("Loading scene " + scene + "...");
            SceneManager.LoadScene(scene, LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform != player) return;
        isActive = true;      
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform != player) return;
        isActive = false;
    }


}
