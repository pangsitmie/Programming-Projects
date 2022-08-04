<?php 
    session_start();
    $Hashedenglishname = $_GET["id"];
    
    $con = mysqli_connect('localhost','root','root','unityuser');//localhost e diganti acrual url of databse nanti

	//check that connection happen
	if(mysqli_connect_error())
	{
		echo "#1 connection failed";//error code number 1 = conenction fail
		exit();
    }
    
    $query = "SELECT * from users WHERE hash like '$Hashedenglishname'";

    $result = $con->query($query);

    // var_dump($result);
    // die();
    if($result){
        if(mysqli_num_rows($result)){
        $url = "http://localhost/";
        $row = mysqli_fetch_array($result);
        $_SESSION["mandarinName"] = $row["mandarin_name"];
        $_SESSION["englishName"] = $row["english_name"];
        $_SESSION["job"] = $row["job"];
        $_SESSION["phoneNumber"] = $row["phone_number"];
        $_SESSION["fixedNumber"] = $row["fixed_number"];
        $_SESSION["mobileNumber"] = $row["mobile_number"];
        $_SESSION["address"] = $row["address"];
        $_SESSION["email"] = $row["email"];
        header("location: http://localhost/sqlconnect/index.php");
        }else{
            dd("done");
        }
    }

    $con->close();

?>