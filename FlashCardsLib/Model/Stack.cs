using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCardsLib.Model;

public class Stack
{
    public Stack(string title)
    {
        Title = title;
        Flashcards = new List<int>();
    }

    public string Title { get; set; }
    public List<int> Flashcards { get; set; }

    public void AddCard(int cardId)
    {
        Flashcards.Add(cardId);
    }

    public void RemoveCard(int cardId)
    {
        Flashcards.Remove(cardId);
    }
}
