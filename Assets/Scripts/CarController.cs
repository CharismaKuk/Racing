using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    public WheelCollider[] m_wheelColliders = new WheelCollider[4];
    public GameObject[] m_wheel = new GameObject[4];

    public float m_TopSpeed = 250f;
    public float m_MaxTorque = 200f;
    public float m_MaxSteerAngle = 45f;
    public float m_CurrentSpeed;
    public float m_MaxBrakeTorque = 2200f;

    private float m_Forward;
    private float m_Turn;
    private float m_Brake;

    void FixedUpdate()
    {
        m_Forward = Input.GetAxis("Vertical");
        m_Turn = Input.GetAxis("Horizontal");
        m_Brake = Input.GetAxis("Jump");

        m_wheelColliders[0].steerAngle = m_MaxSteerAngle * m_Turn;
        m_wheelColliders[1].steerAngle = m_MaxSteerAngle * m_Turn;

        m_CurrentSpeed = 2 * 22 / 7 * m_wheelColliders[2].radius * m_wheelColliders[2].rpm * 60 / 1000;

        if (m_CurrentSpeed < m_TopSpeed)
        {
            m_wheelColliders[0].motorTorque = m_MaxTorque * m_Forward;
            m_wheelColliders[1].motorTorque = m_MaxTorque * m_Forward;
        }

        for (int i = 0; i < 4; i++)
        {
            m_wheelColliders[i].brakeTorque = m_MaxBrakeTorque * m_Brake;
        }
    }

    void Update()
    {
        Quaternion tempQuat;
        Vector3 tempVec3;

        for (int i = 0; i < 4; i++)
        {
            m_wheelColliders[i].GetWorldPose(out tempVec3,out tempQuat);
            m_wheel[i].transform.position = tempVec3;
            m_wheel[i].transform.rotation = tempQuat;
        }

        // Speed Update
        SpeedManager.m_Speed = (int)m_CurrentSpeed;
    }
}