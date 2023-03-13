using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    
    public TextMeshPro label;
    public int tempoTotal = 10;
    private float tempoDecorrido = 0f;
    private int? tempoRestante;

    public GameObject gate;
    public bool[] clicked = {false,false};

    void Start()
    {
        EventsController.current.onInitCount += initCount;
        EventsController.current.initCount();  
    }

    void initCount() {
        tempoRestante = tempoTotal;
        label.text = "" + tempoRestante;
        EventsController.current.onRespawnLevel += onRespawnLevel;
    }

    void Update()
    {
        if(tempoRestante == null) {return;}
        if (tempoRestante > 0)
        {
            tempoDecorrido += Time.deltaTime;
            if (tempoDecorrido >= 1f)
            {
                tempoDecorrido = 0f;
                tempoRestante--;
                label.text = "" + tempoRestante;
            }
        }
        else
        {
            EventsController.current.respawnLevel();    
        }
    }

    void onRespawnLevel() {
        tempoRestante = tempoTotal;
        label.text = "" + tempoRestante;
    }

}
