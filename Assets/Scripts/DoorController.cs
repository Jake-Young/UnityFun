using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public int id;

    private void Start()
    {
        GameEvents.CURRENT.onDoorwayTriggerEnter += OnDoorwayOpen;
        GameEvents.CURRENT.onDoorwayTriggerExit += OnDoorwayClose;
    }

    private void OnDoorwayOpen(int id)
    {
        if (id == this.id)
        {
            LeanTween.moveLocalY(gameObject, 7.0f, 1.5f).setEaseInOutQuad();
        }
        
    }

    private void OnDoorwayClose(int id)
    {
        if (id == this.id)
        {
            LeanTween.moveLocalY(gameObject, 2.5f, 1.5f).setEaseInOutQuad();
        }
    }
}
