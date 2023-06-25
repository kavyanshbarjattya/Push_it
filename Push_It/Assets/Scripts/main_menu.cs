using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_menu : MonoBehaviour
{
    [SerializeField] private Transform cam;
    [SerializeField] private float rot_speed;
    // Update is called once per frame
    void Update()
    {
        cam.eulerAngles += new Vector3(0, rot_speed *Time.deltaTime,0);
    }
    public void Play_btn()
    {

    }
}
