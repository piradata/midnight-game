using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour {

	[SerializeField]
	protected bool isActive;

	[SerializeField]
	Activable[] activables;

	public bool IsActive{
		get{return isActive;}
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	virtual protected void Update () {
		for(int i = 0; i < activables.Length; i++){
			activables[i].IsActive = isActive;
		}
	}
}
