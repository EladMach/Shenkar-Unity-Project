using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectables : MonoBehaviour
{

    public GameObject collectSoundPrefab;
    public float rotationSpeed = 10f; 

    private void Update()
    {
        CoinRotation();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(collectSoundPrefab, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
        
    }

    void CoinRotation()
    {
        transform.Rotate(new Vector3(0, 10f, 0) * rotationSpeed * Time.deltaTime);
    }
}
