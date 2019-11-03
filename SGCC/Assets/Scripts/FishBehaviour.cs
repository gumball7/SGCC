using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    private string state = "spawned";
    // spawned: spawning or spawned
    // ending : closing, not clickable
    public float speedOpacity = 0.04f;

    private float timeState = 0;
    private float opacityState = 0;
    Vector2 targetPos;
    Vector2 vel;

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (state == "spawned" && opacityState < 1) opacityState += speedOpacity;
        if (opacityState > 1) opacityState = 1;

        if (state == "ending" && opacityState > 0) opacityState -= speedOpacity;
        if (opacityState < 0) opacityState = 0;

        if (timeState > 1) state = "ending";

        gameObject.GetComponent<Renderer>().material.color = new Color(1f, 1f, 1f, opacityState);

        if (opacityState == 0) Destroy(this.gameObject);

        timeState += Time.deltaTime;

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

        Vector2 moveDirection = (Vector2)transform.position - targetPos;
        float angle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), 0.2f);
    }
}