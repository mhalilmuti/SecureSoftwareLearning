# secure-software

This project includes safe and unsafe methods specified in OWASP top ten.

##For authentication:
####  Post Method
          http://ipAddress:port/token
          Content-Type: application/x-www-form-urlencoded
          userType: "customer" or "employee"
          Body parameters: username=myUsername&password=myPassword&grant_type=password
          Note: The parameter of grant_type should be assigned 'password' key word.
          
##Create Employee:
####  Post Method
          /api/Employee/Create
          Content-Type: application/json
          Body parameters: /Help/Api/POST-api-Employee-Create
          
##Get Employee:
####  Get Method Without Access Token
          api/Employee?id={Id}
          /Help/Api/GET-api-Employee_Id
