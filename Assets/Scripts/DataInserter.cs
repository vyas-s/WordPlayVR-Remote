using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DataInserter : MonoBehaviour {
    public Text Fn;
    public Text Ln;
    public Text Address;
    public Text Height;
    public Text Mh;
    public Text Pv;
    public Text Notes;
    public Text Symp;
    public Text DrugsPres;
    public Text DoAndDont;

    string insertFirstName;
    string insertLastName;
	string insertAddress;
    string insertHeight;
    string insertMedicalHistory;
    string insertPriorVisits;
    string insertNotes;
    string insertSymptoms;
    string insertDrugsPrescribed;
    string insertDoAndDont;

    string CreateUserURL = "http://localhost/LabDatabase/dashboardapp/example.php";

	// Use this for initialization
	void Start () {
       	
	}
	
	// Update is called once per frame
	void Update () {

        insertFirstName = Fn.text;
        insertLastName = Ln.text;
        insertAddress = Address.text;
        insertHeight = Height.text;
        insertMedicalHistory = Mh.text;
        insertPriorVisits = Pv.text;
        insertNotes = Notes.text;
        insertSymptoms = Symp.text;
        insertDrugsPrescribed = DrugsPres.text;
        insertDoAndDont = DoAndDont.text;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CreateUser(insertFirstName, insertLastName, insertAddress, insertHeight, insertMedicalHistory, insertPriorVisits, insertNotes, insertSymptoms, insertDrugsPrescribed, insertDoAndDont);
        }
    }

	public void CreateUser(string FirstName, string LastName, string Address, string Height, string MedHis, string PriorVis, string Notes, string Symptoms, string DrugsPres, string DoAndDont){
		WWWForm form = new WWWForm();
		form.AddField("FirstNamePost", FirstName);
		form.AddField("LastNamePost", LastName);
		form.AddField("AddressPost", Address);
        form.AddField("HeightPost", Height);
        form.AddField("MedicalHistPost", MedHis);
        form.AddField("PriorVisitsPost", PriorVis);
        form.AddField("NotesPost", Notes);
        form.AddField("SymptomsPost", Symptoms);
        form.AddField("DrugsPost", DrugsPres);
        form.AddField("DoAndDntPost", DoAndDont);

        WWW www = new WWW(CreateUserURL, form);
	}
}
