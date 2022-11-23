using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Collectables : MonoBehaviour
{

    public GameObject collectSoundPrefab;



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Instantiate(collectSoundPrefab, transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
        
    }



}
