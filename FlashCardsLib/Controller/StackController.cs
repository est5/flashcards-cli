using FlashCardsLib.Model;
using Npgsql;

namespace FlashCardsLib.Controller;

public class StackController
{

    private NpgsqlConnection _dbContext;
    public StackController(NpgsqlConnection dbContext)
    {
        _dbContext = dbContext;
    }

    public void GetAllStacks() => throw new NotImplementedException();

    public void GetStackById(int stackId) => throw new NotImplementedException();

    public void GetFlashcardsInStackById(int stackId) => throw new NotImplementedException();

    public void AddFlashcardToStackById(Flashcard flashcard, int stackId) => throw new NotImplementedException();

    public void DeleteStackById(int stackId) => throw new NotImplementedException();

    public void RemoveCardFromStackById(int stackId, int cardId) => throw new NotImplementedException();

}
