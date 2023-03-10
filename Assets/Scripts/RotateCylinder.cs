using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCylinder : MonoBehaviour
{
   
    public float rotateforce = 15f;

    // Update is called once per frame
    void Update()
    {
        
        this.transform.Rotate(Vector3.left * rotateforce * Time.fixedDeltaTime);

    }
}
