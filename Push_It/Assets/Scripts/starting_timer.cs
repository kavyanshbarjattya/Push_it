using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starting_timer : MonoBehaviour
{
    [SerializeField] private GameObject joystick;
    //[SerializeField] private GameObject joystick2;
    [SerializeField] private Animator starttimer_anim;
    [SerializeField] private float waiting_time;
    // Start is called before the first frame update
    void Start()
    {
        joystick.SetActive(false);
        //joystick2.SetActive(false);
        Time.timeScale = 0;
        StartCoroutine(Start_anim());
    }
    IEnumerator Start_anim()
    {
        starttimer_anim.Play("Starting_Timer_anim");
        Time.timeScale = 0.01f;
        yield return new WaitForSeconds(waiting_time);
        joystick.SetActive(true);
        Time.timeScale = 1;
        //joystick2.SetActive(true);
    }
    
}
