using UnityEngine;
public class ground_color_variations : MonoBehaviour
{
    [SerializeField] private MeshRenderer ground_rend;
    [SerializeField] private Color[] myColors;
    [SerializeField][Range(0f, 1f)] private float learpTime;
    private int ColorIndex = 0;
    private int len;
    private float t = 0;
    //This script is for ground color variation that show random color in ground
    private void Start()
    {
        len = myColors.Length; // taking the colors length that we put in inspector on a 'len' variable
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
            ColorIndex++; // increasing the color index for showing all colors on ground
            ColorIndex = (ColorIndex >= myColors.Length) ? 0 : ColorIndex;
        }
    }
}
