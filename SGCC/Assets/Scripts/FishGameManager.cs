using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishGameManager : MonoBehaviour
{
    public CircleCollider2D spawnBoundary;
    public GameObject fish;

    private string gameState = "starting";
    // starting: entered but not started
    // started : started game, running.
    // ended   : ended game, closing out soon.

    private int points;
    private float timeState = 30;
    private float timeToNext = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameState == "starting") gameState = "started";

        if (gameState == "ended") ;

        if (timeState < 0)
        {
            gameState = "ended";
            return;
        }

        if (timeToNext < 0)
        {
            spawnFish(randomPoint());
            timeToNext = Random.Range(0.5f, 1);
        }

        timeToNext -= Time.deltaTime;
        timeState -= Time.deltaTime;
    }

    public Vector2 randomPoint()
    {
        return spawnBoundary.transform.position + (Random.insideUnitSphere * spawnBoundary.radius);
    }

    void spawnFish(Vector2 pos)
    {
        Instantiate(fish, pos, Quaternion.identity);
    }

    public void addPoints(int num)
    {
        points += num;
    }
}
