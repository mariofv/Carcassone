using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour 
{
	//
	// VARIABLES
	//
	
	public float turnSpeed = 4.0f;		// Speed of camera turning when mouse moves in along an axis
	public float panSpeed = 4.0f;		// Speed of the camera when being panned
	public float zoomSpeed = 4.0f;		// Speed of the camera going back and forth
	
	private Vector3 mouseOrigin;	// Position of cursor when mouse dragging starts
	private bool isPanning;		// Is the camera being panned?
	private bool isZooming;		// Is the camera zooming?
	
	//
	// UPDATE
	//
	
	void Update () 
	{
		
		// Get the right mouse button
		if(Input.GetMouseButtonDown(0))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isPanning = true;
		}
		
		// Get the middle mouse button
		if(Input.GetMouseButtonDown(2))
		{
			// Get mouse origin
			mouseOrigin = Input.mousePosition;
			isZooming = true;
		}
		
		// Disable movements on button release
		if (!Input.GetMouseButton(0)) isPanning=false;
		if (!Input.GetMouseButton(2)) isZooming=false;

		if (isPanning)
		{
	        	Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

	        	Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
	        	transform.Translate(move, Space.Self);
		}
		
		// Move the camera linearly along Z axis
		if (isZooming)
		{
	        	Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

	        	Vector3 move = pos.y * zoomSpeed * transform.forward; 
	        	transform.Translate(move, Space.World);
		}
	}
}
