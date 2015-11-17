using UnityEngine;
using System.Collections;

public class MainCore : MonoBehaviour {

    [SerializeField]
    private int _health = 1000;
    [SerializeField]
    private int _dms = 0;
    [SerializeField]
    private bool _alive = true;

    //private GameObject body;

    void Start() {
        //body = gameObject;
        InvokeRepeating("dmsHandling", 0, 1);
    }

    private void destroyed() {
        Debug.Log("Main core destroyed");
        CancelInvoke();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<PolygonCollider2D>().enabled = false;
    }

    private void dmsHandling() {
        _health -= _dms;
        if (_health < 0) {
            _health = 0;
            _dms = 0;
            _alive = false;
            destroyed();
        }
    }

	private void OnCollisionEnter2D(Collision2D other) {
        string name = other.collider.name;
        if (name == "Enemy" || name == "Enemy(Clone)" || name == "Player" && _alive) {
            _dms++;
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        string name = other.collider.name;
        if (name == "Enemy" || name == "Enemy(Clone)" || name == "Player" && _alive) {
            _dms--;
        }
    }
}
