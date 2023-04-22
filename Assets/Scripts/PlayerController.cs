using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float PlayerMoveSpeed;
    [SerializeField]
    private float PlayerRotateSpeed = 9.0f;

    float deltaYRotate = 0;

    private CharacterController  charController;

    private void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        movement();

    }

    private void movement()
    {
        deltaYRotate += Input.GetAxis("Horizontal") * PlayerRotateSpeed;
        float rotationY = transform.eulerAngles.x + deltaYRotate;
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
         

        float deltaX = Input.GetAxis("Vertical") * PlayerMoveSpeed;
        Vector3 movement = new Vector3(deltaX, 0, 0);
        movement = Vector3.ClampMagnitude(movement, PlayerMoveSpeed);
        movement.y = -9f;// gravity
        movement *=  Time.deltaTime;
        movement = transform.TransformDirection(movement);
        charController.Move(movement);


        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }
}
