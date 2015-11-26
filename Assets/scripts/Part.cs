using UnityEngine;
using System.Collections;

public class Part : MonoBehaviour {

    [SerializeField]
    private Shield _shield;
    public Shield shield {
        get { return _shield; }
        set { _shield = value;  }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            _shield.Heal(20);
            Destroy(gameObject);
        }
    }
}
