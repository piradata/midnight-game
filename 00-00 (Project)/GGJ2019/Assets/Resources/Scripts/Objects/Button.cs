using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : Activator {

	[SerializeField]
	private LayerMask heavyLayer;


	private List<GameObject> heavyStuff;

	// Use this for initialization
	void Start () {
		heavyStuff = new List<GameObject>();
		
	}
	
	// Update is called once per frame
	protected override void Update () {
		base.Update();

        if (heavyStuff.Count > 0)
        {
            isActive = true;
        }
        else {
            isActive = false;
        }

		Debug.Log(heavyStuff.Count);
	}

	private void OnTriggerEnter2D(Collider2D other) {

		if(Utils.CheckLayer(heavyLayer, other.gameObject) && !heavyStuff.Contains(other.gameObject)){
			heavyStuff.Add(other.gameObject);
		}
	}

	private void OnTriggerStay2D(Collider2D other) {
		if(Utils.CheckLayer(heavyLayer, other.gameObject) && !heavyStuff.Contains(other.gameObject)){
			heavyStuff.Add(other.gameObject);
		}
	}

	private void OnTriggerExit2D(Collider2D other) {
		if(Utils.CheckLayer(heavyLayer, other.gameObject) && heavyStuff.Contains(other.gameObject)){
			heavyStuff.Remove(other.gameObject);
		}
	}
}
