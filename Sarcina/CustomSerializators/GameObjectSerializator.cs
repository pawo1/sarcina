using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Text.Json;
using System.Text.Json.Serialization;

using Sarcina.Objects;
using System.Numerics;

namespace Sarcina.CustomSerializators
{
    public class GameObjectSerializator : JsonConverter<GameObject>
    {
        enum TypeDiscriminator
        {
            Box = 1,
            Grass = 2,
            NamedBox = 3,
            Objective = 4,
            Player = 5,
            Portal = 6,
            Wall = 7
        }

        public override bool CanConvert(Type typeToConvert) => typeof(GameObject).IsAssignableFrom(typeToConvert);

        public override GameObject Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType != JsonTokenType.StartObject)
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            var propertyName = reader.GetString();
            if (propertyName != "TypeDiscriminator")
            {
                throw new JsonException();
            }

            reader.Read();
            if (reader.TokenType != JsonTokenType.Number)
            {
                throw new JsonException();
            }

            /*TypeDiscriminator typeDiscriminator = (TypeDiscriminator)reader.GetInt32();
           // reader.GetString();
            GameObject gameObject = typeDiscriminator switch
            {
                /*    TypeDiscriminator.Box => new Box(),
                    TypeDiscriminator.Grass => new Grass(),
                    TypeDiscriminator.NamedBox => new NamedBox(),
                    TypeDiscriminator.Objective => new Objective(),
                    TypeDiscriminator.Player => new Player(),
                    TypeDiscriminator.Portal => new Portal(),
                    TypeDiscriminator.Wall => new Wall(), 

                TypeDiscriminator.Box => JsonSerializer.Deserialize<Box>(ref reader)!,
                TypeDiscriminator.Grass => JsonSerializer.Deserialize<Grass>(ref reader)!,
                TypeDiscriminator.NamedBox => JsonSerializer.Deserialize<NamedBox>(ref reader)!,
                TypeDiscriminator.Objective => JsonSerializer.Deserialize<Objective>(ref reader)!,
                TypeDiscriminator.Player => JsonSerializer.Deserialize<Player>(ref reader)!,
                TypeDiscriminator.Portal => JsonSerializer.Deserialize<Portal>(ref reader)!,
                TypeDiscriminator.Wall => JsonSerializer.Deserialize<Wall>(ref reader)!,

                _ => throw new JsonException()
            };
            return gameObject; */

            GameObject gameObject;
            TypeDiscriminator typeDiscriminator = (TypeDiscriminator)reader.GetInt32();
            switch (typeDiscriminator)
            {
                case TypeDiscriminator.Box:
                    if (!reader.Read() || reader.GetString() != "TypeValue")
                    {
                        throw new JsonException();
                    }
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                    {
                        throw new JsonException();
                    }
                    gameObject = (Box)JsonSerializer.Deserialize(ref reader, typeof(Box));
                    break;

                case TypeDiscriminator.Grass:
                    if (!reader.Read() || reader.GetString() != "TypeValue")
                    {
                        throw new JsonException();
                    }
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                    {
                        throw new JsonException();
                    }
                    gameObject = (Grass)JsonSerializer.Deserialize(ref reader, typeof(Grass));
                    break;

                case TypeDiscriminator.NamedBox:
                    if (!reader.Read() || reader.GetString() != "TypeValue")
                    {
                        throw new JsonException();
                    }
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                    {
                        throw new JsonException();
                    }
                    gameObject = (NamedBox)JsonSerializer.Deserialize(ref reader, typeof(NamedBox));
                    break;

                case TypeDiscriminator.Objective:
                    if (!reader.Read() || reader.GetString() != "TypeValue")
                    {
                        throw new JsonException();
                    }
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                    {
                        throw new JsonException();
                    }
                    gameObject = (Objective)JsonSerializer.Deserialize(ref reader, typeof(Objective));
                    break;

                case TypeDiscriminator.Player:
                    if (!reader.Read() || reader.GetString() != "TypeValue")
                    {
                        throw new JsonException();
                    }
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                    {
                        throw new JsonException();
                    }
                    gameObject = (Player)JsonSerializer.Deserialize(ref reader, typeof(Player));
                    break;

                case TypeDiscriminator.Portal:
                    if (!reader.Read() || reader.GetString() != "TypeValue")
                    {
                        throw new JsonException();
                    }
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                    {
                        throw new JsonException();
                    }
                    gameObject = (Portal)JsonSerializer.Deserialize(ref reader, typeof(Portal));
                    break;

                case TypeDiscriminator.Wall:
                    if (!reader.Read() || reader.GetString() != "TypeValue")
                    {
                        throw new JsonException();
                    }
                    if (!reader.Read() || reader.TokenType != JsonTokenType.StartObject)
                    {
                        throw new JsonException();
                    }
                    gameObject = (Wall)JsonSerializer.Deserialize(ref reader, typeof(Wall));
                    break;

                default:
                    throw new NotSupportedException();
            }

            if (!reader.Read() || reader.TokenType != JsonTokenType.EndObject)
            {
                throw new JsonException();
            }

            return gameObject;


            /* while (reader.Read())
             {
                 if (reader.TokenType == JsonTokenType.EndObject)
                 {
                     return gameObject;
                 }

                 if (reader.TokenType == JsonTokenType.PropertyName)
                 {
                     propertyName = reader.GetString();
                     reader.Read();
                     switch (propertyName)
                     {
                         case "connectedPortal":
                             int x = reader.GetInt32();
                             int y = reader.GetInt32();
                             Vector2 connectedPortal = new Vector2(x, y);

                             ((Customer)person).CreditLimit = creditLimit;
                             break;
                         case "OfficeNumber":
                             string? officeNumber = reader.GetString();
                             ((Employee)person).OfficeNumber = officeNumber;
                             break;
                         case "Name":
                             string? name = reader.GetString();
                             person.Name = name;
                             break;
                     }
                 }
             } */

            throw new JsonException();
        }

        public override void Write(
            Utf8JsonWriter writer, GameObject gameObject, JsonSerializerOptions options)
        {
            writer.WriteStartObject();

            if (gameObject is Box box)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Box);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, box);
            }
            else if (gameObject is Grass grass)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Grass);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, grass);
            }
            else if (gameObject is Objective objective)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Objective);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, objective);
            }
            else if (gameObject is Player player)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Player);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, player);
            }
            else if (gameObject is Portal portal)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Portal);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, portal);
            }
            else if (gameObject is Wall wall)
            {
                writer.WriteNumber("TypeDiscriminator", (int)TypeDiscriminator.Wall);
                writer.WritePropertyName("TypeValue");
                JsonSerializer.Serialize(writer, wall);
            }
            else
            {
                throw new NotSupportedException();
            }

            writer.WriteEndObject();
        }
    }
}

 
