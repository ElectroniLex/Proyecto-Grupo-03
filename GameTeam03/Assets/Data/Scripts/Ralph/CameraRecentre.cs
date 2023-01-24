using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraRecentre : MonoBehaviour
{
    private CinemachineFreeLook cinemachine;

    // Start is called before the first frame update
    void Start()
    {
        cinemachine = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("CameraRecentre") == 1)
        {
            cinemachine.m_RecenterToTargetHeading.m_enabled = true;
        }
        else
        {
            cinemachine.m_RecenterToTargetHeading.m_enabled = false;
        }
    }
}

