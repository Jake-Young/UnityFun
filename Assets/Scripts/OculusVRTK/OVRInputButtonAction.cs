using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zinnia.Action;

public class OVRInputButtonAction : BooleanAction
{
    public OVRInput.Controller m_Controller = OVRInput.Controller.Active;
    public OVRInput.Button m_Button;

    private void Update()
    {
        Receive(OVRInput.Get(m_Button, m_Controller));
    }
}
