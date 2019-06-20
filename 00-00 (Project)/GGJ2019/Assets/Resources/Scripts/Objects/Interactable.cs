using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInteractable <T1, T2> {

	// Use this for initialization
	void ReceiveInteraction (T1 player, T2 space);

	
}
