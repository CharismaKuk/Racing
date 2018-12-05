﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpeedManager : MonoBehaviour {

    public static int m_Speed;

    public  Text m_SpeedTxt;
    public int m_FontSize = 16;
    public  Rigidbody m_VehicleBody;

    void Awake()
    {
        m_SpeedTxt = GetComponent<Text>();
        m_Speed = 0;
    }

    private void Start()
    {
        m_SpeedTxt.font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;
        m_SpeedTxt.fontSize = m_FontSize;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_VehicleBody)
        {
            // check out about magnitude value!!
            m_SpeedTxt.text = string.Format("Speed: {0:0.00}", m_VehicleBody.velocity.magnitude);
        }
    }
}