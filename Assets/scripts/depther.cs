using UnityEngine;
using System.Collections;

public class depther : MonoBehaviour {
    public Transform playerTf;

    private Transform _backgroundTf;

    void Start() {
        print("If an error pops up about the background missing, it can be ignored. The code using the background won't run without it.");
        GameObject bg = GameObject.FindGameObjectWithTag("Background");
        _backgroundTf = bg != null ? bg.GetComponent<Transform>() : null;
    }

	void Update () {
        float lastY = 0;
        GameObject[] list = GameObject.FindGameObjectsWithTag("WorldObject");

        foreach(GameObject item in list) {
            Transform tf = item.GetComponent<Transform>();
            tf.position = new Vector3(tf.position.x,tf.position.y,tf.position.y);
            if (tf.position.y + 5 > lastY) {
                lastY = tf.position.y;
            }
        }
        if(_backgroundTf && playerTf)
            _backgroundTf.position = new Vector3(playerTf.position.x,playerTf.position.y, lastY + 5);
	}
}
