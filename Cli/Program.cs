using FlashCardsLib.Controller;
using FlashCardsLib.Model;

var cntrl = new FlashcardController();

var cards = cntrl.GetAllFlashcards();

cards.ForEach(card => Console.WriteLine($"front:{card.Front} back:{card.Back} id :{card.Id}"));


