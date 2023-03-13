using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControllerRoom1 : MonoBehaviour
{
    
    public GameObject player;
    public GameObject gate;
    public TextMeshProUGUI RespawnCounter;
    public GameObject cameraObj;

    public Vector3 playerPosition;
    public Vector3 gatePosition;

    private AnimationCurve moveCurve = new AnimationCurve();
    private float moveDuration = 1f;

    public GameObject buttonMain;

    void Start() {

        EventsController.current.onRespawnLevel += respawnLevel;
        EventsController.current.onButtonClicked += buttonClicked;
        EventsController.current.onFinishRoom += finishRoom;

        moveCurve.AddKey(0f, 0f);
        moveCurve.AddKey(0.5f, 0.5f);
        moveCurve.AddKey(1f, 1f);

        playerPosition = player.transform.position;
        gatePosition = gate.transform.position;

    }

    void respawnLevel() {

        gate.transform.position = gatePosition;
        RespawnCounter.text = (int.Parse(RespawnCounter.text) + 1) + "";
        foreach(ButtonController button in buttonMain.GetComponentsInChildren<ButtonController>()) {
            button.resetState();
        }
        player.transform.position = playerPosition;

    }

    void buttonClicked() {

        bool openGate = true;
        foreach(ButtonController button in buttonMain.GetComponentsInChildren<ButtonController>()) {
            if(!button.clicked) {openGate = false;}
        }

        if(openGate) { gateToogle(true); }


    }

    void gateToogle(bool open) {
        Vector3 gatePosition = gate.transform.position;
        float value = open ? 3f : -3f;
        Vector3 targetPosition = new Vector3(gatePosition.x, gatePosition.y + value, gatePosition.z);
        StartCoroutine(MoveObjAnimated(targetPosition, gate));
    }

    void finishRoom() {

        gateToogle(false);

        int jumpSpace = 11;

        Vector3 cameraObjPosition = cameraObj.transform.position;
        Vector3 targetPosition = new Vector3(cameraObjPosition.x + jumpSpace, cameraObjPosition.y, cameraObjPosition.z);
        StartCoroutine(MoveObjAnimated(targetPosition, cameraObj));

        playerPosition = new Vector3(playerPosition.x + jumpSpace, playerPosition.y, playerPosition.z);

    }

    private IEnumerator MoveObjAnimated(Vector3 targetPosition, GameObject obj)
    {
        Vector3 startPosition = obj.transform.position;
        float elapsedTime = 0f;

        while (elapsedTime < moveDuration)
        {
            float t = elapsedTime / moveDuration;
            obj.transform.position = Vector3.Lerp(startPosition, targetPosition, moveCurve.Evaluate(t));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        obj.transform.position = targetPosition;
    }


}
