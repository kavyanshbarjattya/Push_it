using UnityEngine;

public class camera_follow : MonoBehaviour
{
    [SerializeField] car_move[] car;
    [SerializeField] Vector3 center;
    [SerializeField] private Vector3 offset;
    [SerializeField] Transform target;
    [SerializeField] float laziness;

    public Vector3 whereCameraShouldBe;
    private void Start()
    {
        car = FindObjectsOfType<car_move>();
    }
    void Update()
    {
        // here putting our two cars position to a gameobject 'center'
        for (int i = 0; i < car.Length; i++)
        {
            if (car[i] != null && car[i].isActiveAndEnabled)
            {
                center.x += car[i].gameObject.transform.position.x + offset.x;
                center.y += car[i].gameObject.transform.position.y + offset.y;
                center.z += car[i].gameObject.transform.position.z + offset.z;
            }
        }
        center /= car.Length; //here putting 'center' gameobject at mid of the cars 
        target.transform.position = center; 
        center = Vector3.zero;
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            whereCameraShouldBe = target.position + offset;
            // here using lerp() as it give value between 0 & 1 for movement of camera
            transform.position = Vector3.Lerp(transform.position, whereCameraShouldBe, 1/laziness);
        }
    }
}
