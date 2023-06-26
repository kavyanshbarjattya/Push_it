using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
   [SerializeField] TextMeshProUGUI score_txt;
    private float score_counter = 0;
    private void Update()
    {
        score_counter++;
        score_txt.text = "Timer: " + (int)score_counter + " seconds";
        Time.timeScale *= 0.5f;
    }

}
