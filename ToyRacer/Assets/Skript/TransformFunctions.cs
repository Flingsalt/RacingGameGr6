using UnityEngine;
using System.Collections;

public class TransformFunctions : MonoBehaviour
{
	//car speeds
	public float moveSpeed = 10f;
	public float turnSpeed = 50f;

	//"imported" scripts
	public CheckIfHasFallen lyingScript;
	public CheckIfStanding standScript;

	//everything needed for the jump
	public float force = 0.0005F;
	private bool canJump;
	private Rigidbody self;

	private bool inReverse;

	private void Start()
	{
		self = GetComponent<Rigidbody>();
	}

	void FixedUpdate()
	{
		if (canJump)
		{
			canJump = false;
			self.AddForce(0, force, 0, ForceMode.Impulse);
		}
	}

	void Update ()
	{
		// stading up controlls
		if (lyingScript.state == false && standScript.state == true && inReverse == false) // if car stands up and is not on lying down.
		{

			if (Input.GetKey(KeyCode.W))
			{
				transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
			}

			if (Input.GetKey(KeyCode.A))
			{
				transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
			}

			if (Input.GetKey(KeyCode.D))
			{
				transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
			}
		}

		//lying down controlls
		else if (standScript.state == false || lyingScript.state == true) // checks if its either lies on the ground OR is not standing (it might be flying)
		{
			if (Input.GetKeyDown(KeyCode.A) && lyingScript.state == true) // makes it do a little jump
			{
				canJump = true;
			}
			if (Input.GetKey(KeyCode.A)) // gives the ability to rotate in the air
			{
				transform.Rotate(Vector3.forward, 100 * Time.deltaTime);
			}

			if (Input.GetKeyDown(KeyCode.D) && lyingScript.state == true)// makes it do a little jump
			{
				canJump = true;
			}
			if (Input.GetKey(KeyCode.D))// gives the ability to rotate in the air
			{
				transform.Rotate(Vector3.forward, -100 * Time.deltaTime);
			}
		}

		if (Input.GetKey(KeyCode.S))
		{
			transform.Translate(Vector3.forward * -moveSpeed * Time.deltaTime);
			inReverse = true;
		}
		else
		{
			inReverse = false;
		}
		if (inReverse == true) // if car stands up and is not on lying down.
		{

			if (Input.GetKey(KeyCode.A))
			{
				transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
			}

			if (Input.GetKey(KeyCode.D))
			{
				transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
			}
		}
	}
}

		
