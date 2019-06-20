using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable<PlayerBehaviour, GameObject> {

	//[SerializeField]

	private bool open = false;

	private Animator anim;

	// Use this for initialization
	void Start () {
		open = false;
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		anim.SetBool("Open", open);
	}

	public void ReceiveInteraction(PlayerBehaviour player, GameObject space){
		open = player.HasKey;
	}
}
