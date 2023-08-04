using System.ComponentModel.DataAnnotations.Schema;

namespace Discoteque.Data.Models;

public class Song : BaseEntity<int> {

    public string Name { get; set; } = "";

    public double Duration { get; set; }

    [ForeignKey("Id")]
    public int AlbumId { get; set; }

    public virtual Album? Album { get; set; }
    
}

