namespace MySerialize
{
    public static class StartTesting
    {
        static Random rand = new Random();

        //help to create next node
        static ListNode addNode(ListNode prev)
        {
            ListNode result = new ListNode();
            result.Previous = prev;
            result.Next = null;
            result.Data = rand.Next(0, 1000).ToString();
            prev.Next = result;
            return result;
        }

        //help to create ref to Random node
        static ListNode randomNode(ListNode _head, int _length)
        {
            int k = rand.Next(0, _length);
            int i = 0;
            ListNode result = _head;
            while (i < k)
            {
                result = result.Next;
                i++;
            }
            return result;
        }

        public static string StartTest()
        {
            int length = 20;
            string res = "";
            try
            {
                ListNode head = new();
                ListNode tail;
                ListNode temp;

                head.Data = rand.Next(0, 1000).ToString();

                tail = head;

                for (int i = 1; i < length; i++)
                    tail = addNode(tail);

                temp = head;

                for (int i = 0; i < length; i++)
                {
                    temp.Random = randomNode(head, length);
                    temp = temp.Next;
                }

                ListRandom firstList = new ListRandom();
                firstList.Head = head;
                firstList.Tail = tail;
                firstList.Count = length;

                FileStream fs = new FileStream("dat.dat", FileMode.OpenOrCreate);
                firstList.Serialize(fs);
                fs.Close();

                ListRandom secondList = new ListRandom();
                try
                {
                    fs = new FileStream("dat.dat", FileMode.Open);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine("Press Enter to exit.");
                }
                secondList.Deserialize(fs);

                if (firstList.Equals(secondList))
                    res = "Success";
            }
            catch 
            {
                res = "Error";
            }
            return res;
        }
    }
}
