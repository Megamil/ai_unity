using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour {
    
    private Transform target;
    public float smoothTime = 0.3f;
    private Vector3 velocity = Vector3.zero;

    void Start() {

        this.target = this.transform;

    }
    
    void LateUpdate() {
        
        // Define o ponto final para onde a câmera irá se mover
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
        
        // Faz a transição suave entre a posição atual e a posição de destino
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        
        // Adiciona o movimento suave da câmera no eixo x
        transform.position += new Vector3(1.0f, 0.0f, 0.0f) * Time.deltaTime;
    }
}
