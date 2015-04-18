using UnityEngine;
using System.Collections;
using NUnit.Framework;


namespace SignLanguageSynthesisSystem
{
	[TestFixture]
	public class IKCalculatorTest
	{
		private IKCalculator ikCalculator;
		private Vector3 targetPostion;
		private const double TEST_EPSILON = 1e-6;

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
			Vector3d actualCenter;
			double actualRadius;
			Vector3d expectedCenter = new Vector3d (0.0828642411, 1.113685611, 0.1062544018);
			double expectedRadius = 0.1563913426;

			ikCalculator.ComputeElbowCircleCenter (targetPostion, out actualCenter, out actualRadius);

			AssertInRange (expectedCenter.x, actualCenter.x);
			AssertInRange (expectedCenter.y, actualCenter.y);
			AssertInRange (expectedCenter.z, actualCenter.z);

			AssertInRange (expectedRadius, actualRadius);
		}

		[Test]
		public void TestComputeElbowCircleAngles ()
		{
			Vector3d actualCenter;
			double actualRadius;
			double actualZenithAngle = 0;
			double actualAzimuthAngle = 0;
			const double expectedZenithAngle = 153.5004749;
			const double expectedAzimuthAngle = 46.8165359;

			ikCalculator.ComputeElbowCircleCenter (targetPostion, out actualCenter, out actualRadius);
			ikCalculator.ComputeElbowCircleAngles (targetPostion, out actualZenithAngle, out actualAzimuthAngle);

			AssertInRange (expectedZenithAngle, actualZenithAngle);
			AssertInRange (expectedAzimuthAngle, actualAzimuthAngle);
		}

		[Test]
		public void TestComputeElbowCircle ()
		{
			Vector3d actualCenterPosition = new Vector3d ();
			Vector3d actualCosineParas = new Vector3d ();
			Vector3d actualSineParas = new Vector3d ();
			Vector3d expectedCenterPosition = new Vector3d (0.0828642411, 1.113685611, 0.1062544018);
			Vector3d expectedCosineParas = new Vector3d (0.1140352749, -0.1070243343, 0);
			Vector3d expectedSineParas = new Vector3d (0.0957801501, 0.1020545077, 0.069780315);

			ikCalculator.ComputeElbowCircle (targetPostion, out actualCenterPosition, out actualCosineParas, out actualSineParas);

			AssertInRange (expectedCenterPosition.x, actualCenterPosition.x);
			AssertInRange (expectedCenterPosition.y, actualCenterPosition.y);
			AssertInRange (expectedCenterPosition.z, actualCenterPosition.z);

			AssertInRange (expectedCosineParas.x, actualCosineParas.x);
			AssertInRange (expectedCosineParas.y, actualCosineParas.y);
			AssertInRange (expectedCosineParas.z, actualCosineParas.z);

			AssertInRange (expectedSineParas.x, actualSineParas.x);
			AssertInRange (expectedSineParas.y, actualSineParas.y);
			AssertInRange (expectedSineParas.z, actualSineParas.z);
		}

		private void AssertInRange (double expected, double actual)
		{
			Assert.That (actual, Is.InRange (expected * (1.0 - TEST_EPSILON), expected * (1.0 + TEST_EPSILON)));
		}
	}
}
