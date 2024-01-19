using MeuDia.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MeuDia.Infra.Extensions
{
    public class ColorExtension
    {
        public class ColorJsonConverter : System.Text.Json.Serialization.JsonConverter<Color>
        {
            public override bool CanConvert(Type typeToConvert) =>
               typeof(Color).IsAssignableFrom(typeToConvert);

            public override Color Read(ref Utf8JsonReader reader,
              Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                    throw new System.Text.Json.JsonException();

                reader.Read();
                if (reader.TokenType != JsonTokenType.PropertyName)
                    throw new System.Text.Json.JsonException();
                string? propertyName = reader.GetString();
                if (propertyName != "Discriminator")
                    throw new System.Text.Json.JsonException();
                reader.Read();
                if (reader.TokenType != JsonTokenType.String)
                    throw new System.Text.Json.JsonException();
                var colorType = reader.GetString();
                Color color;
                switch (colorType)
                {
                    case "RGBColor":
                        color = new RGBColor();
                        color.Discriminator = colorType;
                        break;
                    case "HexColor":
                        color = new HexColor();
                        color.Discriminator = colorType;
                        break;
                    default:
                        throw new System.Text.Json.JsonException();
                };

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                        return color;
                    if (reader.TokenType == JsonTokenType.PropertyName)
                    {
                        propertyName = reader.GetString();
                        reader.Read();
                        switch (propertyName)
                        {
                            case "ColorId":
                                color.ColorId = reader.GetInt32();
                                break;
                            case "Discriminator":
                                color.Discriminator = reader.GetString();
                                break;
                            case "Red":
                                int red = reader.GetInt32();
                                if (color is RGBColor)
                                    ((RGBColor)color).red = red;
                                else
                                    throw new System.Text.Json.JsonException();
                                break;
                            case "Green":
                                int green = reader.GetInt32();
                                if (color is RGBColor)
                                    ((RGBColor)color).green = green;
                                else
                                    throw new System.Text.Json.JsonException();
                                break;
                            case "Blue":
                                int blue = reader.GetInt32();
                                if (color is RGBColor)
                                    ((RGBColor)color).blue = blue;
                                else
                                    throw new System.Text.Json.JsonException();
                                break;
                            case "HexValue":
                                string hexValue = reader.GetString();
                                if (color is HexColor)
                                    ((HexColor)color).hexValue = hexValue;
                                else
                                    throw new System.Text.Json.JsonException();
                                break;
                        }
                    };
                }
                throw new System.Text.Json.JsonException();
            }

            public override void Write(Utf8JsonWriter writer,
              Color color, JsonSerializerOptions options)
            {
                writer.WriteStartObject();
                writer.WriteString("Discriminator", color.Discriminator);
                writer.WriteNumber("ColorId", color.ColorId);
                if (color is RGBColor rgbColor)
                {
                    writer.WriteNumber("Red", rgbColor.red);
                    writer.WriteNumber("Green", rgbColor.green);
                    writer.WriteNumber("Blue", rgbColor.blue);

                }
                else if (color is HexColor hexColor)
                {
                    writer.WriteString("HexValue", hexColor.hexValue);
                }
                writer.WriteEndObject();
            }
        }
    }
}
