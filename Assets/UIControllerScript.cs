using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControllerScript : MonoBehaviour {

    public GameObject SettingsPanel;
    public GameObject StatsPanel;
	// Use this for initialization
	void Start () {
		
	}

    public void LoadStats()
    {
        Debug.Log("loadstats");
        SettingsPanel.SetActive(false);
        StatsPanel.SetActive(true);
    }
    public void LoadSettings() {
        Debug.Log("loadSettings");
        StatsPanel.SetActive(false);
        SettingsPanel.SetActive(true);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
