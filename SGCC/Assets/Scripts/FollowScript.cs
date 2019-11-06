using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{

    public Transform follow;
    public Vector3 offset;

    private float prev;

    private void Start()
    {
        transform.position = follow.position;
    }

    // Update is called once per frame
    void Update()
    {
        prev = transform.position.x - prev;
        if (prev < 0) transform.localRotation = Quaternion.Euler(0, 180, 0);
        else transform.localRotation = Quaternion.Euler(0, 0, 0);
        prev = transform.position.x;
        transform.position = Vector3.Lerp(follow.position, transform.position, 0.94f) + offset;
    }
}
