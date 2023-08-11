using UnityEngine;

public class cameraFollow : MonoBehaviour
{
    public Transform player;

    void Update () {
        transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z) + new Vector3(0, 3, -5);
    }
}
