using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float movementSpeed;

    
    private void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        transform.Translate(Vector3.up * Time.deltaTime * Input.GetAxis("Vertical")* movementSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal")* movementSpeed);      
    }

}
