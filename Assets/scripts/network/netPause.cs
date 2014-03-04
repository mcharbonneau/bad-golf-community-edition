﻿using UnityEngine;
using System.Collections;

public class netPause : MonoBehaviour {

	public GameObject ed_pauseScreen;

	PlayerInfo myInfo;

	private string nameOfLevel;	// needed?

	// Use this for initialization
	void Start () {
		// get variables we need
		myInfo = (GetComponent("networkVariables") as networkVariables).myInfo;
		ed_pauseScreen = Instantiate (Resources.Load ("pauseScreen")) as GameObject;
		ed_pauseScreen.transform.parent = this.transform;
		//Hide the screen while it is inactive
		hideAllScreens ();
	}
	
	// Update is called once per frame
	void Update () {
		// pause menu toggler
		if(Input.GetKeyDown(KeyCode.Escape)) {
			if(myInfo.playerIsPaused){				// if paused resume
				onResume();
			}else if(!myInfo.playerIsBusy){			// if not busy then pause
				onPause();
			}
		}
	}

	void hideAllScreens(){
		ed_pauseScreen.SetActive (false);
	}

	void onPause(){
		hideAllScreens ();
		ed_pauseScreen.SetActive (true);
		myInfo.playerIsPaused = true;
	}

	void onResume(){
		hideAllScreens ();
		myInfo.playerIsPaused = false;
	}

	void onExit(){
		myInfo.playerIsPaused = false;	//reset pause status
		Network.Disconnect ();
		hideAllScreens();
		Destroy (ed_pauseScreen);		//undo changes to object hierarchy
		
	}
}
