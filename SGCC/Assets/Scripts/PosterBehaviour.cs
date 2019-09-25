using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PosterBehaviour : MonoBehaviour
{
    public Transform poster;
    public GameObject player;
    public Vector3 baseScale, finalScale;
    public GameObject basePos, finalPos;

    public float moveSpeed;
    public float scaleSpeed;

    private bool isActive = false;

    // Start is called before the first frame update
    void Start()
    {
        poster.localScale = baseScale;
        poster.position = basePos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 scale, pos;
        Vector3 targetScale, targetPos;

        if (isActive)
        {
            targetScale = finalScale;
            targetPos = finalPos.transform.position;
        }
        else
        {
            targetScale = baseScale;
            targetPos = basePos.transform.position;
        }

        scale = poster.transform.localScale;
        scale = Vector3.Lerp(targetScale, scale, scaleSpeed);
        pos = poster.transform.position;
        pos = Vector3.Lerp(targetPos, pos, moveSpeed);
        poster.transform.localScale = scale;
        poster.transform.position = pos;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            isActive = false;
        }
    }
}
