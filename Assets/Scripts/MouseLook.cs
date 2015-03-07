	using UnityEngine;
using System.Collections;

//Rotates the camera based on the mouse.
public class MouseLook : MonoBehaviour {

	public const float LOOK_SENSITIVITY = 5;
	public const float LOOK_SMOOTHNESS = 0.1f;
	public const float CAMERA_ZOOM_SPEED = 0.1f;
	public const float CAMERA_DEFAULT = 20;
	private const float TARGET_CAMERA = 60;


	private float CurrentXRotation, CurrentYRotation;
	private float CurrentXRotationV, CurrentYRotationV;
	private float xRotation, yRotation, xRotationV, yRotationV;

	private float cameraZoom = 1;
	private float cameraZoomV;
	public bool colliding = false;

	public bool aimingTrue = false;

	void Update ()
	{
		//If the gun is up and right-click is pressed, aim the gun.
		if (transform.parent.GetComponent<CustomCharacter>().gunUp && Input.GetMouseButtonDown (1)) {
			aimingTrue = !aimingTrue;
		}

		SetAimingZoom ();

		RotationOnLook ();
	}

	//Set the scope zoom based on whether or not aiming is true.
	void SetAimingZoom() {
		if (aimingTrue) {
			cameraZoom = Mathf.SmoothDamp (cameraZoom, 1, ref cameraZoomV, CAMERA_ZOOM_SPEED);
		} else {
			cameraZoom = Mathf.SmoothDamp (cameraZoom, 0, ref cameraZoomV, CAMERA_ZOOM_SPEED);
		}

		camera.fieldOfView = Mathf.Lerp (TARGET_CAMERA, CAMERA_DEFAULT, cameraZoom);
	}

	//Rotate the camera when the mouse is moved around for looking.
	void RotationOnLook() {
		yRotation += Input.GetAxis ("Mouse X") * LOOK_SENSITIVITY;
		xRotation -= Input.GetAxis ("Mouse Y") * LOOK_SENSITIVITY;

		xRotation = Mathf.Clamp (xRotation, -80, 100);

		if (!colliding) {
			CurrentXRotation = Mathf.SmoothDamp (CurrentXRotation, xRotation, ref xRotationV, LOOK_SMOOTHNESS);
			CurrentYRotation = Mathf.SmoothDamp (CurrentYRotation, yRotation, ref yRotationV, LOOK_SMOOTHNESS);
		} else {
			CurrentXRotation = Mathf.SmoothDamp (CurrentXRotation, -xRotation, ref xRotationV, LOOK_SMOOTHNESS);
			CurrentYRotation = Mathf.SmoothDamp (CurrentYRotation, -yRotation, ref yRotationV, LOOK_SMOOTHNESS);
		}
		transform.parent.rotation = Quaternion.Euler (CurrentXRotation, CurrentYRotation, 0);
	}
}