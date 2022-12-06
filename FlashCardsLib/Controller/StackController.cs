using FlashCardsLib.DB;
using FlashCardsLib.Model;
using Npgsql;

namespace FlashCardsLib.Controller;

public class StackController
{
    public StackWithCards GetStackById(int stackId)
    {
        StackWithCards stack = new();
        stack.Id = stackId;
        using (var con = new Postgres().GetDB())
        {
            con.Open();

            var command = con.CreateCommand();
            command.CommandText = @"
            SELECT title, front, back, card.id FROM stack as s
            LEFT JOIN flashcards as fl on  s.id = fl.stack_id
            LEFT JOIN flashcard as card on fl.flashcard_id = card.id
            WHERE s.id = @id
            ";

            NpgsqlParameter param = new("@id", NpgsqlTypes.NpgsqlDbType.Integer);
            param.Value = stackId;
            command.Parameters.Add(param);

            command.Prepare();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                stack.Title = (string)reader[0];
                var card = new Flashcard((string)reader[1], (string)reader[2]);
                card.Id = Convert.ToInt32(reader[3]);
                stack.Cards.Add(card);
            }
        }
        return stack;
    }

    public List<Stack> GetAllStacks()
    {
        List<Stack> stacks = new();
        using (var con = new Postgres().GetDB())
        {
            con.Open();

            var command = con.CreateCommand();
            command.CommandText = @"
            SELECT id,title FROM stack;
            ";

            command.Prepare();
            var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var stack = new Stack("");
                int id = Convert.ToInt32(reader[0]);
                string title = (string)reader[1];
                stack.Title = title;
                stack.Id = id;

                stacks.Add(stack);
            }
        }
        return stacks;
    }

    public void AddFlashcardToStackById(int cardId, int stackId)
    {
        try
        {
            using (var con = new Postgres().GetDB())
            {
                con.Open();

                var command = con.CreateCommand();
                command.CommandText = @"
                INSERT INTO flashcards (stack_id, flashcard_id)
                VALUES(
                    @stack_id, @flashcard_id
                )
                ";

                NpgsqlParameter stackParam = new("@stack_id", NpgsqlTypes.NpgsqlDbType.Integer);
                stackParam.Value = stackId;
                command.Parameters.Add(stackParam);


                NpgsqlParameter cardParam = new("@flashcard_id", NpgsqlTypes.NpgsqlDbType.Integer);
                cardParam.Value = cardId;
                command.Parameters.Add(cardParam);

                command.Prepare();
                command.ExecuteNonQuery();
            }
        }
        catch (System.Exception)
        {
            Console.WriteLine("Card already in stack");
        }
    }

    public void DeleteStackById(int stackId)
    {
        using (var con = new Postgres().GetDB())
        {
            con.Open();

            var command = con.CreateCommand();
            command.CommandText = @"
            DELETE FROM stack
            WHERE id = @stack_id
            ";

            NpgsqlParameter stackParam = new("@stack_id", NpgsqlTypes.NpgsqlDbType.Integer);
            stackParam.Value = stackId;
            command.Parameters.Add(stackParam);

            command.Prepare();
            command.ExecuteNonQuery();
        }
    }

    public void RemoveCardFromStackById(int stackId, int cardId)
    {
        using (var con = new Postgres().GetDB())
        {
            con.Open();

            var command = con.CreateCommand();
            command.CommandText = @"
            DELETE FROM flashcards
            WHERE stack_id = @stack_id AND flashcard_id = @card_id
            ";

            NpgsqlParameter stackParam = new("@stack_id", NpgsqlTypes.NpgsqlDbType.Integer);
            stackParam.Value = stackId;
            command.Parameters.Add(stackParam);

            NpgsqlParameter cardParam = new("@card_id", NpgsqlTypes.NpgsqlDbType.Integer);
            cardParam.Value = cardId;
            command.Parameters.Add(cardParam);

            command.Prepare();
            command.ExecuteNonQuery();
        }
    }

}
