using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxBlock : MonoBehaviour, IInteractable<PlayerBehaviour, GameObject>{

	private Rigidbody2D rb;

	private Rigidbody2D rbTemp;

	private bool holded = false;

	private Rigidbody2D playerRb;

	private Vector2 distance;

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
		if(holded){
			//rb.
			//rb.MovePosition((Vector2)playerRb.position + distance);


		}
	}

	public void ReceiveInteraction(PlayerBehaviour player, GameObject space){
		if(holded == false){
			holded = true;

			Destroy(rb);

			transform.SetParent(player.gameObject.transform);

			player.LockAxis();
			player.LoockLookDirection();

			//rb.simulated = false;

			/*playerRb = player.GetComponent<Rigidbody2D>();

			distance = rb.position - playerRb.position;

			Debug.Log(distance);*/

			//rb.transform.position = space.transform.position;
			//Debug.Log(name);

			//Destroy(gameObject);
		}else{
			gameObject.AddComponent(typeof(Rigidbody2D));

			rb = GetComponent<Rigidbody2D>();

			rb.bodyType = RigidbodyType2D.Static;

			transform.SetParent(null);

			player.FreeAxis();
			player.FreeLookDirection();

			holded = false;
		}
	}
}
