using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class car_move : MonoBehaviour
{
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private Vector3 move;
    [SerializeField] private float forward_speed;
    [SerializeField] public static bool is_looking = true;

    private Rigidbody car_rb;
    void Awake()
    {
        car_rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (joystick.Direction == Vector2.zero)
            return;
        move.x = joystick.Horizontal;
        move.y = joystick.Vertical;
        float yTrans = Mathf.Atan2(move.x, move.y) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, yTrans - 90, 0);

    }
    private void FixedUpdate()
    {
        if (joystick.Direction != Vector2.zero)
        {
            car_rb.AddForce(transform.forward * forward_speed * Time.deltaTime);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            Destroy(gameObject, 2f);
            is_looking = false;
        }
    }
}
    
