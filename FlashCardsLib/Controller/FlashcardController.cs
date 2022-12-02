using FlashCardsLib.DB;
using FlashCardsLib.Model;
using Npgsql;

namespace FlashCardsLib.Controller;

public class FlashcardController
{

    public Flashcard GetFlashcardById(int id)
    {
        var card = new Flashcard("", "");
        using (var _dbContext = new Postgres().GetDB())
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

    public List<Flashcard> GetAllFlashcards()
    {
        List<Flashcard> cards = new();
        using (var _dbContext = new Postgres().GetDB())
        {
            _dbContext.Open();

            var command = _dbContext.CreateCommand();
            command.CommandText = @"
            SELECT front,back FROM flashcard;
            ";

            command.Prepare();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var front = (string)reader[0];
                var back = (string)reader[1];
                var card = new Flashcard(front, back);
                cards.Add(card);
            }
        }
        return cards;
    }

    public void AddFlashcard(Flashcard flashcard) => throw new NotImplementedException();

    public void DeleteFlashcardById(int id) => throw new NotImplementedException();

    public void UpdateFlashcardByID(int id) => throw new NotImplementedException();

}
