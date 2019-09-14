using UnityEngine;public class PlayerBehaviour : MonoBehaviour {
    public new Transform transform;    public new Camera camera;    public Animator animator;    public float speed; private bool left; private bool right;    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() {
        left = Input.GetKey(KeyCode.A);
        right = Input.GetKey(KeyCode.D);
        if (left ^ right) {
            if (left) transform.localRotation = Quaternion.Euler(0, 180, 0);
            else transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
            animator.SetBool("walking", true);
        } else animator.SetBool("walking", false);
    }}