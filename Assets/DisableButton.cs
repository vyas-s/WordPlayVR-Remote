using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisableButton : MonoBehaviour {

    public Button playButton;
    Image playImg;

    // Use this for initialization
    void Start () {
        playImg = gameObject.GetComponent<Image>();//.color = new Color32(255, 255, 225, 100);
        
    }
	
	// Update is called once per frame
	void Update () {
        if (playButton.IsInteractable())
        {
            playImg.color = new Color32(50, 218, 134, 255);
        }
        else
        {
            playImg.color = new Color32(155, 155, 155, 255);
        }
	}
}
