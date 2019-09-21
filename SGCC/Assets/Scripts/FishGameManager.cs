using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class FishGameManager : MonoBehaviour
{
    public CircleCollider2D spawnBoundary;
    public GameObject fish;
    public GameObject fishParent;
    public GameObject pointPrefab;
    public GameObject pointParent;
    public GameObject bob;
    public GameObject countDown;
    public GameObject startText;
    public GameObject timer;

    private string gameState = "starting";
    // starting: entered but not started
    // started : started game, running.
    // ended   : ended game, closing out soon.

    private int points;
    private float timeState = 0;
    private float timeToNext = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == "starting")
        {
            if (timeState > countDown.GetComponent<CountdownBehaviour>().startDelay)
            {
                gameState = "started";
                startText.transform.localScale = new Vector3(1,1,0);
                timeState = 30;
            }
            else timeState += Time.deltaTime;
            return;
        }

        if (gameState == "ended") end();

        if (timeState < 0)
        {
            gameState = "ended";
            return;
        }

        if (timeToNext < 0)
        {
            spawnFish(randomPoint());
            timeToNext = Random.Range(0.2f, 0.5f);
        }

        Vector3 bobPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bobPos.z = 0;
        bob.transform.position = bobPos;

        timer.GetComponent<Slider>().value = (30-timeState)/30;
        timeToNext -= Time.deltaTime;
        timeState -= Time.deltaTime;
    }

    void end()
    {
        SceneManager.LoadScene("Park", LoadSceneMode.Single);
    }

    public Vector2 randomPoint()
    {
        return spawnBoundary.transform.position + (Random.insideUnitSphere * spawnBoundary.radius);
    }

    void spawnFish(Vector2 pos)
    {
        GameObject fishObj = Instantiate(fish, pos, Quaternion.identity);
        fishObj.transform.parent = fishParent.transform;
    }

    public void addPoints(int num)
    {
        points += num;
        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        pos.z = 0;
        Instantiate(pointPrefab, pos, Quaternion.identity);
    }
}
