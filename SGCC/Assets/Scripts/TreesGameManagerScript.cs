using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TreesGameManagerScript : MonoBehaviour
{

    public string gameState = "starting";
    // starting: entered but not started
    // started : started game, running.
    // ended   : ended game, closing out soon.
    public GameObject fallingObjectPrefab;
    public float timeTotal = 60;
    public Slider timeSlider;
    public Text pointText;
    public RawImage countdownImage;

    private float timeState = 0;
    private float timeToNext = 0;
    private int points = 0;
    private float startDelay = 0;
    private float vert = 0;
    private float horz = 0; 


    // Start is called before the first frame update
    void Start()
    {
        gameState = "starting";
        timeToNext = 0;
        timeState = 0;
        points = 0;
        addPoint(0);
        startDelay = countdownImage.GetComponent<CountdownBehaviour>().startDelay;
        vert = Camera.main.orthographicSize * 2.0f;
        horz = vert * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == "starting")
        {
            timeState += Time.deltaTime;
            if (timeState > startDelay)
            {
                gameState = "started";
                timeState = 0;
            }
            return;
        }


        if (gameState == "ended")
        {
            end();
            return;
        }

        if (timeState > timeTotal)
        {
            gameState = "ended";
            return;
        }

        if (timeToNext < 0) {
            spawnNew();
            timeToNext = Random.Range(1, 2);
        }

        timeSlider.value = timeState / timeTotal;
        timeState += Time.deltaTime;
        timeToNext -= Time.deltaTime;

    }

    void spawnNew()
    {
        Vector3 spawnPos = new Vector3();
        spawnPos.x = Random.Range(BoundsMin(Camera.main).x, BoundsMax(Camera.main).x);
        spawnPos.y = BoundsMax(Camera.main).y+2;

        GameObject fallingObject = Instantiate(fallingObjectPrefab, spawnPos, Quaternion.identity);
        fallingObject.GetComponent<Rigidbody2D>().gravityScale = Random.Range(0.5f, 1.5f);
        fallingObject.transform.parent = GameObject.Find("FallingObjectParent").transform;

    }

    public void addPoint(int point)
    {
        points += point;
        pointText.text = "Points: " + points;
    }

    void end()
    {
        foreach (Rigidbody2D falling in GameObject.Find("FallingObjectParent").GetComponentsInChildren<Rigidbody2D>()){
            falling.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        MainMenu.physicalPoints += points;


        SceneManager.LoadScene("Park", LoadSceneMode.Single);
    }

    Vector2 BoundsMin (Camera camera)
    {
        return camera.transform.position - Extents(camera);
    }

    Vector2 BoundsMax(Camera camera)
    {
        return camera.transform.position + Extents(camera);
    }

    Vector3 Extents(Camera camera)
    {
        if (camera.orthographic)
            return new Vector3(camera.orthographicSize * Screen.width / Screen.height, camera.orthographicSize);
        else
        {
            Debug.LogError("Camera is not orthographic!", camera);
            return new Vector3();
        }
    }
}
