﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionMeshHandler : MonoBehaviour
{
    public delegate void DetectionEnter(int signatureID, Vector3 position);
    public DetectionEnter detectionEnterDelegate;

    public delegate void DetectionStay(int signatureID, Vector3 position);
    public DetectionStay detectionStayDelegate;

    public delegate void DetectionExit(int signatureID, Vector3 position);
    public DetectionExit detectionExitDelegate;

    private void OnTriggerEnter(Collider other)
    {
        detectionEnterDelegate(other.transform.GetInstanceID(), other.transform.position);
    }

    private void OnTriggerStay(Collider other)
    {
        detectionStayDelegate(other.transform.GetInstanceID(), other.transform.position);
    }

    private void OnTriggerExit(Collider other)
    {
        detectionExitDelegate(other.transform.GetInstanceID(), other.transform.position);
    }
}
