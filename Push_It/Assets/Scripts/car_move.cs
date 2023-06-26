using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class car_move : MonoBehaviour
{
    [SerializeField] private VariableJoystick joystick;
    [SerializeField] private Vector3 move;
    [SerializeField] private float forward_speed;
    [SerializeField] public static bool is_looking = true;
    public TrailRenderer drifting_sign;
    [SerializeField] private float waitingTime;
    public GameObject retry_screen;

    private Rigidbody car_rb;
    void Awake()
    {
        car_rb = GetComponent<Rigidbody>();
        retry_screen.SetActive(false);
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
            Destroy(gameObject, 2.5f);
            StartCoroutine(RetryScreen());
            is_looking = false;
        }
    }
    public IEnumerator RetryScreen()
    {
        yield return new WaitForSeconds(waitingTime);
        retry_screen.SetActive(true);
    }
}