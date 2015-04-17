using UnityEngine;
using System.Collections;

public class IKController : IIKController
{
	private Transform hand;
	private Transform elbow;
	private Transform arm;

	private float armLength;
	private float armLengthSq;
	private float foreArmLength;
	private float foreArmLengthSq;
	private float elbowZ;

	private float handToElbowZ;
	private float wristRotateAngle;
	private float armRotateAngle;

	public IKController (Transform hand, Transform elbow, Transform arm)
	{
		this.hand = hand;
		this.elbow = elbow;
		this.arm = arm;

		this.armLength = Vector3.Distance (arm.transform.position, elbow.transform.position);
		this.armLengthSq = Mathf.Pow (armLength, 2);
		this.foreArmLength = Vector3.Distance (elbow.transform.position, hand.transform.position);
		this.foreArmLengthSq = Mathf.Pow (foreArmLength, 2);

		Debug.Log (armLength + " " + foreArmLength);
	}

	public void calculateAngles (float distanceToTarget, out float armRotateAngle, out float wristRotateAngle)
	{
		float distanceToTargetSq = Mathf.Pow (distanceToTarget, 2);

		elbowZ = (distanceToTargetSq - foreArmLengthSq + armLengthSq) / (2 * distanceToTarget);
		
		float actualWristLocalZ = Mathf.Clamp (distanceToTarget, 0, armLength + foreArmLength);
		bool isArmFolding = (distanceToTarget < armLength + foreArmLength);
		bool isDistanceLargerThanArmsDiff = (distanceToTarget > Mathf.Abs (armLength - foreArmLength));
		
		if (isArmFolding && isDistanceLargerThanArmsDiff) {
			handToElbowZ = distanceToTarget - elbowZ;
			wristRotateAngle = Mathf.Acos (handToElbowZ / foreArmLength) * Mathf.Rad2Deg;
			armRotateAngle = Mathf.Acos (elbowZ / armLength) * Mathf.Rad2Deg;
		} else if (!isArmFolding) {
			armRotateAngle = 0;
			wristRotateAngle = 0;
		} else {
			armRotateAngle = 0;
			wristRotateAngle = -180;
		}
	}

	public void Update (Vector3 targetPosition, Quaternion targetRotation)
	{
		Debug.Log ("START!");

		float distanceToTarget = Vector3.Distance (arm.position, targetPosition);
		float armRotateAngle = 0;
		float wristRotateAngle = 0;

		this.hand.rotation = targetRotation;
		this.hand.position = targetPosition;

		calculateAngles (distanceToTarget, out armRotateAngle, out wristRotateAngle);

		arm.localRotation = Quaternion.Euler (armRotateAngle, 0, 0);
		elbow.localRotation = Quaternion.Euler (-wristRotateAngle, 0, 0);

		this.armLength = Vector3.Distance (arm.transform.position, elbow.transform.position);
		this.foreArmLength = Vector3.Distance (elbow.transform.position, hand.transform.position);
		Debug.Log (armLength + " " + foreArmLength + " " + distanceToTarget + " " + elbowZ + " " + armRotateAngle + " " + wristRotateAngle);
	}

	public void LateUpdate (Vector3 targetPosition, Quaternion targetRotation)
	{

	}
}
