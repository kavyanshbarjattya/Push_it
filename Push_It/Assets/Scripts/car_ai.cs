using System.Collections;
using UnityEngine;

public class car_ai : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] private TrailRenderer drift_sign;
    [SerializeField] private  GameObject retry_screen;
    [SerializeField] private float waiting;

    public int MoveSpeed;
    private Rigidbody ai_rb;
    private void Awake()
    {
        ai_rb = GetComponent<Rigidbody>();
        retry_screen.SetActive(false);
    }
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        if (car_move.is_looking)
        {
            // here giving look at function to ai car as it only moves towards the player's car
            transform.LookAt(Player); 
        }
        Debug.Log(car_move.is_looking);
        if (car_move.is_looking)
        {
            // here giving movement to ai car
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
