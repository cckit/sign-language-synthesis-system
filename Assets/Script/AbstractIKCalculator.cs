using UnityEngine;
using System.Collections;

public abstract class AbstractIKCalculator
{
	protected Vector3 shoulder;
	protected Vector3 elbow;
	protected Vector3 wrist;

	protected float armLength;
	protected float foreArmLength;

	public AbstractIKCalculator (Vector3 shoulder, Vector3 elbow, Vector3 wrist)
	{
		this.shoulder = shoulder;
		this.elbow = elbow;
		this.wrist = wrist;

		this.SetUp ();
	}

	private void SetUp ()
	{
		this.armLength = Vector3.Distance (this.shoulder, this.elbow);
		this.foreArmLength = Vector3.Distance (this.elbow, this.wrist);
	}

	public abstract Vector3 ComputeElbowCircleCenter (Vector3 targetPostion);

	public abstract void ComputeElbowCircleAngles (Vector3 targetPosition, out float zenithAngle, out float azimuthAngle);

	public abstract void ComputeElbowCircle (Vector3 targetPosition, out Vector3 centerPosition, out Vector3 cosineParas, out Vector3 sineParas);
}
