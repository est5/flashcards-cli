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
    public int Id { get; set; }

    public override string ToString()
    {
        return $"ID: {Id}, Front: {Front}, Back: {Back}";
    }
}
