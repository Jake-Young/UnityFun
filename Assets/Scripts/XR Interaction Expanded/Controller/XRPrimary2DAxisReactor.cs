using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;

[DisallowMultipleComponent]
public class XRPrimary2DAxisReactor : MonoBehaviour
{
    public XRPrimary2DAxisWatcher m_Primary2DAxisWatcher;
    public Vector2 m_IsMoved = Vector2.zero; // Display Vector2 in inspector
    public float m_DeadZone = 0.75f;

    private void Start()
    {
        //m_Primary2DAxisWatcher.m_Primary2DAxisMoved.AddListener(onPrimary2DAxisMoved);
        //m_Primary2DAxisWatcher.m_Primary2DAxisMoved.AddListener(onPrimary2DAxisTeleport);
    }

    public void onPrimary2DAxisMoved(Vector2 moved)
    {
        m_IsMoved = moved;
    }

    
    public void onPrimary2DAxisTeleport(Vector2 moved)
    {
        if (moved.y >= m_DeadZone || moved.y <= -m_DeadZone)
        {

        }
    }

}
