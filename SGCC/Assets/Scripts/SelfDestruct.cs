using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timeToKill;

    private float internalCounter = 0;

    // Update is called once per frame
    void Update()
    {
        internalCounter += Time.deltaTime;
        if (internalCounter > timeToKill) Destroy(this.gameObject);
    }
}
