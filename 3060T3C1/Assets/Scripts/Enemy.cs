using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public string currentRoom;
    private GameObject player;
    private float chaseRange = 10f;

    private float movementSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= chaseRange)

        {

            Vector3 moveDirection = Vector3.MoveTowards(transform.position, player.transform.position, movementSpeed * Time.deltaTime);

            transform.position = moveDirection;

        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("zone"))
        {
            currentRoom = other.gameObject.name;
        }
    }

}
