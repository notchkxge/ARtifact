using ArtifactApi.Models;
using ArtifactApi.Services;
using Microsoft.AspNetCore.Mvc;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ArtifactService>();

var app = builder.Build();



app.MapGet("/artifact", (ArtifactService services) => services.GetAllArtifacts());
app.MapPost("/artifact",(ArtifactService services, [FromBody] Artifact artifact) =>{
    if(string.IsNullOrEmpty(artifact.Title))
        return Results.BadRequest("Title is required");
    
    var createdArtifact = services.addArtifact(artifact);
    return Results.Created($"/artifact/{createdArtifact.Id}", createdArtifact);
});

app.MapDelete("/artifact/{id}",(int id,ArtifactService services)=>services.deleteArtifact(id));
app.MapGet("/artifact/{id}", (int id,ArtifactService services) => services.getArtifact(id));

app.MapPatch("/artifact/{id}",(int id,[FromBody] Artifact newArtifact,ArtifactService services) => services.editArtifact(id, newArtifact));

app.Run();

