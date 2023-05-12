using System.Text.RegularExpressions;
using ProjectManagement.Shared.Primitives.BaseEntity;

namespace Projects.Core.ValueObjects;

public class Email : ValueObject
{
    public static readonly Regex EmailTemplate = new Regex(
        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))"
            + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        RegexOptions.Compiled
    );

    public string Value { get; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Init(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentNullException(nameof(value));

        var updatedValue = value.ToLowerInvariant();

        if (!EmailTemplate.IsMatch(updatedValue))
            throw new ArgumentException("Email is not valid", nameof(value));

        return new Email(value);
    }

    public static implicit operator Email(string value) => value is null ? null : new Email(value);

    public static implicit operator string(Email value) => value.Value;

    public override string ToString() => $"Email: {Value}";

    public override IEnumerable<object> GetValues()
    {
        yield return Value;
    }
}
