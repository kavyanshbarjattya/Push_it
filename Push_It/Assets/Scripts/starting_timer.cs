using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starting_timer : MonoBehaviour
{
    [SerializeField] private Animator starttimer_anim;
    [SerializeField] private float waiting_time;
    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(Start_anim());
    }
    IEnumerator Start_anim()
    {
        starttimer_anim.Play("Starting_Timer_anim");
        Time.timeScale = 0.01f;
        yield return new WaitForSeconds(waiting_time);
        Time.timeScale = 1;
    }
    
}
