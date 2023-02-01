using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Transform spawnPointer;
    [SerializeField] float spanwnValue;


    void Update()
    {
        if (player.transform.position.y < -spanwnValue)
        {
            RespawnPointer();
        }
    }

    void RespawnPointer()
    {
        transform.position = spawnPointer.position;
    }
}
