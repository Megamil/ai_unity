using System;
using UnityEngine;

public class EventsController : MonoBehaviour
{
    
    public static EventsController current;
    private void Awake() { current = this; }

    //Actions
    public event Action onRespawnLevel;
    public event Action onButtonClicked;
    public event Action onFinishRoom;
    public event Action onInitCount;

    //Functions
    public void respawnLevel()
    {
        if (onRespawnLevel != null) { onRespawnLevel(); }
    }

    public void buttonClicked()
    {
        if (onButtonClicked != null) { onButtonClicked(); }
    }

    public void finishRoom() {
        if (onFinishRoom != null) { onFinishRoom(); }
    }

    public void initCount() {
        if (onInitCount != null) { onInitCount(); }
    }

}
