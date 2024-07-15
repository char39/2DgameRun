using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flatform : MonoBehaviour
{
    public GameObject[] obstacles;      // 장애물 옵젝들
    private bool stepped = false;       // 플레이어 캐릭터가 밟았는지

    // OnEnable() : 컴포넌트가 활성화 될 때마다 매번 실행되는 메서드
    //              발판을 리셋 처리 할 예정
    void OnEnable()     // Awake() => OnEnable() => Start() 순서대로 호출됨
    {
        stepped = false;
        for (int i = 0; i < obstacles.Length; i++)
        {
            if (Random.Range(0, 3) == 0)
            {
                obstacles[i].SetActive(true);
            }
            else
            {
                obstacles[i].SetActive(false);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  // 플레이어 옵젝이 자신을 밟을 때마다 점수를 추가함
    {
        
    }
}
