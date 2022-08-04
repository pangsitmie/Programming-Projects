<?php
    session_start();
    require 'vendor/autoload.php';
    use JeroenDesloovere\VCard\VCard;;
    // define vcard
    $vcard = new VCard();
    
    // define variables
    $lastname = $_SESSION["mandarinName"];
    $firstname = $_SESSION["englishName"];
    $additional = '';
    $prefix = '';
    $suffix = '';
    
    // add personal data
    $vcard->addName($lastname, $firstname, $additional, $prefix, $suffix);
    
    // add work data
    $vcard->addJobtitle($_SESSION["job"]);
    $vcard->addEmail($_SESSION["email"]);
    $vcard->addPhoneNumber($_SESSION["phoneNumber"], 'Phone Number');
    $vcard->addPhoneNumber($_SESSION["fixedNumber"], 'Fixed Number');
    $vcard->addPhoneNumber($_SESSION["mobileNumber"], 'Mobile Number');
    $vcard->addAddress(null, null,$_SESSION["address"],null, null,null,null);
    
    // return vcard as a string
    //return $vcard->getOutput();
    
    // return vcard as a download
    return $vcard->download();
    
    // save vcard on disk
    // $vcard->setSavePath('./');
    // $vcard->save();
?>