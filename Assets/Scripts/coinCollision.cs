using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollision : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision) {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D collider) {
        Destroy(gameObject);
    }
}
