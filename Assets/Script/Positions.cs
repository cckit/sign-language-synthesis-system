using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Positions
{
	private Transform spine;
	private Transform shoulderCenter;
	private Transform leftArm;
	private Transform rightArm;

	public Dictionary<Features.Position, Vector3> positions;

	private float xPlane = 0.2f;

	// Use this for initialization
	public Positions (Transform characterTransform)
	{
		positions = new Dictionary<Features.Position, Vector3> ();
		setUpTransform (characterTransform);
	}

	private void setUpTransform (Transform characterTransform)
	{
		spine = characterTransform.Find ("EthanSkeleton/EthanHips/EthanSpine/EthanSpine1/EthanSpine2");
		shoulderCenter = spine.Find ("EthanNeck");
		leftArm = shoulderCenter.Find ("EthanLeftShoulder/EthanLeftArm");
		rightArm = shoulderCenter.Find ("EthanRightShoulder/EthanRightArm");

		Vector3 leftIpsi = getIpsi (leftArm, shoulderCenter, spine);
		positions.Add (Features.Position.LEFT_IPSI, leftIpsi);

		Vector3 rightIpsi = getIpsi (rightArm, shoulderCenter, spine);
		positions.Add (Features.Position.RIGHT_IPSI, rightIpsi);
	}

	private Vector3 getIpsi (Transform arm, Transform shoulderCenter, Transform spine)
	{
		Vector3 ipsi = new Vector3 ();
		ipsi.x = (arm.position.x + shoulderCenter.position.x) / 2;
		ipsi.y = spine.position.y;
		ipsi.z = spine.position.z + xPlane;
		return ipsi;
	}
}
