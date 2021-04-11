1. Open the Solution in Visual Studio
2. Build the project 
3. Navigate to tools ans select Nuget Package manager -> Package Manager Console (PMC)
4. On the console execute the following command
Update-Database -Context Student_Management_IdentityContext



5. On the console execute the following command

Update-Database -Context Student_Management_Data_Context



6. After migration is successful Run the project 

7 if you login as admin  from the following credentials will be able to see the Students,  
Course and Enrolments Links. Note only admin can create students and assign passwords thereafter students can update thier own details by login in with their credetials.

User : admin@students.com
Password: 1qaz2wsX@

8. Also you can login with the following credentials to visit the site as a Student
 will be only able to see that students  details . Also the student can edit their own details . Note if you are editing the password 
 please use the password similar to the default matching password eg: 1qaz2wsX@

 User : sam@students.com
Password: 1qaz2wsX@



9 if you need to create another course admin login with the admin credentials on step 7 above and
Click in "REGISTER Course Admin" register a new admin 

10 . The admin can view delete and edit the students enrolments and courses



The identity  authentication code used in the project were obtained by following URLS

Introduction to Identity on ASP.NET Core
https://docs.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-3.0&tabs=visual-studio
