// The Using Directives
using Microsoft.EntityFrameworkCore; // For working with Entity framework core (Database framework)
using ToDoApp.Data; //Contain my ToDoContext class (Database Context)


//Variable Declaration. Initializes a builder for configuring the app - this set up web server, dependency injection and middleware
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(); //Register Controller Services so that my API EndPoint works
builder.Services.AddDbContext<ToDoContext>(opt => opt.UseInMemoryDatabase("ToDoList")); //Register my Entity Framework Core Context (ToDoContext) and tells it to use an in-memory database called (ToDoList) - data is stored in RAM, Ideal for testing and Demo
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();// For Generating Swagger User Interface for Configuring The API(POST,GEt,UPDATE)

var app = builder.Build(); //this Construct the App, putting together everything I have configured into a place (app). Includes all services (AddControllers and AddDbContext) and Middlewares (UseSwagger and UseAuthorization) 
//At this point, the application pipeline(sequences of event that happens) is built.

//Uing Swagger User Interface
app.UseSwagger();
app.UseSwaggerUI();//Enables the swagger UI where I can test my API

app.UseAuthorization();// For Configuring Authorization
app.MapControllers();//Maps HTTP routes to the controller methods (e.g., GET /api/todos maps to a method in a TodosController).

app.Run();//Starts the web server so your app begins accepting requests.
