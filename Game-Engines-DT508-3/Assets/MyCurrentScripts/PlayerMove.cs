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
        transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical") * movementSpeed);
        transform.Translate(Vector3.right * Time.deltaTime * Input.GetAxis("Horizontal") * movementSpeed);

        if (Input.GetButton("Move Up"))
        {
            transform.Translate(Vector3.up * Time.deltaTime * movementSpeed);
        }
        
        if (Input.GetButton("Move Down"))
        {
            transform.Translate((Vector3.up * Time.deltaTime * movementSpeed) * -1);
        }
    }

}
