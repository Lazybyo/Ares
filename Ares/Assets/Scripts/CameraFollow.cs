using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	public Transform target;
	public PlayerMovement move;

	public float SmoothSpeed = 0.125f;
	public Vector3 offset;

	public bool isnot = false;
	private bool isnotnot = false;
	public float DTime = 0.2f;


	private void Update()
	{
		if (Input.GetButtonDown("Fire1") && isnot == true)
		{
            StartCoroutine(yes());
        }
	}

	IEnumerator yes()
	{
		isnotnot = true;
		move.IsDashing = true;
		yield return new WaitForSeconds(DTime);
		move.IsDashing = false;
		isnotnot = false;
    }

	private void FixedUpdate()
	{
		if (isnot == true)
		{
			if (isnotnot == true)
			{
				Vector3 desiredPosition = target.position + offset;
				Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
				transform.position = smoothedPosition;
			}
        }else
		{
			Vector3 desiredPosition = target.position + offset;
			Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, SmoothSpeed);
			transform.position = smoothedPosition;

		}
	}
}
