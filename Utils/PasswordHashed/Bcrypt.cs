namespace CelsiaProject.Utils;

public class Bcrypt
{
    // Encriptar Contraseña
    public string HashPassword(string password)
    {
        // Implementar el algoritmo de encriptación de contraseñas (bcrypt)
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    // Validar Contraseña
    public bool VerifyPassword(string password, string hashedPassword)
    {
        // Implementar el algoritmo de verificación de contraseñas (bcrypt)
        return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
    }
}