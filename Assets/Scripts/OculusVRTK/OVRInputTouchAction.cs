using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;

public class OVRInputTouchAction : BooleanAction
{
    public OVRInput.Controller m_Controller = OVRInput.Controller.Active;
    public OVRInput.Touch m_Touch;

    private void Update()
    {
        Receive(OVRInput.Get(m_Touch, m_Controller));
    }
}
