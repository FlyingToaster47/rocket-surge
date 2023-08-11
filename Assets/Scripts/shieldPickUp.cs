using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shieldPickUp : MonoBehaviour {
    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.gameObject.tag == "Player") {
            Destroy(gameObject);
            collider.GetComponent<player>().shield(10);
        }
    }
}
