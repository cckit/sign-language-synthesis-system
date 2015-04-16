using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Positions
{
	public Transform spine;
	public Transform shoulderCenter;
	public Transform leftArm;
	public Transform leftForeArm;
	public Transform leftHand;
	public Transform rightArm;
	public Transform rightForeArm;
	public Transform rightHand;

	public Dictionary<Features.Position, Vector3> positions;

	private float xPlane = 0.2f;

	// Use this for initialization
	public Positions (Transform characterTransform)
	{
		positions = new Dictionary<Features.Position, Vector3> ();
		SetUpTransform (characterTransform);
	}

	private void SetUpTransform (Transform characterTransform)
	{
		spine = characterTransform.Find ("EthanSkeleton/EthanHips/EthanSpine/EthanSpine1/EthanSpine2");
		shoulderCenter = spine.Find ("EthanNeck");
		leftArm = shoulderCenter.Find ("EthanLeftShoulder/EthanLeftArm");
		leftForeArm = leftArm.Find ("EthanLeftForeArm");
		leftHand = leftForeArm.Find ("EthanLeftHand");
		rightArm = shoulderCenter.Find ("EthanRightShoulder/EthanRightArm");
		rightForeArm = rightArm.Find ("EthanRightForeArm");
		rightHand = rightForeArm.Find ("EthanRightHand");

		Vector3 leftIpsi = GetIpsi (leftArm, shoulderCenter, spine);
		positions.Add (Features.Position.LEFT_IPSI, leftIpsi);

		Vector3 rightIpsi = GetIpsi (rightArm, shoulderCenter, spine);
		positions.Add (Features.Position.RIGHT_IPSI, rightIpsi);
	}

	private Vector3 GetIpsi (Transform arm, Transform shoulderCenter, Transform spine)
	{
		Vector3 ipsi = new Vector3 ();
		ipsi.x = (arm.position.x + shoulderCenter.position.x) / 2;
		ipsi.y = spine.position.y;
		ipsi.z = spine.position.z + xPlane;
		return ipsi;
	}
}
