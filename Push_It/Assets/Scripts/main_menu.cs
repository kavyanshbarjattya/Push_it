using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class main_menu : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float rot_speed;
    [SerializeField] private GameObject main_menu1, main_menu2, about_section;
    [SerializeField] private float wait_time = 0.5f;
    // Update is called once per frame

    private void Start()
    {
        main_menu2.SetActive(false);
        about_section.SetActive(false);
    }
    void Update()
    {
        cam.eulerAngles += new Vector3(0, rot_speed *Time.deltaTime,0);
    }
    public void Play_btn()
    {
        StartCoroutine(Play_btn_timer());
    }
    IEnumerator Play_btn_timer()
    {
        yield return new WaitForSeconds(wait_time);
        main_menu2.SetActive(true);
        main_menu1.SetActive(false);
    }
    public void About_btn()
    {
        StartCoroutine(About_btn_Timer());
    }
    IEnumerator About_btn_Timer()
    {
        yield return new WaitForSeconds(wait_time);
        main_menu1.SetActive(false);
        about_section.SetActive(true);
    }
    public void Back_btn()
    {
        about_section.SetActive(false);
        main_menu1.SetActive(true); 
    }
    public void Quit_btn()
    {
        Application.Quit();
        Debug.Log("Quit !!");
    }
    public void AI_scene()
    {
        SceneManager.LoadScene("AI_Game");
    }
    public void local_player_scene()
    {
        SceneManager.LoadScene("local_player");
    }

}
