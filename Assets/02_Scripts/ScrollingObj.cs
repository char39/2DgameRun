using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ScrollingObj : MonoBehaviour
{
    private float speed;
    void Start()
    {
        speed = 10.0f;
    }

    void Update()
    {
        if (!GameManager.instance.isGameOver)
            transform.Translate(Vector3.left * speed * Time.deltaTime);
    }
}
