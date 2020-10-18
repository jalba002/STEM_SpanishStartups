using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class CameraPassiveController : MonoBehaviour
{
    public float m_YPosition = 35f;
    public float m_ZDistanceFromTank = 50f;
    public TankController m_Tank;

    void Update()
    {
        Vector3 l_NewPosition = m_Tank.transform.position;
        l_NewPosition.y = m_YPosition;
        l_NewPosition += Vector3.forward * m_ZDistanceFromTank;
        this.transform.position = l_NewPosition;
    }
}
