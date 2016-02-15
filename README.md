# RESTAssignment2

	
Assignment 2

In this assignment, you will implement a similar Web API as in assignment 1, with the following requirements:

(20%) All API methods, plus the model classes used as their parameters and/or return values should be documented using XML documentation (Note: having the XML comments converted to actual help pages is not required, but of course highly recommended). The documentation should include a description of each class/method/property, and properties should include an example value.
(20%) There should be a separate class library (API.Services) which contains the business logic of the application.
(20%) The data should be stored in an SQL database, and all queries written using LINQ.
(20%) Each course should have a "Semester" string property (example: "20151" -> spring 2015, "20152" -> summer 2015, "20153" -> fall 2015). The method which returns a list of courses should accept an optional parameter, which allows us to query by a given semester. Example: /api/courses?semester=20151. If no semester is provided in the query (i.e. /api/courses), the current semester should be used - can be hardcoded as 20153. 
(20%) There should be a separate class library (API.Models) for all models used for input and output data in the API. No entity classes should be exposed outside of the API, i.e. there should be separate DTO/ViewModel classes used for return values and parameters to the Web API methods. 
Implementation details

You should add an entity class called CourseTemplate, with the following properties:

Name (Example: "Vefþjónustur"
CourseID (Example: "T-514-VEFT")
When adding a new course, it should be enough to specify the CourseID (Example: "T-111-PROG"), Semester, and Start/End dates. The business logic should figure out the name of the course, based of the name found in the course template. The method which adds a new course should accept an object which contains only the necessary properties for adding a course. I.e. it should NOT contain the name of the course, since the name is stored in the course template.

The method which returns details about a course should include as a sub-property a list of all the students in the course. However, the method which returns a list of all courses should NOT Include all students in each course, but it should include the number of students. When editing a course, only the course properties should be edited, and the object which that method accepts should NOT contain a list of students.

Seed data

The following students should be a part of the test data:

SSN    Name
"1234567890" "Jón Jónsson"
"9876543210" "Guðrún Jónsdóttir"
"6543219870" "Gunnar Sigurðsson"
"4567891230" "Jóna Halldórsdóttir"

Your test code should contain at least two course templates: "T-514-VEFT", and "T-111-PROG", with the names "Web services" and "Programming" respectively. 
There should be three course instances created as a part of the initial data:

ID CourseID Semester
1 "T-514-VEFT", 20143, 
2 "T-514-VEFT", 20153, 
3 "T-111-PROG" 20143.

Each course instance should have at least two students registered (each students may be registered to more than one course).

The following API calls should give the given result:

 /api/courses - GET
Should return a list containing exactly one element (see section about test data above)
/api/courses?semester=20143
Should return a list containing two elements: T-514-VEFT and T-111-PROG, both taught in fall 2014 (obviously)
/api/courses/1 - GET
Should return a more detailed object describing T-514-VEFT, taught in 20143 (see above in test data definition)
/api/courses/999- GET
Should return HTTP 404 (see test data)
/api/courses/1 - PUT
Should allow the client of the API to modify the given course instance. The properties which should be mutable are StartDate and EndDate, others (CourseID and Semester) should be immutable.
/api/courses/999 - PUT
Should return 404
/api/courses/1 - DELETE
Should remove the given course
/api/courses/999 - DELETE
Should return 404
/api/courses/1/students - GET
Should return a list of all students in T-514-VEFT in fall 2014
/api/courses/3/students - POST
Should add a new student to T-514-VEFT in 20153. It is assumed that the request body contains the 
