using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
    GameObject[] dialogsObjects;
	bool isActive;

	// Use this for initialization
	void Start () {
		dialogsObjects = GameObject.FindGameObjectsWithTag("dialog");
		hide();
		this.isActive = false;
	}

	// Update is called once per frame
	void Update () {

		//uses the p button to pause and unpause the game
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(isActive) hide();
			else show();
		}
	}

	//shows objects with ShowOnPause tag
	public void show(){
		foreach(GameObject g in dialogsObjects){
			g.SetActive(true);
			this.isActive = true;
		}
	}

	//hides objects with ShowOnPause tag
	public void hide(){
		foreach(GameObject g in dialogsObjects){
			g.SetActive(false);
			this.isActive = false;
		}
	}
}



