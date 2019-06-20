using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBlock : MonoBehaviour, IInteractable<PlayerBehaviour, GameObject>{

	private Rigidbody2D rb;

	private Rigidbody2D rbTemp;

	private bool holded = false;

	private Rigidbody2D playerRb;

	private Vector2 distance;

	private Vector2 lastDir;

	void Awake(){
	}

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		rbTemp = rb;
		holded = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate(){
		
	}

	public void ReceiveInteraction(PlayerBehaviour player, GameObject space){
		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.gravityScale = 0;
		rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		rb.interpolation = RigidbodyInterpolation2D.Interpolate;

		rb.AddForce(player.GetDirection() * 500, ForceMode2D.Force);

		lastDir = player.GetDirection();
	}

	private void OnCollisionEnter2D(Collision2D other) {
		/*if(other.gameObject.GetComponent<Rigidbody2D>() != null){
			if(other.gameObject.GetComponent<Rigidbody2D>().bodyType == RigidbodyType2D.Dynamic){

			}
		}*/

		rb.position -= lastDir * 0.1f;

		rb.velocity = Vector2.zero;

		//rb.bodyType = RigidbodyType2D.Static;
	}
}
