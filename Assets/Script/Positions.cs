using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Positions
{
	private Transform spine;
	private Transform shoulderCenter;
	private Transform leftShoulder;
	private Transform rightShoulder;

	public Dictionary<Features.Position, Vector3> positions;

	private float xPlane = 0.2f;

	// Use this for initialization
	public Positions (Transform characterTransform)
	{
		positions = new Dictionary<Features.Position, Vector3> ();

		spine = characterTransform.Find ("Hips/Spine/Spine1");
		shoulderCenter = spine.Find ("Spine2");
		leftShoulder = shoulderCenter.Find ("LeftShoulder");
		rightShoulder = shoulderCenter.Find ("RightShoulder");

		Vector3 leftIpsi = new Vector3 ();
		leftIpsi.x = leftShoulder.position.x;
		leftIpsi.y = (spine.position.y + shoulderCenter.position.y) / 2;
		leftIpsi.z = spine.position.z + xPlane;
		positions.Add (Features.Position.LEFT_IPSI, leftIpsi);

		Vector3 rightIpsi = new Vector3 ();
		rightIpsi.x = rightShoulder.position.x;
		rightIpsi.y = (spine.position.y + shoulderCenter.position.y) / 2;
		rightIpsi.z = spine.position.z + xPlane;
		positions.Add (Features.Position.RIGHT_IPSI, rightIpsi);
	}
}
