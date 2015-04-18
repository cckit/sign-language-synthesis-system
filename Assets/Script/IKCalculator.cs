using UnityEngine;
using System.Collections;

public class IKCalculator : AbstractIKCalculator
{
	public IKCalculator (Vector3 shoulder, Vector3 elbow, Vector3 wrist) : base(shoulder, elbow, wrist)
	{

	}

	public override Vector3d ComputeElbowCircleCenter (Vector3 targetPostion)
	{
		Vector3d targetPostionD = new Vector3d (targetPostion);
		double distanceToTarget = Vector3d.Distance (base.shoulder, targetPostionD);
		double distanceToTargetSq = Mathd.Pow (distanceToTarget, 2);
		double armLengthSq = Mathd.Pow (base.armLength, 2);
		double foreArmLengthSq = Mathd.Pow (base.foreArmLength, 2);
		double z = (distanceToTargetSq + armLengthSq - foreArmLengthSq) / (2.0 * distanceToTarget);

		return Vector3d.Lerp (base.shoulder, targetPostionD, 1.0 - z);
	}

	public override void ComputeElbowCircleAngles (Vector3 targetPosition, out double zenithAngle, out double azimuthAngle)
	{
		throw new System.NotImplementedException ();
	}

	public override void ComputeElbowCircle (Vector3 targetPosition, out Vector3d center, out Vector3d cosineParas, out Vector3d sineParas)
	{
		throw new System.NotImplementedException ();
	}
}
