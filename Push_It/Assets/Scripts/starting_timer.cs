using System.Collections;
using UnityEngine;

public class starting_timer : MonoBehaviour
{
    [SerializeField] private Animator starttimer_anim;
    [SerializeField] private float waiting_time;

    // this script is for StartingTimer's animation
    void Start()
    {
        Time.timeScale = 0;
        StartCoroutine(Start_anim());
    }
    IEnumerator Start_anim() // this will take time for animation to play and then start the game
    {
        starttimer_anim.Play("counting_timer");
        Time.timeScale = 0.01f;
        yield return new WaitForSeconds(waiting_time);
        Time.timeScale = 1;
    }
}
