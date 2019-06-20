using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

    [SerializeField]
    private bool isTrigger;

	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player" && !isTrigger){
			other.gameObject.GetComponent<PlayerBehaviour>().KillPlayer();
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(other.gameObject.tag == "Player" && isTrigger)
        {
			other.gameObject.GetComponent<PlayerBehaviour>().KillPlayer();
		}
	}
}
