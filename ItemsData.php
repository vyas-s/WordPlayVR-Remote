<?php
	$servername = "localhost";
	$username =  "root";
	$password = "";
	$dbName = "labdatabase";
	
	//Make Connection
	$conn = new mysqli($servername, $username, $password, $dbName);
	//Check Connection
	if(!$conn){
		die("Connection Failed. ". mysqli_connect_error());
	}
	else{
		echo("Connection Successfull");
	}

	$sql = "SELECT ID, FirstName, LastName, Address, Height, Symptoms, Notes, DrugsPrescribed, MedicalHistory, PriorVisits, DoAndDont FROM EXAMPLE";
	$result = mysqli_query($conn ,$sql);
	
	
	if(mysqli_num_rows($result) > 0){
		//show data for each row
		while($row = mysqli_fetch_assoc($result)){
			echo "ID: ".$row['ID'] . 
			"|First Name: ".$row['FirstName']. 
			"|Last Name: ".$row['LastName']. 
			"|Address: ".$row['Address']. 
			"|Height: ".$row['Height'] . 
			"|Symptoms: ".$row['Symptoms'] . 
			"|Notes: ".$row['Notes'] . 
			"|DrugsPrescribed: ".$row['DrugsPrescribed'] . 
			"|MeicalHistory: ".$row['MedicalHistory'] . 
			"|PriorVisits: ".$row['PriorVisits']. 
			"|Do's And Dont's: ".$row['DoAndDont'] . 
			";";
		}
	}

?>