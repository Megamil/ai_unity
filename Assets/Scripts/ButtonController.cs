using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    
    public Material newMaterial;
    public bool clicked = false;

    private Material originalMaterial;
    private Vector3 originalPosition;
    private new Renderer renderer;


    private void Start() {
        renderer = GetComponent<Renderer>();
        originalMaterial = renderer.material;
        originalPosition = this.transform.position;
    }

    private void OnCollisionEnter(Collision other) {
        
        if(!clicked) {
            transform.position = new Vector3(transform.position.x, transform.position.y - 0.05f, transform.position.z);
            renderer.material = newMaterial;
            clicked = true;
            EventsController.current.buttonClicked();
        }

    }

    public void resetState() {

        this.clicked = false;
        renderer.material = originalMaterial;
        transform.position = originalPosition;

    }

}
