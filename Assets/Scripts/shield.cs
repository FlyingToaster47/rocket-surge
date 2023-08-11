using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield : MonoBehaviour
{
    public Collider2D playerCollider;
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Enemy") {
            Destroy(collider.gameObject);
            gameObject.SetActive(false);
            playerCollider.enabled = true;
        }
    }
}
