using UnityEngine;

public class bg_car_view : MonoBehaviour
{
    [SerializeField] GameObject[] cars1;
    [SerializeField] GameObject[] cars2;

    private void Awake()
    {
        for (int i = 0; i < cars1.Length; i++)
        {
            cars1[i].SetActive(false);
        }
        cars1[PlayerPrefs.GetInt("Car_selector1", 0)].SetActive(true);

        for (int i = 0; i < cars2.Length; i++)
        {
            cars2[i].SetActive(false);
        }
        cars2[PlayerPrefs.GetInt("Car_selector2", 0)].SetActive(true);


    }
}
