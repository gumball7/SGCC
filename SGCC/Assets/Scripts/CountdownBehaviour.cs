using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownBehaviour : MonoBehaviour
{
    public float startDelay = 3;
    public Text introText;
    public Sprite[] images;
    public int baseScale = 1;

    private int imageIndex = 0;
    private float timeState = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeState > startDelay)
        {
            transform.localScale = new Vector3(0, 0, 1);
            introText.transform.localScale = new Vector3(0, 0, 1);
            return;
        }

        timeState += Time.deltaTime;
        imageIndex = Mathf.FloorToInt(timeState);   
        float scaleNum = Mathf.Abs(Mathf.Sin(timeState * Mathf.PI));

        transform.localScale = new Vector3(scaleNum * baseScale, scaleNum * baseScale, 1);
        GetComponent<RawImage>().texture = images[imageIndex].texture;
    }
}
