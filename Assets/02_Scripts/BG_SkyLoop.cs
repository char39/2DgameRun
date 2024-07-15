using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BG_SkyLoop : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    private float width;
    
    void Awake()    // Start()보다 Awake()가 먼저 호출됨. 제일 빠른 이벤트 함수
    {
        boxCollider2D = GetComponent<BoxCollider2D>();
        width = boxCollider2D.size.x;
        StartCoroutine(BG_RePosition());
    }
    void Start()
    {

    }
    void Update()
    {

    }

    IEnumerator BG_RePosition()
    {
        while (true)
        {
            if (transform.position.x <= -width)
                RePosition();
            yield return new WaitForSeconds(0.02f);
        }
    }
    
    private void RePosition()
    {
        Vector2 offset = new Vector2(width * 2, 0);
        transform.position = (Vector2)transform.position + offset;
    }
}
