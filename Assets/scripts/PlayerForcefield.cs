using UnityEngine;
using System.Collections;

public class PlayerForcefield : MonoBehaviour {
    private void OnTriggerEnter2D(Collider2D other) {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy) {
            enemy.damage(10);
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy) {
            enemy.damage(10);
        }
    }
}
