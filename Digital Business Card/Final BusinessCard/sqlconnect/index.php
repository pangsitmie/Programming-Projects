<!DOCTYPE html>
<html lang="en">
  <head>
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css" integrity="sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm" crossorigin="anonymous">
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />



    <link href="floating-labels.css" rel="stylesheet">
    <title>Contact Info</title>
  </head>

  <?php 
    session_start();
    $url = "http://localhost/sqlconnect";
  ?>

  <body>
    <form class="form-signin">

      <div class="text-center mb-4">
        <img class="mb-4" src="https://getbootstrap.com/docs/4.0/assets/brand/bootstrap-solid.svg" alt="" width="72" height="72">
        <h1 class="h3 mb-3 font-weight-normal">Contact</h1>
        <p>hello this is my details</p>
      </div>

      <div class="text-center mb-4">
        
      <p><strong>Mandarin Name: <strong><?php echo $_SESSION["mandarinName"] ?><br/>
        <strong>English Name: <strong><?php echo $_SESSION["englishName"] ?><br/>
        <strong>Job: <strong><?php echo $_SESSION["job"] ?><br>
        
        <strong>Phone Number: <strong><?php echo $_SESSION["phoneNumber"] ?><br>
        <strong>Fixed Number: <strong><?php echo $_SESSION["fixedNumber"] ?><br>
        <strong>Mobile Number: <strong><?php echo $_SESSION["mobileNumber"] ?><br>
        
        <strong>Address: <strong><?php echo $_SESSION["address"] ?><br>
        <strong>Email: <strong><?php echo $_SESSION["email"] ?><br/>
      </p>

       <a class="btn btn-primary" href="<?php echo $url?>/createContact.php" role="button">Add to Contacts</a>
      </div>

      
      <p class="mt-5 mb-3 text-muted text-center">&copy; 2017-2018</p>
    </form>




















    
   

    <!-- The core Firebase JS SDK is always required and must be listed first -->
    <!-- TODO: Add SDKs for Firebase products that you want to use
      https://firebase.google.com/docs/web/setup#available-libraries -->
  </body>
</html>