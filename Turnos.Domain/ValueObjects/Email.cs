using System.Net.Mail;

namespace Turnos.Domain.ValueObjects;

public class Email
{
    public string Value { get; private set; }

    private Email(string value)
    {
        Value = value;
    }

    public static Email Create(string email)
    {
        if (string.IsNullOrWhiteSpace(email)) throw new ArgumentException("El email no puede estar vacio");

        if (!IsValid(email)) throw new ArgumentException("El formato del email es invalido");

        return new Email(email);
    }

    private static bool IsValid(string email)
    {
        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}