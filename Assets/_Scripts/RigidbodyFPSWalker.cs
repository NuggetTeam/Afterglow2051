using UnityEngine;
using System.Collections;
 
[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (CapsuleCollider))]
 
public class RigidbodyFPSWalker : MonoBehaviour {
 
	public float speed = 10.0f;
	public float gravity = 10.0f;
	public float maxVelocityChange = 10.0f;

	public bool active = true;
	
	void Awake () {
	    GetComponent<Rigidbody>().freezeRotation = true;
	    GetComponent<Rigidbody>().useGravity = false;
	}
 
	void FixedUpdate () {
	    
		if(active){
		
	        // Calculate how fast we should be moving
	        Vector3 targetVelocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
	        targetVelocity = transform.TransformDirection(targetVelocity);
	        targetVelocity *= speed;
 
	        // Apply a force that attempts to reach our target velocity
	        Vector3 velocity = GetComponent<Rigidbody>().velocity;
	        Vector3 velocityChange = (targetVelocity - velocity);
	        velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
	        velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
	        velocityChange.y = 0;
	        GetComponent<Rigidbody>().AddForce(velocityChange, ForceMode.VelocityChange);
		
		}
		else{transform.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;}
		
		
	}
	
	public void SetActive(bool ac){
		
		active = ac;
		
	}


 
}