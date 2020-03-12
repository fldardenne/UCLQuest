using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogManager : MonoBehaviour
{
	[SerializeField]
    private GameObject dialogCanvas;

	[SerializeField]
	private RawImage character_object;

	[SerializeField]
	private Text dialogText;

	private string[] dialogs;
	private int currentDialog;

	bool isActive;

	// Use this for initialization
	void Start () {
		this.isActive = true;

		// Event listener
		Button butt = dialogCanvas.GetComponent<Button>();
        butt.onClick.AddListener(nextText);
	}

	// Update is called once per frame
	void Update () {

		//uses p to display the dialog in debug
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(isActive) hide();
			else show();
		}
	}

	// Show the dialog
	public void show(){
		dialogCanvas.SetActive(true);
		this.isActive = true;
	}

	//hide the dialog
	public void hide(){
		dialogCanvas.SetActive(false);
		this.isActive = false;
	}

	// Set the dialog
	public void setDialogs(string[] dialogs){
		this.dialogs = dialogs;
		this.currentDialog = 0;
		dialogText.text = dialogs[currentDialog];

	}

	//Set the path, the image must be in Resources folder
	public void setImage(string path){
		Texture2D myTexture = Resources.Load(path) as Texture2D;
		character_object.texture = myTexture;
	}

	private void nextText(){
		if(dialogs.Length > currentDialog+1){
			dialogText.text = dialogs[++currentDialog];
		}else{
			hide();
		}
	}

}



