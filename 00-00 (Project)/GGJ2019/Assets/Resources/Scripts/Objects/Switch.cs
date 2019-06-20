using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : Activator, IInteractable<PlayerBehaviour, GameObject> {

	[SerializeField]
	private bool justOnce;

	private bool firstPress = true;

	// Use this for initialization
	void Start () {
		firstPress = true;
	}
	
	// Update is called once per frame
	override protected void Update () {
		base.Update();
		//Debug.Log(isActive);
	}

	public void ReceiveInteraction(PlayerBehaviour player, GameObject space){
		if((justOnce && firstPress) || !justOnce){
			isActive = !isActive;
			firstPress = false;
		}
	}
}
