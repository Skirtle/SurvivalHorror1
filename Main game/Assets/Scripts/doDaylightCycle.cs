using UnityEngine;

public class doDaylightCycle : MonoBehaviour {
    public float speed;
    public float time = 1f;

    // Update is called once per frame
    void FixedUpdate() {
        transform.Rotate(0, speed, 0);
        time = (time+speed)%24;
    }
}
