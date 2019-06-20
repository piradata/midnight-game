using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTip : MonoBehaviour {

	private List<GameObject> interObjs;

	[SerializeField]
	private Animator anim;

	[SerializeField]
	private LayerMask interactionMask;

	[SerializeField]
	private GameObject balloonTip;

	private bool exitCtrl = true;

	private bool startCtrl = false;

	void OnEnable(){
		
	}


	// Use this for initialization
	void Start () {
		interObjs = new List<GameObject>();	
	}
	
	// Update is called once per frame
	void Update () {
		

		if(interObjs.Count > 0){
			if(!startCtrl){
				anim.SetTrigger("Start");
				exitCtrl = false;
				startCtrl = true;
			}
		}else if(!exitCtrl){
			anim.SetTrigger("Exit");
			exitCtrl = true;
			startCtrl = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D other) {
		if(!interObjs.Contains(other.gameObject) && Utils.CheckLayer(interactionMask, other.gameObject)){
			interObjs.Add(other.gameObject);
		}
	}

	
	private void OnTriggerExit2D(Collider2D other) {
		if(interObjs.Contains(other.gameObject) && Utils.CheckLayer(interactionMask, other.gameObject)){
			interObjs.Remove(other.gameObject);
		}
	}
}
