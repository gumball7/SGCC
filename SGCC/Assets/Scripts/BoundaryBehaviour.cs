using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryBehaviour : MonoBehaviour
{

    public Transform player;

    private bool colliding = false;

    private void Update()
    {
        float playerSpeed = player.GetComponent<PlayerBehaviour>().speed;
        float back = -(playerSpeed + 0.01f) * Time.deltaTime;
        if (colliding) player.transform.Translate(back, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform != player) return;
        colliding = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform != player) return;
        colliding = false;
    }

}
