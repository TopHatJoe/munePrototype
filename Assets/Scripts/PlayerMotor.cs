using UnityEngine;

[RequireComponent(typeof (PlayerMotor))]
public class PlayerMotor : MonoBehaviour 
{
	private Vector3 velocity = Vector3.zero;
	private Vector3 rotation = Vector3.zero;
	private float cameraRotationX = 0f;
	private float currentCameraRotationX = 0f;
    
	[SerializeField]
	private float cameraRotationLimit = 85f;

	[SerializeField]
	private Camera cam;
	private Rigidbody rb;

	void Start ()
	{
		rb = GetComponent <Rigidbody> ();
	}

	//get movement vector
	public void Move (Vector3 _velocity)
	{
		velocity = _velocity;
	}

	//get rotational vector
	public void Rotate (Vector3 _rotation)
	{
		rotation = _rotation;
	}

	//get rotational vector for camera
	public void RotateCamera (float _cameraRotationX)
	{
		cameraRotationX = _cameraRotationX;
	}


	void FixedUpdate ()
	{
		PerformMovement ();
		PerformRotation ();
	}

	//perform movement
	private void PerformMovement ()
	{
		if (velocity != Vector3.zero) 
		{
			rb.MovePosition (rb.position + velocity * Time.fixedDeltaTime);
		}
	}

	//perform rotation
	private void PerformRotation ()
	{
		rb.MoveRotation (rb.rotation * Quaternion.Euler (rotation));

		if (cam != null) {
			//sets and clamps rotation
			currentCameraRotationX -= cameraRotationX;
			currentCameraRotationX = Mathf.Clamp (currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit);

			//applies rotation to transform of cam
			cam.transform.transform.localEulerAngles = new Vector3 (currentCameraRotationX, 0f, 0f);

			//cam.transform.Rotate (-cameraRotation);
		}
	}
}