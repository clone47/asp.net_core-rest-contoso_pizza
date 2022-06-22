using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace ContosoPizza.Models;

public class Pizza
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string? MenuItem { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
    public string? Name { get; set; }

    public bool IsGlutenFree { get; set; }
}