using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    
    private bool clicked = false;
    public Material newMaterial;
    private Renderer renderer;


    private void Start() {
        renderer = GetComponent<Renderer>();
    }

    private void OnCollisionEnter(Collision other) {
        
        if(!clicked) {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            renderer.material = newMaterial;
            clicked = true;
        }

    }

}
