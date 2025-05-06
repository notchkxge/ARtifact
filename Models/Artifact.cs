namespace ArtifactApi.Models;

public class Artifact{
	public int Id{ get; set; }
    public string? Title{ get; set; }
    public string? Description{ get; set; }
    public string? ImageUrl{ get; set; }
    public string? ModelUrl{ get; set; } 
    public DateTime CreatedAt{ get; set; }
}