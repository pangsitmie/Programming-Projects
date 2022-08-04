<?php
	
	$con = mysqli_connect('localhost','root','root','unityuser');//localhost e diganti acrual url of databse nanti

	//check that connection happen
	if(mysqli_connect_error())
	{
		echo "#1 connection failed";//error code number 1 = conenction fail
		exit();
	}

	//the post variable name must match with unity
	$mandarin_name = $_POST["mandarinName"];
	$english_name = $_POST["englishName"];
	$job = $_POST["job"];
	$phone_number = $_POST["phoneNumber"];
	$fixed_number = $_POST["fixedNumber"];
	$mobile_number = $_POST["mobileNumber"];
	$address = $_POST["address"];
	$email = $_POST["email"];




/*
	//check if name already exsist
	$nameCheckQuery = "SELECT english_name from users WHERE english_name='" .$englishName . "';";

	$nameCheck = mysqli_query($con, $nameCheckQuery) or die("#2: name check query fail");//error code #2 name check error

	if(mysqli_num_rows($nameCheck)>0)
	{
		echo "#3: name already exsist"//error code 3 name exsist cannot register
		exit();
	}
*/

	




	//add user to table

	//hashing for password not used in unity database

	$salt = "\$5\$rounds=1000\$" . "guid" . $english_name . "\$";

	$hash = crypt($english_name,$salt);//hash ini sama kek guid e seng disave di database
	echo $hash;
	


	$insertUserQuery = "INSERT INTO users (mandarin_name,english_name,job,phone_number,fixed_number, mobile_number,address,email,hash) VALUES 
						('" . $mandarin_name ."',
						'" . $english_name ."', 
						'" . $job ."',
						'" . $phone_number ."',
						'" . $fixed_number ."',
						'" . $mobile_number ."',
						'" . $address ."',
						'" . $email ."',
						'" . $hash ."');";

	mysqli_query($con, $insertUserQuery)or die("#4:inserting data query failed");//error code 4 insert query failed

	



?>