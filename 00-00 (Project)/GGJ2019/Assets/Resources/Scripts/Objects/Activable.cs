using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour {

	[SerializeField]
	protected bool isActive;

	public virtual bool IsActive{
		set{isActive = value;}
	}
}
