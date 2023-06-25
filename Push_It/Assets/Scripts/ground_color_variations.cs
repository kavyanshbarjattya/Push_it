using UnityEngine;

public class ground_color_variations : MonoBehaviour
{
    [SerializeField] private MeshRenderer ground_rend;
    [SerializeField] private Color[] myColors;
    [SerializeField][Range(0f, 1f)] private float learpTime;

    int ColorIndex = 0;
    int len;
    float t = 0;

    private void Start()
    {
        len = myColors.Length;
    }
    void Update()
    {
        // Putting Color lerp for changing the color of ground material
        ground_rend.material.color = Color.Lerp(ground_rend.material.color, myColors[ColorIndex], learpTime * Time.deltaTime);
        t = Mathf.Lerp(t, 1, learpTime * Time.deltaTime);
        // changing the index number of colors for variation
        if (t > 0.9f)
        {
            t = 0f;
            ColorIndex++;
            ColorIndex = (ColorIndex >= myColors.Length) ? 0 : ColorIndex;
        }
    }
}
