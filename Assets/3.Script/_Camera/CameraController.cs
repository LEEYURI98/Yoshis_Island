using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //카메라 범위 제한
    public float minX_1 = 3.32f;
    public float maxX_1 = 37.73f;
    public float minY_1 = -11.3f;
    public float maxY_1 = 6f;
    public float minX_2 = 26f;
    public float maxX_2 = 29f;
    public float minY_2 = -10f;
    public float maxY_2 = -6.4f;
    private void LateUpdate()
    {
        Vector3 position = transform.position;
        if (position.y > maxY_2)//지상맵
        {
            position.x = Mathf.Clamp(position.x, minX_1, maxX_1);
            position.y = Mathf.Clamp(position.y, minY_1, maxY_1);
        }
        else if (position.y <= maxY_2)//지하맵 y기준으로 나눔
        {
            position.x = Mathf.Clamp(position.x, minX_2, maxX_2);
            position.y = Mathf.Clamp(position.y, minY_2, maxY_2);
        }

        transform.position = position;
    }
}
