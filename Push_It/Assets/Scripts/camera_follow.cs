using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_follow : MonoBehaviour
{
    [SerializeField] Transform[] car;
    [SerializeField] Vector3 center;
    [SerializeField] private Vector3 offset;
    [SerializeField] Transform target;
    [SerializeField] float laziness;

    public Vector3 whereCameraShouldBe;
    void Update()
    {
        for (int i = 0; i < car.Length; i++)
        {
            if (car[i] != null)
            {
                center.x += car[i].position.x + offset.x;
                center.y += car[i].position.y + offset.y;
                center.z += car[i].position.z + offset.z;
            }
        }
        center /= car.Length;
        target.transform.position = center;
        center = Vector3.zero;
    }
    private void FixedUpdate()
    {
        if (target != null)
        {
            whereCameraShouldBe = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, whereCameraShouldBe, 1/laziness);
        }
    }
}
