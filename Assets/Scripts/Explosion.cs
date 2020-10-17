using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [Range(0f, 5000f)] public float m_ExplosionForce = 10f;
    [Range(0f, 100f)] public float m_ExplosionRadius = 10f;
    public bool ExplodeButton = false;

    private Rigidbody m_SelfRB;

    private void Start()
    {
        m_SelfRB = GetComponent<Rigidbody>();
    }

    void Explode()
    {
        Collider[] l_NearbyObjects = Physics.OverlapSphere(this.gameObject.transform.position, m_ExplosionRadius);

        
        foreach (Collider RB in l_NearbyObjects)
        {
            Rigidbody l_RB =  RB.GetComponent<Rigidbody>();
            if(l_RB!=null)
                l_RB.AddForce((RB.gameObject.transform.position-this.transform.position).normalized*m_ExplosionForce, ForceMode.Impulse);
        }
        //m_SelfRB.AddExplosionForce(m_ExplosionForce, this.gameObject.transform.position, m_ExplosionRadius);
    }
    
    private void OnValidate()
    {
        if (ExplodeButton)
        {
            ExplodeButton = false;
            Explode();
        }
    }
}
