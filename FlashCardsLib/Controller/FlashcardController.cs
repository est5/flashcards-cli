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

    public void GetFlashcardById(int id)
    {

    }

    public void GetAllFlashcards()
    {

    }

    public void AddFlashcard(Flashcard flashcard)
    {

    }

    public void DeleteFlashcardById(int id)
    {

    }



}
