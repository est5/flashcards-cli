using FlashCardsLib.Controller;
using FlashCardsLib.DB;


var cntrl = new FlashcardController(new Postgres().GetDB());
var card = cntrl.GetFlashcardById(1);
System.Console.WriteLine($"front:{card.Front} back:{card.Back}");
