using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private float speed = 2.0f;
    public float horizontalInput;
    public float verticalInput;
    public string currentRoom;
    public Rigidbody rb;

    private Camera mainCamera;

    private Vector3 mousePos;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
        rb.MovePosition(transform.position + (transform.forward * verticalInput * speed * Time.deltaTime) + (transform.right * horizontalInput * speed * Time.deltaTime));

        mousePos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = mainCamera.ScreenPointToRay(mousePos);
            if (Physics.Raycast(ray, out raycastHit, 3f))
            {
                if (raycastHit.transform != null)
                {
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("zone"))
        {
            currentRoom = other.gameObject.name;
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag == "enemy")
        {
            Destroy(gameObject);

        }
    }
}
