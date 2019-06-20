using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneDetection : MonoBehaviour {

	private bool detected;

	public bool Detected{
		get {return detected;}
	}

	[SerializeField]
	private Vector2 direction;

	public Vector2 Direction{
		get{return direction;}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			detected = true;
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(other.gameObject.tag == "Player"){
			detected = false;
		}
	}
}
