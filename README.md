# Mike Wojcik Please help me with code review 
1. Proper utilization of Dependency Injection (done)
2. Code-first Entity Framework (Microsoft SQL Server) (done)
3. Encapsulating Business logic within models independent of the DB implementation. (done, may be done better using https://fluentvalidation.net/)
4. Composition & Inheritance (Bonus: Explain which is better and why?) (done and sent by email, not much comparison according to my underestanding)
5. Basic design patterns (done, like dependency injection)
6. Utilize AJAX to present an always up-to-date listing of vehicles on the track (no clue, real time update could be done by singalR according to my knowledge, prefer to get help from senior developer, like demo code or url)
7. Write unit tests to prove the following business requirements (done by 2 ways: memory in DB and Moq)

The following set of business requirements should help you demonstrate the above:
1. Present an always up-to-date listing of vehicles on the race track (Utilizing AJAX) (see above)
2. Present a single form to add vehicles to the race track. (Utilize a Type drop-down to determine which fields to show/hide, see inspections below) (related to 6)
3. A maximum of 5 vehicles can be on the race-track at any time. (done: see unit test)
4. Vehicles must pass an inspection prior to entering the track (done: see unit test)

Truck Inspections:
1. Tow strap on the vehicle (done: see unit test)
2. Not lifted more than 5 inches (done: see unit test)

Car Inspections:
1. Tow strap on the vehicle (done: see unit test)
2. Less than 85% tire wear (done: see unit test)

# Matt and Chris Please help me with code review 

## Instruction

- The demo code was implemented according to https://www.youtube.com/watch?v=3PyUjOmuFic
- The OAuth 2.0 authorization is set up in Azure AD.
- SecureAPI runs as a service side Authorized web api to return data
- SecureAPIClient runs as a client side to retrieve data


## Prerequisite

- Visual Studio 2019 (v16.3 or later)
- .NET Core Runtime 3.0.3
- ASP.NET Core Runtime 3.0.3

## How to Run demo

- Load "SecureAPI.sln" solution in VS 2019
- Right click solution and set Multiple start projects->SecureAPI and SecureAPIClient

## Shenyi implementation

- Basic authorization : use Azure AD
- Thread safe, dependency injection and exception handling : in SecureAPI\Service\CacheService.cs and ICacheService.cs
- Unit and functional test : use SecureAPITests project
- Factory pattern : in SecureAPI\Factory\WeatherForecastHelper.cs
- Extension method : in Extension\WeatherForecastExtension; demo it as var sports = weatherForecast.TakeSports(); in  WeatherForecastController.cs

## Result

- Retrived Token
eyJ0eXAiOiJKV1QiLCJhbGciOiJSUzI1NiIsIng1dCI6Imh1Tjk1SXZQZmVocTM0R3pCRFoxR1hHaXJuTSIsImtpZCI6Imh1Tjk1SXZQZmVocTM0R3pCRFoxR1hHaXJuTSJ9.eyJhdWQiOiJhcGk6Ly8xN2ExZjBhNS1hNTQwLTQ0MDYtOTcxNS04MmNkMzcwNjBjNzciLCJpc3MiOiJodHRwczovL3N0cy53aW5kb3dzLm5ldC9iMzA1NmJlMS0xNTIxLTRhNWYtOTIzNy05YTc4MTdiMjFkODQvIiwiaWF0IjoxNTk2NjAzMDQyLCJuYmYiOjE1OTY2MDMwNDIsImV4cCI6MTU5NjYwNjk0MiwiYWlvIjoiRTJCZ1lFZzI3NXR0VnYva21JS3B3bnJKemUyZkFRPT0iLCJhcHBpZCI6ImJkNjQ5YmU5LTkyNjEtNDdlZS1iM2Y4LTAyMzhhY2JiNTliZCIsImFwcGlkYWNyIjoiMSIsImlkcCI6Imh0dHBzOi8vc3RzLndpbmRvd3MubmV0L2IzMDU2YmUxLTE1MjEtNGE1Zi05MjM3LTlhNzgxN2IyMWQ4NC8iLCJvaWQiOiJlODFmMGVmMi00Yjc0LTQ2MzItYTgyMC1hNTEyN2M4OGZhNTciLCJyb2xlcyI6WyJEYWVtb25BcHBSb2xlIl0sInN1YiI6ImU4MWYwZWYyLTRiNzQtNDYzMi1hODIwLWE1MTI3Yzg4ZmE1NyIsInRpZCI6ImIzMDU2YmUxLTE1MjEtNGE1Zi05MjM3LTlhNzgxN2IyMWQ4NCIsInV0aSI6ImRKby1wcV9OWTB5MUpNUEdnUE1LQUEiLCJ2ZXIiOiIxLjAifQ.soawsduHk_rLlRsSHm4sc3utK9SoFakqVcbB46Azv7Zeq9Sjko7lKlxRNMW2mEMJd7YqV1--YV8OFWT_A-0J47CoZIF6fm4Bb9pt4p9sNFdvtCqFyOaopFiglDXvrDGKMEIorD7sRuY_OblFr4_Oz0PNk7udUMljy6HZFnlD8x_8Le4Z3ZsBw3G7Xbq9N2yGpW5CQuhftt0KNi3PRH3ySBi8Dmb4EaLxfRqrSagKu7vuxSPrrp2hAEKz3nNgX9ibGs4jf_FjfNDjeX4vXkKs36wwc5zIizSHS9IeRM6qwkd9VBsM55IVyOR1_XvW3swR-efeYeKjUlN6fmMAynkeUg

- Retrieved data
[{"date":"2020-08-05T22:55:42.7500952-06:00","temperatureC":26,"temperatureF":78,"summary":"Sweltering"},{"date":"2020-08-06T22:55:42.7503655-06:00","temperatureC":13,"temperatureF":55,"summary":"Warm"},{"date":"2020-08-07T22:55:42.7503702-06:00","temperatureC":4,"temperatureF":39,"summary":"Mild"},{"date":"2020-08-08T22:55:42.7503706-06:00","temperatureC":4,"temperatureF":39,"summary":"Balmy"},{"date":"2020-08-09T22:55:42.7503709-06:00","temperatureC":49,"temperatureF":120,"summary":"Warm"}]

## Note

- SecureAPIClient is used to show result purpose, which needs code refactoring if it is required.
- If you like to see more design patterns, please let me know by email or phone call. 
