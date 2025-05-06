using System.Collections.Concurrent;
using ArtifactApi.Models;
using Microsoft.AspNetCore.Components.Web;

namespace ArtifactApi.Services;

public class ArtifactService{
    private readonly ConcurrentDictionary<int, Artifact> _artifact = new();
    private int _nextId = 1; //id tracking

    public Artifact addArtifact(Artifact artifact){
        artifact.Id = _nextId++; 
        _artifact.TryAdd(artifact.Id, artifact);
        return artifact;
    }

    public bool deleteArtifact(int id) => _artifact.TryRemove(id, out _);

    public List<Artifact> GetAllArtifacts() => _artifact.Values.ToList();

    public Artifact? getArtifact(int id){
        if(_artifact.TryGetValue(id, out var artifact)){
            return artifact;
        }
        else
        return null;
    }

    public Artifact? editArtifact(int id ,Artifact newArtifact){
        if(_artifact.TryGetValue(id, out _)){
            newArtifact.Id = id;
            _artifact[id] = newArtifact;
            return newArtifact;
        }
        else
        {
            return null;
        }
    }
}
