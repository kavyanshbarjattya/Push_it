using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class car_controller : MonoBehaviour
{
    [SerializeField] Transform front_right_trans;
    [SerializeField] Transform front_left_trans;
    [Header("This is for car movement")]
    [SerializeField] private float acceleration;
    [SerializeField] private float brake;
    [SerializeField] private float steeringAngle = 20f;
    [SerializeField] private float Drag = 0.90f;
    [SerializeField] private float MaxSpeed = 15f;
    [SerializeField] private float Traction = 1f;
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private Vector3 rotate;
    [SerializeField] private float angle;

    private Vector2 MoveForce;
    private bool isSteering = false;
    private float current_acceleration;
    private float current_brake;
    private Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); 
    }

    void Update()
    {
        //This is for z direction (forward & backward)
        MoveForce += transform.forward * acceleration * joystick.Direction * Time.deltaTime;
        Debug.Log(joystick.Direction);
        //transform.position += MoveForce * Time.deltaTime;

        //This is for x direction (left & right)
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
    /*private void FixedUpdate()
    {
        angle = Mathf.Atan(joystick.Vertical * joystick.Horizontal);
    }*/

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Out");
    }
}
