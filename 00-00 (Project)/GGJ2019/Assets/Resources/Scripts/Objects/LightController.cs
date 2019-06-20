using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightController : Activable {

	private SpriteMask rend;
	

	private Collider2D coll;

	// Use this for initialization
	void Awake () {
		rend = GetComponent<SpriteMask>();
		coll = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rend.enabled = isActive;
		coll.enabled = isActive;
	}
}
