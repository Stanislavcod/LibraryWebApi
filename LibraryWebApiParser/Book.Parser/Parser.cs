using HtmlAgilityPack;

namespace Book.Parser
{
    public class Parser
    {
        public List<string> GetBook()
        {
            HtmlWeb web = new();
            HtmlDocument document = web.Load("https://www.100bestbooks.ru");

            var title = document.DocumentNode.SelectNodes("//table[contains(@class, 'table-rating')]//td/a/span");
            List<string> list = new();
            if (title is not null)
            {
                int count = 1;
                foreach (HtmlNode item in title)
                {
                    if (count % 2 == 0)
                    {
                        list.Add(item.InnerText);
                    }
                    count++;
                }
            }
            return list;
        }
    }
}