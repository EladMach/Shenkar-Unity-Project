using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesBehavior : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    [SerializeField] [Range(0,1)] float movementFactor;
    [SerializeField] float period = 2f;
    [SerializeField] float _degreesPerSecond = 20f;
    

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float cycles = Time.time / period; 
        
        const float tau = Mathf.PI * 2;  
        float rawSinWave = Mathf.Sin(cycles * tau);  

        movementFactor = (rawSinWave + 1f) / 2f;
        
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;

        transform.Rotate(new Vector3(0, _degreesPerSecond, 0) * Time.deltaTime);

    }
}
