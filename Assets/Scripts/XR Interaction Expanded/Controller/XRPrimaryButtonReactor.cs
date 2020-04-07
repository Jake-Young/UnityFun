using System.Collections;
using UnityEngine;

public class XRPrimaryButtonReactor : MonoBehaviour
{
    public XRPrimaryButtonWatcher watcher;
    public bool IsPressed = false; // used to display button state in the Unity Inspector window

    void Start()
    {
        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (pressed) 
        {
            // Do X function
        }
        else
        {
            // Else do Y function
        }
    }
}
