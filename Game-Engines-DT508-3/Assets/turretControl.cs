using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretControl : MonoBehaviour
{
    //public GameObject target;
    //public GameObject turretPivot;

    public Transform currentPosition;
    public Transform targetPosition;

    private float timeCount = 1.0f;
    
    void Start()
    {
        //currentPosition = turretPivot.transform;
    }

    
    void Update()
    {
        //targetPosition = target.transform;
        transform.rotation = Quaternion.Slerp(currentPosition.rotation, targetPosition.rotation, timeCount);
        timeCount = timeCount + Time.deltaTime;
    }
}
