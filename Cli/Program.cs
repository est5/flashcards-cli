using FlashCardsLib.Controller;
using FlashCardsLib.Model;

var cntrl = new FlashcardController();
var cardToAdd = new Flashcard("String", "Строка");
cntrl.AddFlashcard(cardToAdd);


var card = cntrl.GetFlashcardById(1);
System.Console.WriteLine($"front:{card.Front} back:{card.Back}");

var cards = cntrl.GetAllFlashcards();

cards.ForEach(card => Console.WriteLine($"front:{card.Front} back:{card.Back}"));
