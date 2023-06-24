using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class car_ai : MonoBehaviour
{
    [SerializeField] Transform Player;
    public int MoveSpeed;

    Rigidbody ai_rb;
    private void Awake()
    {
        ai_rb = GetComponent<Rigidbody>();

    }


    void Update()
    {
        if (car_move.is_looking)
        {
            transform.LookAt(Player);
        }
        Debug.Log(car_move.is_looking);
        if (car_move.is_looking)
        {
            ai_rb.AddForce(transform.forward * MoveSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Trigger"))
        {
            car_move.is_looking = false;
            Destroy(gameObject, 3f);
        }
    }
}