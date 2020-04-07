using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[System.Serializable]
public class Primary2DAxisMovedEvent : UnityEvent<Vector2> { }

[DisallowMultipleComponent]
public class XRPrimary2DAxisWatcher : MonoBehaviour
{
    public Primary2DAxisMovedEvent m_Primary2DAxisMoved;

    public XRController m_XRController;

    [SerializeField]
    private XRNode m_ControllerNode = XRNode.LeftHand;

    private Vector2 m_LastKnownPosition = Vector2.zero;
    private List<InputDevice> m_DevicesWithPrimary2DAxis;

    private void Awake()
    {
        if (m_Primary2DAxisMoved == null)
        {
            m_Primary2DAxisMoved = new Primary2DAxisMovedEvent();
        }

        m_DevicesWithPrimary2DAxis = new List<InputDevice>();
    }


    private void OnEnable()
    {
        List<InputDevice> allDevices = new List<InputDevice>();
        InputDevices.GetDevices(allDevices);
        foreach (InputDevice device in allDevices)
        {
            InputDevices_deviceConnected(device);
        }

        InputDevices.deviceConnected += InputDevices_deviceConnected;
        InputDevices.deviceDisconnected += InputDevices_deviceDisconnected;
    }

    private void OnDisable()
    {
        InputDevices.deviceConnected -= InputDevices_deviceConnected;
        InputDevices.deviceDisconnected -= InputDevices_deviceDisconnected;
        m_DevicesWithPrimary2DAxis.Clear();
    }

    private void InputDevices_deviceConnected(InputDevice device)
    {
        Vector2 discardedValue;
        if (device.TryGetFeatureValue(CommonUsages.primary2DAxis, out discardedValue))
        {
            m_DevicesWithPrimary2DAxis.Add(device); // Add any device that has primary 2d axis input
        }
    }

    private void InputDevices_deviceDisconnected(InputDevice device)
    {
        if (m_DevicesWithPrimary2DAxis.Contains(device))
        {
            m_DevicesWithPrimary2DAxis.Remove(device);
        }
    }

    private void Update()
    {
        bool positionChanged = false;

        Vector2 primary2DAxisPosition = Vector2.zero;

        if (m_ControllerNode == XRNode.LeftHand)
        {
            positionChanged = m_DevicesWithPrimary2DAxis[0].TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxisPosition)
                              && primary2DAxisPosition != Vector2.zero
                              || positionChanged;
        }
        else if (m_ControllerNode == XRNode.RightHand)
        {
            positionChanged = m_DevicesWithPrimary2DAxis[1].TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxisPosition)
                              && primary2DAxisPosition != Vector2.zero
                              || positionChanged;
        }

        /*foreach (var device in m_DevicesWithPrimary2DAxis)
        {
            positionChanged = device.TryGetFeatureValue(CommonUsages.primary2DAxis, out primary2DAxisPosition)
                                && primary2DAxisPosition != Vector2.zero
                                || positionChanged;
        }*/

        if (positionChanged)
        {
            m_Primary2DAxisMoved.Invoke(primary2DAxisPosition);
            m_LastKnownPosition = primary2DAxisPosition;
        }
    }
}
