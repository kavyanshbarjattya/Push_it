using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class car_shifter : MonoBehaviour
{
    [SerializeField] Transform cam_Trans;
    [SerializeField] Transform target_Trans;
    [SerializeField] GameObject[] cars;

    private int index;
    // Start is called before the first frame update
    void Start()
    {
        cam_Trans = Camera.main.transform;
    }

    // Update is called once per frame
    void Update()
    {
        cam_Trans.LookAt(target_Trans);
        target_Trans.position = Vector3.Lerp(target_Trans.position, cars[index].transform.position, Time.deltaTime);
    }
    public void Next_car()
    {
        index--;
        if(index < 0)
        {
            index = cars.Length - 1;
        }
    }
    public void Prev_car()
    {
        index++;
        if(index >= cars.Length)
        {
            index = 0;
        }
    }
    public void Selector()
    {
        SceneManager.LoadScene("main_menu");
    }
    public void Player1()
    {
        PlayerPrefs.SetInt("Car_selector1", index);
    }
    public void Player2()
    {
        PlayerPrefs.SetInt("Car_selector2", index);
    }

}
