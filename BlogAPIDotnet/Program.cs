using BlogAPIDotnet.Services.Configuration;

var builder = WebApplication.CreateBuilder(args); // creates a new WebApplication instance.
ServiceConfiguration.Configure(builder.Services, builder.Configuration); // configures services for the application.

var app = builder.Build(); // creates the application.

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers(); // maps the controllers.
app.UseHttpsRedirection(); // redirects HTTP requests to HTTPS.
app.UseAuthorization(); // adds authorization to the application.
app.UseAuthentication(); // adds authentication to the application.

app.Run(); // runs the application.