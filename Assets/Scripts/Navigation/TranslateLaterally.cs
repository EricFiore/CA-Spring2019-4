using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslateLaterally : MonoBehaviour
{
    public float speed;
    private Vector3 startPoint = new Vector3(20, 1, 63);
    public Vector3 endPoint = new Vector3(-20, 1, 68);
 

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(startPoint, endPoint, Mathf.PingPong(Time.time, 1));
    }
}
