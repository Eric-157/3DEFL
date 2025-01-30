using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 5.0f;
    public float horizontalInput;
    public float verticalInput;
    public string currentRoom;
    public Rigidbody rb;

    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // There is a bug with movement and colliders, you can phase through certain corners, will fix in a later version.
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        rb.MovePosition(transform.position + (transform.forward * verticalInput * speed * Time.deltaTime) + (transform.right * horizontalInput * speed * Time.deltaTime));
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("zone"))
        {
            currentRoom = other.gameObject.name;
        }
    }
}
