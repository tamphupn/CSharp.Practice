using System;
using System.Collections;

namespace Hackerrank
{
    public class SinglyLinkedListNode
    {
        public int data;
        public SinglyLinkedListNode next;

        public SinglyLinkedListNode(int nodeData)
        {
            this.data = nodeData;
            this.next = null;
        }
    }

    public class SinglyLinkedList
    {
        public SinglyLinkedListNode head;
        public SinglyLinkedListNode tail;

        public SinglyLinkedList()
        {
            this.head = null;
            this.tail = null;
        }

        public void InsertNode(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }

        public void InsertNodeBefore(int nodeData)
        {
            SinglyLinkedListNode node = new SinglyLinkedListNode(nodeData);

            if (this.head == null)
            {
                this.head = node;
            }
            else
            {
                this.tail.next = node;
            }

            this.tail = node;
        }
    }


    public class MergeLinkedList
	{
        public static SinglyLinkedListNode MergeLists(SinglyLinkedListNode head1, SinglyLinkedListNode head2)
        {
            while (head2 != null)
            {
                var nodeWillInsert = new SinglyLinkedListNode(head2.data);

                if (head1.data >= head2.data)
                {
                    nodeWillInsert.next = head1.next; 
                    head1.next = nodeWillInsert;
                } else
                {
                    nodeWillInsert.next = head1;
                    head1 = nodeWillInsert;
                }
                head2 = head2.next;
            }

            return head1;
        }

        public static void PrintSinglyLinkedList(SinglyLinkedListNode node, string sep, TextWriter textWriter)
        {
            while (node != null)
            {
                textWriter.Write(node.data);

                node = node.next;

                if (node != null)
                {
                    textWriter.Write(sep);
                }
            }
        }

        public static void PrintSinglyLinkedList(SinglyLinkedListNode node)
        {
            while (node != null)
            {
                Console.WriteLine(node.data);
                node = node.next;
            }
        }

        public static void Run()
        {
            Console.WriteLine("Init head1");
            SinglyLinkedListNode head1 = new SinglyLinkedListNode(1);
            SinglyLinkedListNode head11 = new SinglyLinkedListNode(3);
            SinglyLinkedListNode head12 = new SinglyLinkedListNode(7);

            head12.next = null;
            head11.next = head12;
            head1.next = head11;

            PrintSinglyLinkedList(head1);

            Console.WriteLine("Init head2");
            SinglyLinkedListNode head2 = new SinglyLinkedListNode(1);
            SinglyLinkedListNode head21 = new SinglyLinkedListNode(2);

            head21.next = null;
            head2.next = head21;
            PrintSinglyLinkedList(head2);

            Console.WriteLine("Merged List");
            var mergeList = MergeLists(head1, head2);
            PrintSinglyLinkedList(mergeList);
        }
    }
}

