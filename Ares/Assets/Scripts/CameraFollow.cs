using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;

	public float SmoothSpeed = 0.125f;
	public Vector3 offset;


	private void Update()
	{
		
	}


	private void FixedUpdate()
	{
		
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
		transform.position = smoothedPosition;
		
	}
}
