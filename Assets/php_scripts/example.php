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

	//Make Connection
	$conn = new mysqli($servername, $server_username, $server_password, $dbName);
	//Check Connection
	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}
	
	$sql = "INSERT INTO example (FirstName, LastName,  Address,Height,  SymptomsNotes,) VALUES ('".$FirstName."', '".$LastName."', '".$Address."', '".$Height."', '".$Symptoms."', '".$Notes."')";
	$result = mysqli_query($conn ,$sql);
	
	if(!result) echo "there was an error";
	else echo "Everything ok.";

?>