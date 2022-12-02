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
            SELECT front,back,id FROM flashcard;
            ";

            command.Prepare();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var front = (string)reader[0];
                var back = (string)reader[1];
                var id = Convert.ToInt32(reader[2]);
                var card = new Flashcard(front, back);
                card.Id = id;
                cards.Add(card);
            }
        }
        return cards;
    }

    public void AddFlashcard(Flashcard flashcard)
    {
        using (var _dbContext = new Postgres().GetDB())
        {
            _dbContext.Open();

            var command = _dbContext.CreateCommand();
            command.CommandText = @"
            INSERT INTO flashcard(front,back)
            VALUES(
                @front, @back
            )
            ";

            NpgsqlParameter frontParam = new("@front", NpgsqlTypes.NpgsqlDbType.Varchar);
            frontParam.Value = flashcard.Front;
            command.Parameters.Add(frontParam);

            NpgsqlParameter backParam = new("@back", NpgsqlTypes.NpgsqlDbType.Text);
            backParam.Value = flashcard.Back;
            command.Parameters.Add(backParam);


            command.Prepare();
            command.ExecuteNonQuery();
        }
    }

    public void DeleteFlashcardById(int id)
    {
        using (var _dbContext = new Postgres().GetDB())
        {
            _dbContext.Open();

            var command = _dbContext.CreateCommand();
            command.CommandText = @"
            DELETE FROM flashcard
            WHERE id = @id
            ";

            NpgsqlParameter param = new("@id", NpgsqlTypes.NpgsqlDbType.Integer);
            param.Value = id;
            command.Parameters.Add(param);

            command.Prepare();
            command.ExecuteNonQuery();
        }
    }

    public void UpdateFlashcardByID(int id) => throw new NotImplementedException();

}
