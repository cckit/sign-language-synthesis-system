using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour
{
	public float rightShoulderAngle;
	public float rightArmAngle;
	public float rightElbowAngle;
	private Positions pos;
	private IIKController rightIKController;

	private Dictionary<Features.Position, GameObject> positionObjects;
	private float speed = 1.0f;

	public Transform rightHand;

	// Use this for initialization
	void Start ()
	{
		pos = new Positions (transform);
		rightIKController = new IKController (pos.rightHand, pos.rightForeArm, pos.rightArm);

		positionObjects = new Dictionary<Features.Position, GameObject> ();
		
		foreach (Features.Position position in pos.positions.Keys) {
			GameObject go = GameObject.CreatePrimitive (PrimitiveType.Sphere);
			go.transform.position = new Vector3 (0, 0, 1);
			go.transform.localScale = new Vector3 (0.1f, 0.1f, 0.1f);
			positionObjects.Add (position, go);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		float step = speed * Time.deltaTime;
		foreach (Features.Position position in pos.positions.Keys) {
			Vector3 target = pos.positions [position];
			GameObject positionObject = positionObjects [position];
			positionObject.transform.position = target;
		}

		Vector3 targetPosition = pos.positions [Features.Position.RIGHT_IPSI];
		Quaternion targetRotation = Quaternion.LookRotation (Vector3.forward);
		rightIKController.Update (targetPosition, targetRotation);
	}
}
