#pragma warning disable CS8618
namespace CommonLibrary.Classes
{
    public class TimeZoneContainer
    {
        public string Identifier { get; set; }
        public string DisplayName { get; set; }

        public string Item => $"{Identifier},{DisplayName}";

        public override string ToString() => DisplayName;

    }
}