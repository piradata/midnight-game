using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCorrection : MonoBehaviour {


    [SerializeField]
    private SpriteRenderer sprite;

    [SerializeField]
    private int value;

	// Use this for initialization
	void Start () {     
	}
	
	// Update is called once per frame
	void Update () {


        #region Position on Layer

        //sprite.sortingOrder = 10000 - (int)(transform.position.y * 100);
        sprite.sortingOrder = - (int)(transform.position.y * 100) + value;

        #endregion

		
	}
}
