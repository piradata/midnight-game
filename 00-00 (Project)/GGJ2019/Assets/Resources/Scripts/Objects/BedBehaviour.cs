using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BedBehaviour : MonoBehaviour, IInteractable<PlayerBehaviour, GameObject> {

	private DarknessController darkness;
	

	// Use this for initialization
	void Start () {

		darkness = GameObject.FindGameObjectWithTag("Darkness").GetComponent<DarknessController>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void ReceiveInteraction(PlayerBehaviour player, GameObject space){
		if(darkness.IsEnable()){

			Debug.Log("LEVEL ACABOU");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
	}
}
