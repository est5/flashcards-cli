using FlashCardsLib.Model;
using Npgsql;

namespace FlashCardsLib.Controller;

public class FlashcardController
{
    private NpgsqlConnection _dbContext;
    public FlashcardController(NpgsqlConnection dbContext)
    {
        _dbContext = dbContext;
    }

    public Flashcard GetFlashcardById(int id)
    {
        var card = new Flashcard("", "");
        using (_dbContext)
        {
            _dbContext.Open();

            var command = _dbContext.CreateCommand();
            command.CommandText = @"
            SELECT front,back FROM flashcard
            WHERE id = @id
            ";

            NpgsqlParameter param = new("@id", NpgsqlTypes.NpgsqlDbType.Integer);
            param.Value = id;
            command.Parameters.Add(param);

            command.Prepare();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                card.Front = (string)reader[0];
                card.Back = (string)reader[1];
            }
        }
        return card;
    }

    public void GetAllFlashcards() => throw new NotImplementedException();

    public void AddFlashcard(Flashcard flashcard) => throw new NotImplementedException();

    public void DeleteFlashcardById(int id) => throw new NotImplementedException();

    public void UpdateFlashcardByID(int id) => throw new NotImplementedException();

}
