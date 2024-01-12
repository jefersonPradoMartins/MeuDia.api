
using System.Text.Json.Serialization;

namespace MeuDia.Domain.Entities
{
    // Classe base
    public abstract class Color
    {
        public int ColorId { get; set; }
        [JsonPropertyOrder(-1)]
        public string Discriminator { get; set; }
        [JsonIgnore]
        public IList<Tag>? Tags { get; set; }
        public abstract string Display();
    }

    // Implementação para RGB
    public class RGBColor : Color
    {
        public int red { get; set; }
        public int green { get; set; }
        public int blue { get; set; }

        //  [JsonConstructor]
        public RGBColor() { }

        public override string Display()
        {
            return $"RGB({red}, {green}, {blue})";
        }

        // Builder para RGBColor
        public class RGBColorBuilder
        {
            private RGBColor color;

            public RGBColorBuilder()
            {
                color = new RGBColor();
            }
            public RGBColorBuilder SetRed(int red)
            {
                color.red = red;
                return this;
            }
            public RGBColorBuilder SetGreen(int green)
            {
                color.green = green;
                return this;
            }
            public RGBColorBuilder SetBlue(int blue)
            {
                color.blue = blue;
                return this;
            }
            private RGBColor Build()
            {
                return color;
            }
            public static implicit operator RGBColor(RGBColorBuilder builder)
            {
                return builder.Build();
            }
        }
    }

    // Implementação para HEX
    public class HexColor : Color
    {
        public string hexValue { get; set; }
        public HexColor() { }
        public override string Display()
        {
            return $"HEX({hexValue})";
        }
        // Builder para HexColor
        public class HexColorBuilder
        {
            private HexColor color;

            public HexColorBuilder()
            {
                color = new HexColor();
            }
            public HexColorBuilder SetHexValue(string hexValue)
            {
                color.hexValue = hexValue;
                return this;
            }
            private HexColor Build()
            {
                return color;
            }
            public static implicit operator HexColor(HexColorBuilder builder)
            {
                return builder.Build();
            }
        }
    }
}


