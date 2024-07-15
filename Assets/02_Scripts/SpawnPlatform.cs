using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlatform : MonoBehaviour
{
    [SerializeField]private GameObject flatform;
    private Vector3 spawnPos;
    private Vector3 startPos;
    private bool isSpawn = true;

    void Start()
    {
        flatform = Resources.Load<GameObject>("Prefabs/Platform");
        startPos = transform.position;
        spawnPos = startPos;
        SpawnFlatform();
    }

    void Update()
    {
        SpawnTime();
    }

    void SpawnTime()
    {
        if (!isSpawn && !GameManager.instance.isGameOver)
        {
            isSpawn = true;
            Invoke("SpawnFlatform", Random.Range(2.5f, 5f));
        }
    }

    void SpawnFlatform()
    {
        spawnPos = new Vector3(spawnPos.x, spawnPos.y + Random.Range(-3, 3), spawnPos.z);
        Instantiate(flatform, spawnPos, Quaternion.identity);
        spawnPos = startPos;
        isSpawn = false;
    }
}
