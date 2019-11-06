using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterPutTeleScript : MonoBehaviour
{
    public Transform tele;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            tele.position = target.position;
        }
    }
}
