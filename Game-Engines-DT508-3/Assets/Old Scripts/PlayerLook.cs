using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private string mouseXInput, mouseYInput;
    [SerializeField] private float mouseSensitivity;

    [SerializeField] private Transform playerBody;
    public Transform leftTurret;
    public Transform rightTurret;

    public Transform aimReticle;

    private float xAxisClamp;

    private void Awake()
    {
        LockCursor();
        xAxisClamp = 0.0f;
    }


    private void LockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis(mouseXInput) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInput) * mouseSensitivity * Time.deltaTime;

        xAxisClamp += mouseY;

        if(xAxisClamp > 30.0f)
        {
            xAxisClamp = 30.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(330.0f);
        }
        else if (xAxisClamp < -30.0f)
        {
            xAxisClamp = -30.0f;
            mouseY = 0.0f;
            ClampXAxisRotationToValue(30.0f);
        }

        transform.Rotate(Vector3.left * mouseY);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    private void ClampXAxisRotationToValue(float value)
    {
        Vector3 eulerRotation = transform.eulerAngles;
        eulerRotation.x = value;
        transform.eulerAngles = eulerRotation;
    }
}
