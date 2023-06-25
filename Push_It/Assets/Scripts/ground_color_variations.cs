using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground_color_variations : MonoBehaviour
{
    [SerializeField] private MeshRenderer ground_rend;
    [SerializeField] private Color a,b,origin;
    [SerializeField] [Range(0f,1f)] private float t;

    private void Start()
    {

        
    }
    // Update is called once per frame
    void Update()
    {
        Color custom_color = Color.Lerp(a, b, 1 / t);
        ground_rend.material.SetColor("_Color", custom_color);
        origin = Color.Lerp(a,b, 1 / t);    
    }
}
