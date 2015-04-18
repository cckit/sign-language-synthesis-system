using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMovement : MonoBehaviour
{

	private Positions pos;

	private Dictionary<Features.Position, GameObject> positionObjects;
	private float speed = 1.0f;

	public Transform rightHand;

	// Use this for initialization
	void Start ()
	{
		pos = new Positions (transform);
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
			positionObject.transform.position = Vector3.MoveTowards (positionObject.transform.position, target, step);
		}

		print (rightHand.position);
		print (pos.positions [Features.Position.RIGHT_IPSI]);
		rightHand.position = Vector3.MoveTowards (rightHand.position, pos.positions [Features.Position.RIGHT_IPSI], step);
	}
}
