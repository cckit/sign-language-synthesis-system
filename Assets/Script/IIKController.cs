using UnityEngine;

public interface IIKController
{
	void Update (Vector3 targetPosition, Quaternion targetRotation);
	void LateUpdate (Vector3 targetPosition, Quaternion targetRotation);
}