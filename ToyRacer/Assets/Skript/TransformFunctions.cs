using UnityEngine;
using System.Collections;

public class TransformFunctions : MonoBehaviour
{
	//car speeds
	public float topSpeed = 50f; // moveSpeed
	public float turnSpeed = 50f;

	//"imported" scripts
	public CheckIfHasFallen lyingScript;
	public CheckIfStanding standScript;

	//everything needed for the jump
	public float force = 0.0005F;
	private bool canJump;
	private Rigidbody self;

	// What is needed for Acceleration and Deacceleration
	private float currentSpeed;
	private float newSpeed;
	public float acclerationTime = 10.0f;
	private bool acceleratorPressed = false;
	private bool reverseAcceleratorPressed = false;

	private float accelerationRate;


	private bool inReverse;

	private void Start()
	{
		self = GetComponent<Rigidbody>();
		accelerationRate = (topSpeed / acclerationTime) * Time.deltaTime;
	}

	void FixedUpdate()
	{
		if (canJump)
		{
			canJump = false;
			self.AddForce(0, force, 0, ForceMode.Impulse);
		}
	}

	void Update()
	{
		// standing up controlls
		if (lyingScript.state == false && standScript.state == true && inReverse == false) // if car stands up and is not on laying down.
		{

			if (Input.GetKey(KeyCode.W))
			{
				//transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
				acceleratorPressed = true;
			}
			else
			{
				acceleratorPressed = false;
			} // Inbromsning och acceleration

			if (Input.GetKey(KeyCode.S))
			{
				//transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime); // comment this out if reverse behavior is incorrect
				reverseAcceleratorPressed = true;
			}
			else
			{
				reverseAcceleratorPressed = false;
			} // Inbromsning och deacceleration


			if (Input.GetKey(KeyCode.A))
			{
				transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
			}

			if (Input.GetKey(KeyCode.D))
			{
				transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
			}


			// -- Acceleration and deceleration --
			
			transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
			
			// forward is pressed

			if (acceleratorPressed && currentSpeed < topSpeed)
			{
				newSpeed = currentSpeed + accelerationRate;
				currentSpeed = newSpeed;
			}

			if (acceleratorPressed && currentSpeed >= topSpeed)
			{
				currentSpeed = topSpeed;
			}

			// reverse is pressed
			if (reverseAcceleratorPressed && currentSpeed > (topSpeed*-1)) // With negative top speed.
			{
				newSpeed = currentSpeed - accelerationRate;
				currentSpeed = newSpeed;
			}

			if (reverseAcceleratorPressed && currentSpeed <= (topSpeed*-1))
			{
				currentSpeed = (topSpeed*-1);
			}

            // Neither forward nor reverse is pressed.
            if ((!acceleratorPressed && !reverseAcceleratorPressed) && currentSpeed > 0f)
            {
                newSpeed = currentSpeed - accelerationRate;
                currentSpeed = newSpeed;
                if (currentSpeed <= 0f)
                    currentSpeed = 0f;
            }

            if ((!acceleratorPressed && !reverseAcceleratorPressed) && currentSpeed < 0f)
            {
                newSpeed = currentSpeed + accelerationRate;
                currentSpeed = newSpeed;
                if (currentSpeed >= 0f)
                    currentSpeed = 0f;
            }
        }

		//laying down controlls
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
			// transform.Translate(Vector3.forward * -currentSpeed * Time.deltaTime); // not sure why this is here but comment it back in if commenting out the other one
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


