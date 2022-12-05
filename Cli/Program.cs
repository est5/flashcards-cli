using FlashCardsLib.Controller;

var stackCtrl = new StackController();
stackCtrl.GetAllStacks().ForEach(Console.WriteLine);
Console.WriteLine(stackCtrl.GetStackById(1));
