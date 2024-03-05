using System.Xml.Linq;

namespace MySerialize
{
    class ListRandom
    {
        public ListNode Head;
        public ListNode Tail;
        public int Count;

        public void Serialize(Stream s)
        {
            ListNode temp = Head;
            
            using (StreamWriter w = new StreamWriter(s))
            {
                while (temp != null)
                {
                    w.WriteLine(temp.Data.ToString() + ":" + getPosition(temp.Random).ToString());
                    temp = temp.Next;
                }
                
            }
        }

        public void Deserialize(Stream s)
        {
            List<ListNode> arr = new List<ListNode>();
            ListNode temp = new ListNode();
            Count = 0;
            Head = temp;
            string line;

            try
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (!line.Equals(""))
                        {
                            Count++;
                            temp.Data = line;
                            ListNode next = new ListNode();
                            temp.Next = next;
                            arr.Add(temp);
                            next.Previous = temp;
                            temp = next;
                        }
                    }
                }
                Tail = temp.Previous;
                Tail.Next = null;

                foreach (ListNode n in arr)
                {
                    n.Random = arr[Convert.ToInt32(n.Data.Split(':')[1])];
                    n.Data = n.Data.Split(':')[0];
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Не удалось обработать файл данных, возможно, он поврежден, подробности:");
                Console.WriteLine(e.Message);
                Console.WriteLine("Press Enter to exit.");
                Console.Read();
                Environment.Exit(0);
            }
        }

        public override bool Equals(object? obj)
        {
            return obj is ListRandom random &&
                   Equals(Head.Data, random.Head.Data) &&
                   Equals(Tail.Data, random.Tail.Data) &&
                   Count == random.Count;
        }

        private int getPosition(ListNode node)
        {
            int position = 0;
            while (node != Head)
            {
                node = node.Previous;
                position++;
            }
            return position;
        }
    }
}
