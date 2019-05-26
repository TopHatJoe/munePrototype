using UnityEngine;


[RequireComponent(typeof (Rigidbody))]
public class PlayerController : MonoBehaviour 
{
	[SerializeField]
	private float speed = 5f;
	[SerializeField]
	private float mouseSesitivity = 3;

    private PlayerMotor motor;


	void Start ()
	{
		motor = gameObject.GetComponent <PlayerMotor> ();
	}

	void Update ()
	{
		//calculate movement velocity as a 3d vector
		float _xMov = Input.GetAxisRaw ("x");
		float _yMov = Input.GetAxisRaw ("y");
        float _zMov = Input.GetAxisRaw ("z");

		Vector3 _movHorizontal = transform.right * _xMov;
		Vector3 _movVertical = transform.forward * _yMov;
        Vector3 _movHitical = transform.up * _zMov;

		//final movement vector
		Vector3 _velocity = (_movHorizontal + _movVertical + _movHitical).normalized * speed;

		//apply movement
		motor.Move (_velocity);


		//calculate rotation as a 3D vector (pan)
		float _yRot = Input.GetAxisRaw ("Mouse X");

		Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * mouseSesitivity;

		//apply pan
		motor.Rotate (_rotation);


		//calculate camera rotation as a 3D vector 
		float _xRot = Input.GetAxisRaw ("Mouse Y");

		float _cameraRotationX = _xRot * mouseSesitivity; //new Vector3 (_xRot, 0f, 0f) * mouseSesitivity;

		//apply cameraRotation
		motor.RotateCamera (_cameraRotationX);
	}
}