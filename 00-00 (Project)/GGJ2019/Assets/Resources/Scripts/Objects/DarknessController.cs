using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarknessController : Activable {

	private SpriteRenderer rend;
	

	private Collider2D coll;
	
	public bool IsEnable(){
		return isActive;
	}

	// Use this for initialization
	void Awake () {
		rend = GetComponent<SpriteRenderer>();
		coll = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rend.enabled = isActive;
		coll.enabled = !isActive;
	}
}
