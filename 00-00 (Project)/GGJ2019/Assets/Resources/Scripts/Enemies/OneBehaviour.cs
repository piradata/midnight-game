using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneBehaviour : MonoBehaviour {

	[SerializeField]
	private Animator anim;


	private Rigidbody2D rb;


	private PlayerBehaviour player;

	[SerializeField]
	private float speed;

	[SerializeField]
	private Vector2 dir;


	[SerializeField]
	private OneDetection downDetector;

	[SerializeField]
	private OneDetection topDetector;

	[SerializeField]
	private OneDetection leftDetector;

	[SerializeField]
	private OneDetection rightDetector;

	private bool moving = false;

	private bool collPlayer = false;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();

		player =GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerBehaviour>();

		moving = false;
		collPlayer = false;
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetFloat("X", dir.x);
		anim.SetFloat("Y", dir.y);

		if(!moving && !collPlayer){
			if(downDetector.Detected){
				moving = true;
				StartMove(downDetector.Direction);
			}else if(topDetector.Detected){
				moving = true;
				StartMove(topDetector.Direction);
			}else if(leftDetector.Detected){
				moving = true;
				StartMove(leftDetector.Direction);
			}else if(rightDetector.Detected){
				moving = true;
				StartMove(rightDetector.Direction);
			}
		}
	}

	private void StartMove(Vector2 _dir) {
		dir = _dir;
		rb.bodyType = RigidbodyType2D.Dynamic;
		rb.gravityScale = 0;
		rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
		rb.interpolation = RigidbodyInterpolation2D.Interpolate;

		rb.constraints = RigidbodyConstraints2D.FreezeRotation;

		rb.AddForce(_dir * speed, ForceMode2D.Force);

		rb.sharedMaterial = Utils.noFriction;
	}
	private void OnCollisionEnter2D(Collision2D other) {
		if(other.gameObject.tag == "Player"){
			collPlayer = true;
		}else{
			
			rb.position -= dir * 0.1f;
		}

			dir *= -1;

			rb.velocity = Vector2.zero;

			moving = false;

			rb.bodyType = RigidbodyType2D.Static;
		
	}

	private void OnCollisionExit2D(Collision2D other) {
		if(other.gameObject.tag == "Player"){
			collPlayer = false;
		}
	}
}
