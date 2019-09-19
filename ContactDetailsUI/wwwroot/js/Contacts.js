

    var app = angular.module('MyForm', ['ui.bootstrap', 'ngResource']);
     app.controller('myCtrl', function ($scope, $http) {
         $scope.predicate = 'name';
        
    $scope.reverse = true;
         $scope.currentPage = 1;
         $scope.msg = "";
       $scope.order = function (predicate) {
        $scope.reverse = ($scope.predicate === predicate) ? !$scope.reverse : false;
    $scope.predicate = predicate;
         };


         $http({
             method: "GET",
             url: 'https://localhost:44320/api/contacts',
             headers: {
                 'Content-Type': 'application/json'
             }
         }).then(function mySuccess(response) {
             $scope.contacts = response.data;

             $scope.totalItems = $scope.contacts.length;
             $scope.numPerPage = 5;
             $scope.paginate = function (value) {
                 var begin, end, index;
                 begin = ($scope.currentPage - 1) * $scope.numPerPage;
                 end = begin + $scope.numPerPage;
                 index = $scope.contacts.indexOf(value);
                 return (begin <= index && index < end);
             };
         }, function myError(response) {
                 $scope.contacts = response.statusText;
             });


         $scope.getContactInfo = function (contactId) {
             $scope.msg = "";
             if (contactId > 0) {
                 $http({
                     method: "GET",
                     url: 'https://localhost:44320/api/contacts/' + contactId,
                     headers: {
                         'Content-Type': 'application/json'
                     }
                 }).then(function mySuccess(response) {
                     $scope.contactInfo = response.data;

                 }, function myError(response) {
                     $scope.msg = response.statusText;
                 });
             }
             else {
                 $scope.contactInfo = { contactId: 0, fname: '', lname: '', email: '', phone: '', gender: 'M', status: true };
             }
         }


         $scope.saveContact = function (contactId) {

             $http({
                 method: "POST",
                 url: 'https://localhost:44320/api/contacts',
                 data: $scope.contactInfo,
                 headers: {
                     'Content-Type': 'application/json'
                 }

             }).then(function mySuccess(response) {
                 if ($scope.contactInfo.contactId==0)
                     $scope.msg = "Contacts saved successfully";
                 else
                     $scope.msg = "Contacts updated successfully";
                 $('#exampleModalCenter').modal('toggle');
                 $http({
                     method: "GET",
                     url: 'https://localhost:44320/api/contacts',
                     headers: {
                         'Content-Type': 'application/json'
                     }
                 }).then(function mySuccess(response) {
                     $scope.contacts = response.data;

                     $scope.totalItems = $scope.contacts.length;
                     $scope.numPerPage = 5;
                     $scope.paginate = function (value) {
                         var begin, end, index;
                         begin = ($scope.currentPage - 1) * $scope.numPerPage;
                         end = begin + $scope.numPerPage;
                         index = $scope.contacts.indexOf(value);
                         return (begin <= index && index < end);
                     };
                 }, function myError(response) {
                     $scope.contacts = response.statusText;
                 });


             }, function myError(response) {
                     $scope.msg = response.statusText;
             });
         }

         $scope.deleteContactInfo = function (contactId) {
             
                 $http({
                     method: "DELETE",
                     url: 'https://localhost:44320/api/contacts',
                     data: contactId,
                     headers: {
                         'Content-Type': 'application/json'
                     }
                 }).then(function mySuccess(response) {
                     $scope.msg = "Contact Deleted sucess fully";


                     $http({
                         method: "GET",
                         url: 'https://localhost:44320/api/contacts',
                         headers: {
                             'Content-Type': 'application/json'
                         }
                     }).then(function mySuccess(response) {
                         $scope.contacts = response.data;

                         $scope.totalItems = $scope.contacts.length;
                         $scope.numPerPage = 5;
                         $scope.paginate = function (value) {
                             var begin, end, index;
                             begin = ($scope.currentPage - 1) * $scope.numPerPage;
                             end = begin + $scope.numPerPage;
                             index = $scope.contacts.indexOf(value);
                             return (begin <= index && index < end);
                         };
                     }, function myError(response) {
                         $scope.contacts = response.statusText;
                     });


                 }, function myError(response) {
                     $scope.msg = response.statusText;
                 });
             
           
         }


     });


