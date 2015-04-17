using UnityEngine;
using System.Collections;

public class IKCalculator : AbstractIKCalculator
{
	public IKCalculator (Vector3 shoulder, Vector3 elbow, Vector3 wrist) : base(shoulder, elbow, wrist)
	{

	}

	public override Vector3 ComputeElbowCircleCenter (Vector3 targetPostion)
	{
		throw new System.NotImplementedException ();
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
