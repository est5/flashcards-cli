using FlashCardsLib.Controller;
using FlashCardsLib.DB;


var cntrl = new FlashcardController();

var card = cntrl.GetFlashcardById(1);
System.Console.WriteLine($"front:{card.Front} back:{card.Back}");

var cards = cntrl.GetAllFlashcards();

cards.ForEach(card => Console.WriteLine($"front:{card.Front} back:{card.Back}"));
