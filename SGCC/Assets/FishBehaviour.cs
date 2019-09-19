using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    private string state = "spawned";
    // spawned: spawning or spawned
    // ending : closing, not clickable

    private float timeState = 0;
    Vector2 targetPos;
    Vector2 vel;

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void OnMouseDown()
    {
        GameObject.Find("GameManager").GetComponent<FishGameManager>().addPoints(10);
        Destroy(this.gameObject);
    }

    void move()
    {
        if (targetPos.magnitude == 0 || ((Vector2)transform.position - targetPos).magnitude < 2)
        {
            targetPos = GameObject.Find("GameManager").GetComponent<FishGameManager>().randomPoint()*2;
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPos, 0.1f);
        transform.LookAt(targetPos);
    }
}