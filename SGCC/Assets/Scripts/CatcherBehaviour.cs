using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatcherBehaviour : MonoBehaviour
{

    public float speed = 10;
    public GameObject pointPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool left = Input.GetKey(KeyCode.A);
        bool right = Input.GetKey(KeyCode.D);
        if (left ^ right)
        {
            if (left) transform.localRotation = Quaternion.Euler(0, 180, 0);
            else transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject.Find("GameManager").GetComponent<GameManagerScript>().addPoint(10);
        GameObject pointSprite = Instantiate(pointPrefab, collision.transform.position, Quaternion.identity);
        pointSprite.transform.parent = GameObject.Find("FallingObjectParent").transform;
        Destroy(collision.gameObject);
    }

}
