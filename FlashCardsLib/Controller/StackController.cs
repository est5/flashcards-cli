using FlashCardsLib.DB;
using FlashCardsLib.Model;
using Npgsql;

namespace FlashCardsLib.Controller;

public class StackController
{
    public void GetStackById(int stackId) => throw new NotImplementedException();

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

    public void GetFlashcardsInStackById(int stackId) => throw new NotImplementedException();

    public void AddFlashcardToStackById(Flashcard flashcard, int stackId) => throw new NotImplementedException();

    public void DeleteStackById(int stackId) => throw new NotImplementedException();

    public void RemoveCardFromStackById(int stackId, int cardId) => throw new NotImplementedException();

}
