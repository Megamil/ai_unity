using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountDown : MonoBehaviour
{
    
    public TextMeshPro label;
    public GameObject player;
    public float playerX = -5.0f;
    public float playerY = 8.0f;
    public float playerZ = -2.0f;
    public int tempoTotal = 10;
    private float tempoDecorrido = 0f;
    private int tempoRestante;

    void Start()
    {
        tempoRestante = tempoTotal;
        label.text = "" + tempoRestante;
    }

    void Update()
    {
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
            tempoRestante = tempoTotal;
            player.transform.position = new Vector3(playerX, playerY, playerZ); //@todo
        }
    }

}
