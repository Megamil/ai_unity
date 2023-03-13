using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishRoom : MonoBehaviour
{
    
    private bool canFinish = true;

    private void OnTriggerEnter(Collider other) {
        if(canFinish) {
            canFinish = false;
            EventsController.current.finishRoom();
        }
    }
}
