using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;

public class TankController : MonoBehaviour
{
    private NavMeshAgent m_NavMeshAgent;
    private Animator m_Animator;

    private Vector3 lastFacing;
    private float currentAngle;
    private bool isRotating;
    void Awake()
    {
        m_NavMeshAgent = GetComponent<NavMeshAgent>();
        m_Animator = GetComponent<Animator>();
        isRotating = false;
    }

    private void Update()
    {
        if((m_NavMeshAgent.destination - transform.position).magnitude<m_NavMeshAgent.stoppingDistance 
           || m_NavMeshAgent.isPathStale)
            m_Animator.SetBool("Moving", false);
    }

    float RotatingAngle()
    {
        Vector3 currentFacing = transform.forward;
        Vector3 facingThere = m_NavMeshAgent.destination - transform.position;
        float l_Angle = Vector3.SignedAngle(currentFacing, facingThere, Vector3.up); 
        // Debug.Log(l_Angle);
        // if (l_Angle > 180)
        //     l_Angle = l_Angle - 360;
        return l_Angle;
        //isRotating = currentAngularVelocity > 1f; //or whatever treshold you find appropriate
    }
    
    public NavMeshAgent GetAgent()
    {
        return m_NavMeshAgent;
    }

    public void GoTo(Vector3 Pos)
    {
        m_NavMeshAgent.SetDestination(Pos);
        m_Animator.SetFloat("Horizontal", RotatingAngle());
        m_Animator.SetTrigger("Rotate");
        m_Animator.SetBool("Moving", true);
    }
}
