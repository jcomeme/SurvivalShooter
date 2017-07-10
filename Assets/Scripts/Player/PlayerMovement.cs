using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 6.0f;
	Vector3 movement;
	Animator anim;
	Rigidbody playerRigidbody;
	int floorMask;
	float camRayLength = 100.0f;

	void Awake(){
		floorMask = LayerMask.GetMask ("Floor");
		anim = GetComponent<Animator> ();
		playerRigidbody = GetComponent<Rigidbody> ();

	}

	void FixedUpdate(){
		float h = Input.GetAxisRaw ("Horizontal");
		float v = Input.GetAxisRaw ("Vertical");
		Move (h,v);
		Animating (h,v);
		Turning ();
	}


	void Move(float h, float v){
		movement.Set (h, 0.0f, v);
		movement = movement.normalized * speed * Time.deltaTime;
		playerRigidbody.MovePosition (playerRigidbody.position + movement);
	}

	void Turning(){
	
		Ray camRay = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit rayhit;

		if(Physics.Raycast(camRay,out rayhit ,camRayLength, floorMask))	{
			
			Vector3 rotateto = rayhit.point - transform.position;
			rotateto.y = 0.0f;
			Quaternion rotateQuatation = Quaternion.LookRotation (rotateto);
			playerRigidbody.MoveRotation (rotateQuatation);

		}
	}


	void Animating(float h, float v){
		/*
		if (h !=0 || v != 0){
			anim.SetBool("IsWalking", true);
		}else{
			anim.SetBool("IsWalking", false);
		}
		*/
		bool walking = h != 0f || v != 0f;

		// Tell the animator whether or not the player is walking.
		anim.SetBool ("IsWalking", walking);
	}
    
}
