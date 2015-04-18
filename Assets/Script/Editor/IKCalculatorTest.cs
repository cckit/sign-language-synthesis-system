﻿using UnityEngine;
using System.Collections;
using NUnit.Framework;


namespace SignLanguageSynthesisSystem
{
	[TestFixture]
	public class IKCalculatorTest
	{
		private IKCalculator ikCalculator;
		private Vector3 targetPostion;
		private const float TEST_EPSILON = 1e-3f;

		[SetUp]
		public void setUp ()
		{
			Vector3 shoulderPosition = new Vector3 (0.1408867f, 1.175509f, -0.06380438f);
			Vector3 elbowPosition = new Vector3 (0.3434902f, 1.036004f, -0.05624427f);
			Vector3 wristPosition = new Vector3 (0.457402f, 0.9503536f, 0.01992068f);

			targetPostion = new Vector3 (0.0704433f, 1.100451f, 0.1426591f);
			ikCalculator = new IKCalculator (shoulderPosition, elbowPosition, wristPosition);
		}

		[Test]
		public void TestComputeElbowCircleCenter ()
		{
			Vector3 actualResult = ikCalculator.ComputeElbowCircleCenter (targetPostion);
			Vector3 expectedResult = new Vector3 (0.0828642411f, 1.113685611f, 0.1062544018f);

			Assert.LessOrEqual (Mathf.Abs (expectedResult.x - actualResult.x), TEST_EPSILON);
			Assert.LessOrEqual (Mathf.Abs (expectedResult.y - actualResult.y), TEST_EPSILON);
			Assert.LessOrEqual (Mathf.Abs (expectedResult.z - actualResult.z), TEST_EPSILON);
		}

		[Test]
		public void TestComputeElbowCircleAngles ()
		{
			float actualZenithAngle = 0f;
			float actualAzimuthAngle = 0f;
			const float expectedZenithAngle = -26.4995251f;
			const float expectedAzimuthAngle = 46.8165359f;

			ikCalculator.ComputeElbowCircleCenter (targetPostion);
			ikCalculator.ComputeElbowCircleAngles (targetPostion, out actualZenithAngle, out actualAzimuthAngle);

			Assert.LessOrEqual (Mathf.Abs (expectedZenithAngle - actualZenithAngle), TEST_EPSILON);
			Assert.LessOrEqual (Mathf.Abs (expectedAzimuthAngle - actualAzimuthAngle), TEST_EPSILON);
		}

		[Test]
		public void TestComputeElbowCircle ()
		{
			Vector3 actualCenterPosition = new Vector3 ();
			Vector3 actualCosineParas = new Vector3 ();
			Vector3 actualSineParas = new Vector3 ();
			Vector3 expectedCenterPosition = new Vector3 (0.0828642411f, 1.113685611f, 0.1062544018f);
			Vector3 expectedCosineParas = new Vector3 (0.1140352749f, -0.1070243343f, 0f);
			Vector3 expectedSineParas = new Vector3 (0.0957801501f, 0.1020545077f, 0.069780315f);

			ikCalculator.ComputeElbowCircle (targetPostion, out actualCenterPosition, out actualCosineParas, out actualSineParas);

			Assert.LessOrEqual (Mathf.Abs (expectedCenterPosition.x - actualCenterPosition.x), TEST_EPSILON);
			Assert.LessOrEqual (Mathf.Abs (expectedCenterPosition.y - actualCenterPosition.y), TEST_EPSILON);
			Assert.LessOrEqual (Mathf.Abs (expectedCenterPosition.z - actualCenterPosition.z), TEST_EPSILON);

			Assert.LessOrEqual (Mathf.Abs (expectedCosineParas.x - actualCosineParas.x), TEST_EPSILON);
			Assert.LessOrEqual (Mathf.Abs (expectedCosineParas.y - actualCosineParas.y), TEST_EPSILON);
			Assert.LessOrEqual (Mathf.Abs (expectedCosineParas.z - actualCosineParas.z), TEST_EPSILON);

			Assert.LessOrEqual (Mathf.Abs (expectedSineParas.x - actualSineParas.x), TEST_EPSILON);
			Assert.LessOrEqual (Mathf.Abs (expectedSineParas.y - actualSineParas.y), TEST_EPSILON);
			Assert.LessOrEqual (Mathf.Abs (expectedSineParas.z - actualSineParas.z), TEST_EPSILON);
		}
	}
}
