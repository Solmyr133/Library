using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace library.Models;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public DateTime? PublishDate { get; set; }

    public int? AuthorId { get; set; }

    public int? CategoryId { get; set; }

    [JsonIgnore]
    public virtual Author? Author { get; set; }

    [JsonIgnore]
    public virtual Category? Category { get; set; }
}
