using FlashCardsLib.Controller;

var stackCtrl = new StackController();
stackCtrl.GetAllStacks().ForEach(Console.WriteLine);
Console.WriteLine(stackCtrl.GetStackById(1));
stackCtrl.AddFlashcardToStackById(1, 1);
Console.WriteLine(stackCtrl.GetStackById(1));
stackCtrl.RemoveCardFromStackById(1, 1);
Console.WriteLine(stackCtrl.GetStackById(1));


