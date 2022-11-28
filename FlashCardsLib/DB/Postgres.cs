using Npgsql;

namespace FlashCardsLib.DB;

public class Postgres
{

    private static string _CONN = "Host=localhost:5432;Username=postgres;Password=flashcards;Database=postgres";

    public NpgsqlConnection GetDB()
    {
        var conn = new NpgsqlConnection(_CONN);
        return conn;
    }
}
