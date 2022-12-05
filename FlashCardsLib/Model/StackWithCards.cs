using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FlashCardsLib.Model
{
    public class StackWithCards
    {
        public List<Flashcard> Cards { get; set; } = new List<Flashcard>();
        public int Id { get; set; }
        public string Title { get; set; }

        public override string ToString()
        {
            return $"ID: {this.Id}, Title: {this.Title}\n---CARDS---\n{GetCards()}";
        }

        private string GetCards()
        {
            var output = "";

            Cards.ForEach(e => output += $"ID: {e.Id}, Front: {e.Front}, Back: {e.Back}\n");

            return output.TrimEnd();
        }
    }
}
