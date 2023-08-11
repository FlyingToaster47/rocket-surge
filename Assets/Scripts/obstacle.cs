using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        Color s = sprite.color;
        s.r += Random.Range(10, 253);
        s.b += Random.Range(10, 253);
        s.g += Random.Range(10, 253);
        sprite.color = s;   
    }
}
