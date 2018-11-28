using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class DataLoader : MonoBehaviour {

    public string[] items;
    public Text IdVar;
    public Text tempID;
    public Text tempFN;
    public Text tempLN;
    public Text Id;

    string IdComesHere;

    IEnumerator Start ()
    {
        WWW itemsData = new WWW("http://localhost/ItemsData.php");
        yield return itemsData;
        string itemsDataString = itemsData.text;
        print(itemsDataString);
        items = itemsDataString.Split(';');
        print(GetDataValue(items[0], "First Name:"));
    }

    string GetDataValue(string data, string index)
    {
        string value = data.Substring(data.IndexOf(index) + index.Length);
        if (value.Contains("|"))
        {
            value = value.Remove(value.IndexOf("|"));
        }
        return value;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            IdComesHere = Id.text;
            Debug.Log(IdComesHere + "idcomeshere");          
            //temp.text = (GetDataValue(items[0], "ID:"));
            for (int i = 0; i < items.Length; i++)
            {              
                tempID.text = (GetDataValue(items[i], "ID:"));
                tempFN.text = (GetDataValue(items[i], "First Name:"));
                tempLN.text = (GetDataValue(items[i], "Last Name:"));
                Debug.Log(tempID.text+ "temp ki id value");
                Debug.Log(Id.text + "idtext neeeechee");
                if (tempID.text != Id.text)
                {
                    IdVar.text = "null";
                    print("if me aya");
                }
                else
                {
                    IdVar.text = Id.text;
                    print("else me aya");
                    break;
                }
            }
        }
    }
}
