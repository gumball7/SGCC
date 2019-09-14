using UnityEngine;

public class CloudBehavier : MonoBehaviour {
    public new Transform transform;
    public new Camera camera;
    public Vector3 movement;
    private float horizontalMin;
    private float horizontalMax;

    void Start() {
        float halfHeight = camera.orthographicSize;
        float halfWidth = camera.aspect * halfHeight;

        horizontalMin = -halfWidth;
        horizontalMax = halfWidth;
    }

    void Update() {
        transform.Translate(movement);
        if (movement.x > 1 && transform.position.x > horizontalMax) {
            transform.position.Set(horizontalMin, Random.Range(-1, 2), transform.position.z);
        } else if (movement.x < 1 && transform.position.x < horizontalMin) {
            transform.position.Set(horizontalMax, Random.Range(-1, 2), transform.position.z);
        }
    }
}
