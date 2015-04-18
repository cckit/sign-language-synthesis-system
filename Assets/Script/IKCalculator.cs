using UnityEngine;
using System.Collections;

public class IKCalculator : AbstractIKCalculator
{
	public IKCalculator (Vector3 shoulder, Vector3 elbow, Vector3 wrist) : base(shoulder, elbow, wrist)
	{

	}

	public override Vector3 ComputeElbowCircleCenter (Vector3 targetPostion)
	{
		float distanceToTarget = Vector3.Distance (base.shoulder, targetPostion);
		float distanceToTargetSq = Mathf.Pow (distanceToTarget, 2);
		float armLengthSq = Mathf.Pow (base.armLength, 2);
		float foreArmLengthSq = Mathf.Pow (base.foreArmLength, 2);
		float z = (distanceToTargetSq + armLengthSq - foreArmLengthSq) / (2 * distanceToTarget);

		return Vector3.Lerp (base.shoulder, targetPostion, 1 - z);
	}

	public override void ComputeElbowCircleAngles (Vector3 targetPosition, out float zenithAngle, out float azimuthAngle)
	{
		throw new System.NotImplementedException ();
	}

	public override void ComputeElbowCircle (Vector3 targetPosition, out Vector3 center, out Vector3 cosineParas, out Vector3 sineParas)
	{
		throw new System.NotImplementedException ();
	}
}
