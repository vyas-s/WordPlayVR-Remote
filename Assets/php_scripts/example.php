<?php
//Variables for the connection
	$servername = "localhost";
	$server_username =  "root";
	$server_password = "";
	$dbName = "labdatabase";
	
//Variable from the user	
	$FirstName = $_POST["FirstNamePost"];//"harmeet";
	$LastName = $_POST["LastNamePost"];//"singh";
	$Address = $_POST["AddressPost"];//"test";
	$Height = $_POST["HeightPost"];//"517";
	$Symptoms = $_POST["MedicalHistPost"];//"abc";
	$Notes = $_POST["PriorVisitsPost"];//"abcxyz";
	$DrugsPrescribed = $_POST["NotesPost"];//"qwerty";
	$MedicalHistory = $_POST["SymptomsPost"];//"asdfghjkl";
	$PriorVisits = $_POST["DrugsPost"];//"nu";
	$DoAndDont = $_POST["DoAndDntPost"];//"nu";

	//Make Connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//Check Connection
	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}
	
	$sql = "INSERT INTO example (FirstName, LastName, Address, Height, MedicalHistory, PriorVisits, Notes, Symptoms, DrugsPrescribed, DoAndDont) VALUES ('".$FirstName."', '".$LastName."', '".$Address."', '".$Height."', '".$MedicalHistory."', '".$PriorVisits."', '".$Notes."', '".$Symptoms."', '".$DrugsPrescribed."', '".$DoAndDont."')";
	$result = mysqli_query($conn ,$sql);
	
	if(!result) echo "there was an error";
	else echo "Everything ok.";

?>