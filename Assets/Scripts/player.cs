using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Vector2 screenBounds;

    public Rigidbody2D rigid_body;
    public float speed = 10f;
    public float maxSpeed = 30f;
    public float minSpeed = 10f;
    Vector2 direction;
    bool moveUpwards = true;
    void Start() {
        direction = transform.up;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }
    void Update()
    {
        if (moveUpwards) {
            direction = transform.up;
        }

        rigid_body.velocity = direction * speed;
        Vector3 point = Camera.main.WorldToViewportPoint(transform.position);
        if (Input.GetButton("Horizontal")) {
            float value = Input.GetAxis("Horizontal");
            float rotation = transform.rotation.z * 100;
            if (value > 0) {
                if (rotation > -30) {
                    direction.x += 0.6f;
                    transform.Rotate(0, 0, -5f);
                }
            } else if (value < 0) {
                if (rotation < 30) {
                    direction.x -= 0.6f;
                    transform.Rotate(0, 0, 5f);   
                }
            }
        }
        else {
            resetRotation();
        }
    }

    void LateUpdate() {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, -1 * screenBounds.x, screenBounds.x);
        transform.position = viewPos;
    }

    void resetRotation() {
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(new Vector3(0, 0, 0)), 80 * Time.deltaTime);
    }

    public void speedUp (int secs) {
        Collider2D playerCollider = GetComponent<Collider2D>();
        playerCollider.isTrigger = true;
        speed = maxSpeed;
        StartCoroutine(speedNormal(secs));

        IEnumerator speedNormal(int sec) {
            yield return new WaitForSeconds(sec);
            speed = minSpeed;
            playerCollider.isTrigger = false;
        }
    }
    public void shield (int secs) {
        
        Collider2D playerCollider = GetComponent<Collider2D>();
        playerCollider.enabled = false;

        GameObject shield = gameObject.transform.GetChild(2).gameObject;
        shield.SetActive(true);


        StartCoroutine(speedNormal(secs));
        IEnumerator speedNormal(int sec) {
            yield return new WaitForSeconds(sec);

            shield.SetActive(false);
            playerCollider.enabled = true;

        }
    }
}
