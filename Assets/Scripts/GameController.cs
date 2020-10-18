using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.IsolatedStorage;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

public class GameController : MonoBehaviour
{
    public TankController m_Tank;
    public Camera m_MainCamera;
    public LayerMask m_Mask;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray l_CamRay=m_MainCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(l_CamRay, out RaycastHit info, 200f, m_Mask))
            {
                SendTo(info.point);
            }
        }
    }

    void SendTo(Vector3 Destination)
    {
        m_Tank.GoTo(Destination);
    }
}
