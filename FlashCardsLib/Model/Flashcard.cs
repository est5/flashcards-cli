using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCardsLib.Model;

public class Flashcard
{
    public Flashcard(string front, string back)
    {
        Front = front;
        Back = back;
    }

    public string Front { get; set; }
    public string Back { get; set; }
}
