namespace Showcase.MassTransit.DTOs
{
    internal record MessageDto
    {
        public MessageDto(string value)
        {
            Value = value;
        }

        public string Value { get; init; } = string.Empty;
    }
}