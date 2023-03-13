using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerScript : MonoBehaviour
{
    public float speed = 5f;
    public float jumpforce = 7f;

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {
        
        if(Input.GetKeyDown("space")) {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
        }


        if(this.transform.position.y < -3) {
            EventsController.current.respawnLevel();
        }

    }

    private void FixedUpdate()
    {

        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");    

        Vector3 movement = new Vector3(horizontalInput, 0f , verticalInput).normalized;
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);


    }

}
