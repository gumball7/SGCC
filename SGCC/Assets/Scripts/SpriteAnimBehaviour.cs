using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteAnimBehaviour : MonoBehaviour
{
    public double freq = 5;
    public float scale = 0.1f;
    public Vector3 initScale;

    // Start is called before the first frame update
    void Start()
    {
        initScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = initScale + new Vector3(
            Mathf.Sin((float)(2 * Mathf.PI * freq * Time.time)) * scale,
            Mathf.Sin((float)(2 * Mathf.PI * freq * Time.time)) * scale,
            0
            );
    }
}
