## About Evolent Health - Project exercise for Application Repository
Design and implement a production ready application for maintaining
contact information. Please choose the frameworks, packages and/or
technologies that best suit the requirements

## Contacts Information API
Represents the server portion of the application that exposes a WebApi for interacting with the application.

Minimum expected functionality:

    - List contacts
    - Add a contact
    - Edit contact
    - Delete/Inactivate a contact
    
Minimum Contact model fields:

    - First Name
    - Last Name
    - Email
    - Phone Number
    - Status (Possible values: Active/Inactive)

## Contact Information UI
Represents the client portion of the application that runs as a single-page-application (SPA) using the Angular 1.x framework.

![alt text](https://i.ibb.co/2ZpBkDM/Contact-Info.png)

## Contact Information Test Case
Represents the Xunit Test for contacts details


## Contact information API

This section contains information about contact-related resources as used within the contact information API.

 >| API | Verb | URL |
 >|:--: |:--:  |:--: |
 >|Get all contacts | GET | <https://{hostname}/api/contacts> |
 >|Get single contacts  | GET | <https://{hostname}/api/contacts/{contactsId}> | 
 >|Add  and edit contacts | POST  | <https://{hostname}/api/contacts> |
 >|Delete contacts | DELETE | <https://{hostname}/api/contacts/contactsId>  |
 
