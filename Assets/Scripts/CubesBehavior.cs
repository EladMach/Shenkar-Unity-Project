using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesBehavior : MonoBehaviour
{
    Vector3 startingPosition;
    
    private Player player;
    public Transform[] waypoints;
    private int _currentWaypointIndex = 0;
    private float _speed = 2f;
    private Rigidbody rb;

   

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player_Maria").GetComponent<Player>();
        startingPosition = transform.position;
        
    }


    void Update()
    {

        Transform wp = waypoints[_currentWaypointIndex];

        if (Vector3.Distance(transform.position, wp.position) < 1f)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % waypoints.Length;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, wp.position, _speed * Time.deltaTime);
        }

        if (player.currentHealth == 0)
        {
            this.gameObject.SetActive(false);
        }
    }    

    

}
