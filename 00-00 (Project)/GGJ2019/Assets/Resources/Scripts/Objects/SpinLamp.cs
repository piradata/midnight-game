using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinLamp : MonoBehaviour, IInteractable<PlayerBehaviour, GameObject> {

	[SerializeField]
	private float rotation;


	[SerializeField]
	private float startRotation;


	[SerializeField]
	private GameObject head;

	// Use this for initialization
	void Start () {
		head.transform.Rotate(Vector3.forward * startRotation);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReceiveInteraction(PlayerBehaviour player, GameObject space){
		head.transform.Rotate(Vector3.forward * rotation);
	}
}
