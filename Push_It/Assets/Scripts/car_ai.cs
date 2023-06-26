using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class car_ai : MonoBehaviour
{
    [SerializeField] Transform Player;
    public TrailRenderer drift_sign;
    public GameObject retry_screen;
    [SerializeField] private float waiting;

    public int MoveSpeed;

    private Rigidbody ai_rb;
    private void Awake()
    {
        ai_rb = GetComponent<Rigidbody>();
        retry_screen.SetActive(false);

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
            drift_sign.enabled = false;
            car_move.is_looking = false;
            Destroy(gameObject, 2.5f);
            StartCoroutine(RetryScreen());
        }
    }
    
    IEnumerator RetryScreen()
    {
        yield return new WaitForSeconds(waiting);
        retry_screen.SetActive(true);
    }
}
