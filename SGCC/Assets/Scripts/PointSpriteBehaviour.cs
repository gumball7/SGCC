using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpriteBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    private float state = 1;
    public float fadeSpeed = 1f;
    public float riseSpeed = 1f;

    private bool kill = false;

    // Update is called once per frame
    void Update()
    {
        state -= Time.deltaTime * fadeSpeed;
        Vector3 pos = transform.position;
        pos.y += Time.deltaTime * riseSpeed;
        this.transform.position = pos;
        if (state < 0) { state = 0; kill = true; }
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, state);

        if (kill) Destroy(this.gameObject);
    }
}
