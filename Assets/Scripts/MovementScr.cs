using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScr : MonoBehaviour
{
    //[SerializeField]
    [SerializeField]
    private Rigidbody rb;
    [SerializeField]
    private float speed;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent <Rigidbody> ();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _vect = new Vector3 (Input.GetAxisRaw ("x"), Input.GetAxisRaw ("y"), Input.GetAxisRaw ("z"));
        rb.MovePosition (rb.position + _vect * Time.deltaTime * speed);
        
        /* 
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
        */
    }
}
