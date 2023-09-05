public class Message
{
    private readonly string _content;
    private readonly string _author;
    private readonly DateTime _time;
    private int _likes;

    public Message() { }

    Random rnd = new Random();

    public Message(string content, string author, DateTime time)
    {
        this._content = content;
        this._author = author;
        this._time = time;
    }

    public int Likes { get => _likes; }
    public DateTime Time { get => _time; }
    public string Author { get => _author; }
    public string Content { get => _content; }

    public void AddLike()
    {
        _likes++;
    }

    public double GetPopularity()
    {
        double elapsed = DateTime.Now.Subtract(this._time).TotalSeconds;
        if (elapsed == 0)
        {
            return _likes;
        }
        return _likes / elapsed;

    }

    public void ShowMessage()
    {
        Console.WriteLine("{0}/{1}\n{2}", Author, Time, Content);

    }

    public string PopVsPop(Message esimene, Message teine)
    {
        double esimenePop = Math.Round(esimene.GetPopularity(), 2);
        double teinePop = Math.Round(teine.GetPopularity(), 2);
        string rezult = "";
        Console.WriteLine("{0} ja {1}", esimenePop, teinePop);
        if (esimenePop > teinePop) { rezult = "Esimene sõnum on populaarsem kui teine"; }
        else if (esimenePop < teinePop) { rezult = "Teine sõnum on populaarsem kui esimene"; }
        else { rezult = "Sõnumid on võrdselt populaarsed"; }

        return rezult;
    }

    public string PopVsPopN(List<Message> messages)
    {
        double messageTop = 0;
        string rezult = "";
        for (int i = 0; i < messages.Count; i++)
        {
            if (messages[i].GetPopularity() > messageTop)
            {
                messageTop = messages[i].GetPopularity();
                rezult = (messages[i].Content + " kõige populaarsem sõnum, selle kirjutanud " + messages[i].Author);
            }
        }
        return rezult;
    }

    public void CreateMessages(List<Message> messages)
    {
        int n = rnd.Next(2, 10);
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine("Sõnum?");
            string content = Console.ReadLine();
            Console.WriteLine("Autor?");
            string author = Console.ReadLine();
            Console.WriteLine("Meeldimiste arv?");
            int likes = int.Parse(Console.ReadLine());

            Message m = new Message(content, author, DateTime.Now);
            for (int l = 0; l < likes; l++)
            {
                m.AddLike();
            }

            messages.Add(m);
        }
    }

}