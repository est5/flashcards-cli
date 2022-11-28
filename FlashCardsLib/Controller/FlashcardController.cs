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

    public void GetFlashcardById(int id) => throw new NotImplementedException();

    public void GetAllFlashcards() => throw new NotImplementedException();

    public void AddFlashcard(Flashcard flashcard) => throw new NotImplementedException();

    public void DeleteFlashcardById(int id) => throw new NotImplementedException();

    public void UpdateFlashcardByID(int id) => throw new NotImplementedException();

}
