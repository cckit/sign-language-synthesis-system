using UnityEngine;
using System.Collections;

public abstract class AbstractIKCalculator
{
	protected Vector3d shoulder;
	protected Vector3d elbow;
	protected Vector3d wrist;

	protected double armLength;
	protected double foreArmLength;

	public AbstractIKCalculator (Vector3 shoulder, Vector3 elbow, Vector3 wrist)
	{
		this.shoulder = new Vector3d (shoulder);
		this.elbow = new Vector3d (elbow);
		this.wrist = new Vector3d (wrist);

		this.SetUp ();
	}

	private void SetUp ()
	{
		this.armLength = Vector3d.Distance (this.shoulder, this.elbow);
		this.foreArmLength = Vector3d.Distance (this.elbow, this.wrist);
	}

	public abstract void ComputeElbowCircleCenter (Vector3 targetPostion, out Vector3d center, out double radius);

	public abstract void ComputeElbowCircleAngles (Vector3 targetPosition, out double zenithAngle, out double azimuthAngle);

	public abstract void ComputeElbowCircle (Vector3 targetPosition, out Vector3d centerPosition, out Vector3d cosineParas, out Vector3d sineParas);
}
