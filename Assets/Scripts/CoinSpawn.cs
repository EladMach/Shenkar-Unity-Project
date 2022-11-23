using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    public GameObject coinPrefabe;
    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(CoinSpawnRoutine());
    }

    private void Update()
    {
        
    }

    IEnumerator CoinSpawnRoutine()
    {
        while (_stopSpawning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-13f, 25f), 0.5f, (Random.Range(-10f, 26f)));
            Instantiate(coinPrefabe, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(3.0f);
        }

    }
    
}   

