using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionReceiver : MonoBehaviour {

	private GameObject interObj;

	[SerializeField]
	private LayerMask interactionMask;

	[SerializeField]
	private PlayerBehaviour player;

	private bool interact;

	public bool Interact{
		set{ interact = value;}
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log(interObj);

		if(interact && interObj != null){
			interObj.gameObject.GetComponent<IInteractable<PlayerBehaviour, GameObject>>().ReceiveInteraction(player, gameObject);
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(Utils.CheckLayer(interactionMask, other.gameObject) && other.gameObject.GetComponent<IInteractable<PlayerBehaviour, GameObject>>() != null){
			interObj = other.gameObject;
		}
	}

	
	private void OnTriggerExit2D(Collider2D other) {
		if(Utils.CheckLayer(interactionMask, other.gameObject) && interObj == other.gameObject){
			interObj = null;
		}
	}
}
