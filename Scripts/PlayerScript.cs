using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	GameObject projectile;

	bool moving = true;	
	bool charging = false;

	Vector2 startLocation;
	Vector2 endLocation;
	// Use this for initialization
	void Start () {
	
	}



	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			RotateTowardsPointer(FakeTouchInput());
			charging = true;
		}

		if (Input.GetMouseButtonUp (0)) {
			float magnitude = Vector2.Distance(startLocation, FakeTouchInput());
			float angle = Vector2.Angle(startLocation, FakeTouchInput());
			Vector3 startPos = transform.position;
			startPos.x += 5;
			GameObject _projectile = Instantiate(projectile, startPos, Quaternion.identity) as GameObject;
			Vector3 angleVector = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
			_projectile.GetComponent<Rigidbody>().AddForce(angleVector*magnitude);
		}
	}

	void RotateTowardsPointer(Vector2 touchPosition)
	{
		gameObject.transform.Rotate (new Vector3 (0, 0, Mathf.Atan2 (touchPosition.y, touchPosition.x)*Mathf.Rad2Deg));

	}

	Vector2 FakeTouchInput()
	{
		Vector2 _vec = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
		return _vec;
	}
	
}
