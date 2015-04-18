using UnityEngine;
using System.Collections;

public class IKCalculator : AbstractIKCalculator
{
	public IKCalculator (Vector3 shoulder, Vector3 elbow, Vector3 wrist) : base(shoulder, elbow, wrist)
	{

	}

	public override void ComputeElbowCircleCenter (Vector3 targetPostion, out Vector3d center, out double radius)
	{
		Vector3d targetPostionD = new Vector3d (targetPostion);
		double shoulderToTarget = Vector3d.Distance (base.shoulder, targetPostionD);
		double shoulderToTargetSq = Mathd.Pow (shoulderToTarget, 2);
		double armLengthSq = Mathd.Pow (base.armLength, 2);
		double foreArmLengthSq = Mathd.Pow (base.foreArmLength, 2);
		double shoulderToCircleCenter = (shoulderToTargetSq + armLengthSq - foreArmLengthSq) / (2.0 * shoulderToTarget);
		double shoulderToCircleCenterRatio = shoulderToCircleCenter / shoulderToTarget;

		center = Vector3d.Lerp (base.shoulder, targetPostionD, shoulderToCircleCenterRatio);
		radius = Mathd.Sqrt (armLengthSq - shoulderToCircleCenter * shoulderToCircleCenter);
	}

	public override void ComputeElbowCircleAngles (Vector3 targetPosition, out double zenithAngle, out double azimuthAngle)
	{
		Vector3d newDirection = -(new Vector3d (targetPosition) - base.shoulder).normalized;
		Vector3d projectedDirection = new Vector3d (newDirection.x, newDirection.y, 0).normalized;

		zenithAngle = Mathd.Acos (Vector3d.Dot (newDirection, Vector3d.forward)) * Mathd.Rad2Deg;
		zenithAngle = Mathd.Repeat (zenithAngle, 180.0);

		azimuthAngle = Mathd.Acos (Vector3d.Dot (projectedDirection, Vector3d.right)) * Mathd.Rad2Deg;
		azimuthAngle = Mathd.Repeat (azimuthAngle, 180.0);
	}

	public override void ComputeElbowCircle (Vector3 targetPosition, out Vector3d center, out Vector3d cosineParas, out Vector3d sineParas)
	{
		double radius;
		double zenithAngle;
		double azimuthAngle;
		this.ComputeElbowCircleCenter (targetPosition, out center, out radius);
		this.ComputeElbowCircleAngles (targetPosition, out zenithAngle, out azimuthAngle);

		zenithAngle *= Mathd.Deg2Rad;
		azimuthAngle *= Mathd.Deg2Rad;
		cosineParas = new Vector3d (Mathd.Sin (azimuthAngle), -Mathd.Cos (azimuthAngle)) * radius;
		sineParas = new Vector3d (-Mathd.Cos (zenithAngle) * Mathd.Cos (azimuthAngle), -Mathd.Cos (zenithAngle) * Mathd.Sin (azimuthAngle), Mathd.Sin (zenithAngle)) * radius;
	}
}
