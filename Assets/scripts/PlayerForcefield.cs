using UnityEngine;
using System.Collections;

public class PlayerForcefield : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        CharacterHealth enemy = other.GetComponent<CharacterHealth>();
        if (enemy && other.gameObject != this.gameObject) {
            enemy.damage(1);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        CharacterHealth enemy = other.GetComponent<CharacterHealth>();
        if (enemy && other.gameObject != this.gameObject) {
            enemy.damage(1);
        }
    }
}
