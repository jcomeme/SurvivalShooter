using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public Transform target;
	public float smoothing = 5f;
	Vector3 offset;
	// Use this for initialization
	void Start () {
		offset = this.transform.position - target.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 campos = target.transform.position + offset;
		this.transform.position = Vector3.Lerp (this.transform.position, campos, smoothing * Time.deltaTime);
	}
}
