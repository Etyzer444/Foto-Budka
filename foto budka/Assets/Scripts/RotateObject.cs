using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed;
	
	public Camera currentCamera;
	float zoomAmount = 0;
	public float maxToClamp = 10;
	public float zoomSpeed = 10;
 
	public void Update() 
	{
     zoomAmount += Input.GetAxis("Mouse ScrollWheel");
     zoomAmount = Mathf.Clamp(zoomAmount, -maxToClamp, maxToClamp); //limit the amount the user can zoom in
     var translate = Mathf.Min(Mathf.Abs(Input.GetAxis("Mouse ScrollWheel")), maxToClamp - Mathf.Abs(zoomAmount));
     currentCamera.transform.Translate(0,0,translate * zoomSpeed * Mathf.Sign(Input.GetAxis("Mouse ScrollWheel")));
	}
	
	void OnMouseDrag()
	{
		transform.RotateAround(Vector3.down, Input.GetAxis("Mouse X") * rotationSpeed * Mathf.Deg2Rad);
		transform.RotateAround(Vector3.right, Input.GetAxis("Mouse Y") * rotationSpeed * Mathf.Deg2Rad);
	}
}
