using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_controller : MonoBehaviour
{
    [SerializeField] private float acceleration;
    [SerializeField] private float steeringAngle = 20f;
    [SerializeField] private float Drag = 0.90f;
    [SerializeField] private float MaxSpeed = 15f;
    [SerializeField] private float Traction = 1f;
    [SerializeField] private VariableJoystick joystick;

    private Vector3 MoveForce;
    private bool isSteering = false;

    void Update()
    {
        //This is for z direction (forward & backward)
        MoveForce += transform.forward * acceleration * joystick.Vertical * Time.deltaTime;
        transform.position += MoveForce * Time.deltaTime;

        //This is for x direction (left & right)
        //float steeringInput = Input.GetAxisRaw("Horizontal");
        transform.Rotate(Vector3.up * joystick.Horizontal * MoveForce.magnitude * steeringAngle * Time.deltaTime);

        // Drag
        MoveForce *= Drag;
        MoveForce = Vector3.ClampMagnitude(MoveForce, MaxSpeed); // This will clamp the speed of the car

        if (joystick.Horizontal > 0 ||joystick.Horizontal < 0)
        {
            isSteering = true;
            if (isSteering == true)
            {
                transform.Rotate(Vector3.up * joystick.Horizontal * MoveForce.magnitude * steeringAngle * Time.deltaTime);
            }
        }
        else if(joystick.Horizontal == 0)
        {
            isSteering = false; 
        }

        //Traction
        Debug.DrawRay(transform.position, MoveForce.normalized * 3);
        Debug.DrawRay(transform.position, transform.forward * 3 ,Color.red);
        MoveForce = Vector3.Lerp(MoveForce.normalized,transform.forward,Traction * Time.deltaTime) * MoveForce.magnitude;
    }
}
