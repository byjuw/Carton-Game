using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
	public Transform lookAt;
	private Vector3 offset = new Vector3 (0, 0, -10f);

	void LateUpdate()
	{
		Vector3 desiredPosition = lookAt.transform.position + offset;
		transform.position = desiredPosition;
	}
}