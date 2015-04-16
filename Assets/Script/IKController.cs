using UnityEngine;
using System.Collections;

public class IKController
{
	private Transform hand;
	private Transform elbow;
	private Transform arm;

	private float armLengthSq;
	private float foreArmLengthSq;
	private float elbowZ;

	public IKController (Transform hand, Transform elbow, Transform arm)
	{
		this.hand = hand;
		this.elbow = elbow;
		this.arm = arm;

		this.armLengthSq = Mathf.Pow (Vector3.Distance (arm.transform.position, elbow.transform.position), 2);
		this.foreArmLengthSq = Mathf.Pow (Vector3.Distance (elbow.transform.position, hand.transform.position), 2);
	}

	public void Update (Vector3 target)
	{

		this.hand.position = Vector3.MoveTowards (hand.position, target, 1.0f);
	}
}
