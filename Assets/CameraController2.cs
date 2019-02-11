using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController2 : MonoBehaviour
{
	 public float speed = 1.5f;
     private float X;
     private float Y;
	 
     void Update() 
	 {
		Vector3 pos = transform.position;
		
        if(Input.GetMouseButton(1)) 
		{
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }		 

		if (Input.GetKey(KeyCode.A))
		{
			pos.x -= 10 * Time.deltaTime;
		}
			
		if (Input.GetKey(KeyCode.D))
		{
			pos.x += 10 * Time.deltaTime;
		}
			
		if (Input.GetKey(KeyCode.W))
		{
			pos.z += 10 * Time.deltaTime;
		}
			
		if (Input.GetKey(KeyCode.S))
		{
			pos.z -= 10 * Time.deltaTime;
		}
			
		transform.position = pos;	
		
	
	 }
  }
