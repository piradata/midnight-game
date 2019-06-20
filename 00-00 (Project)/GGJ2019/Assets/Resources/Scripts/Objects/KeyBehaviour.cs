using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBehaviour : MonoBehaviour {

    [SerializeField]
    private Image rendUI;

	// Use this for initialization
	void Start () {
		rendUI = GameObject.FindGameObjectWithTag("KeyUI").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player"){
			other.gameObject.GetComponent<PlayerBehaviour>().HasKey = true;

            rendUI.enabled = true;
			Destroy(gameObject);
		}
	}
}
