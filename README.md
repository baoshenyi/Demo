# Demo. Matt and Chris Please help me with code review 

## Instruction

- The demo code were implmented according to https://www.youtube.com/watch?v=3PyUjOmuFic
- The OAuth 2.0 authorization is set up in Azure AD.
- SecureAPI runs as a service side Authorized web api to return data
- SecureAPIClient runs as a client side to retrieve data


## Prerequist

- Visual Studio 2019 (v16.3 or later)
- .NET Core Runtime 3.0.3
- ASP.NET Core Runtime 3.0.3

## How to Run demo

- Load "SecureAPI.sln" solution in VS 2019
- Right click solution and set Multiple start projects->SecureAPI and SecureAPIClient

## Shenyi implementation

- Basic authorization implementation using Azure AD
- Thread safe, dependecy injection and exception handling implementation using SecureAPI\CacheService.cs and ICacheService.cs

