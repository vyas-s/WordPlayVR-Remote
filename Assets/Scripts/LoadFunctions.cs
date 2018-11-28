using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadFunctions : MonoBehaviour {

    public GameObject Settings;
    public GameObject Details;
    public GameObject AddUser;

    public void SettingsFunc()
    {
        Settings.gameObject.SetActive(true);
        Details.gameObject.SetActive(false);
        AddUser.gameObject.SetActive(false);
    }
    public void DetailsFunc()
    {
        Settings.gameObject.SetActive(false);
        Details.gameObject.SetActive(true);
        AddUser.gameObject.SetActive(false);
    }
    public void AddUserFunc()
    {
        Settings.gameObject.SetActive(false);
        Details.gameObject.SetActive(false);
        AddUser.gameObject.SetActive(true);
    }
}
