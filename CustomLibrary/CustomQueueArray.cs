﻿using System;
using System.Collections.Generic;

namespace CustomLibrary
{
    public class CustomQueueArray
    {
        #region private fileds
        private int[] items;
        private int front;
        private int rear;
        private int count;
        private int incr;
        #endregion

        #region constructor
        public CustomQueueArray(int length)
        {
            this.items = new int[length];
        }
        #endregion

        #region public methods
        public void Enqueue(int item)
        {
            if (count == items.Length)
            {
                throw new Exception("Queue is overflow");
            }

            items[rear] = item;
            rear = (rear + 1) % items.Length;
            incr++;
            count++;
        }

        public int Dequeue()
        {
            if (count == 0)
            {
                throw new Exception("Queue is underflow");
            }

            var item = items[front];
            front = (front + 1) % items.Length;
            count--;

            return item;
        }

        public void Print()
        {
            int max = incr >= items.Length ? items.Length : rear;

            for (int i = front; i < max; i++)
            {
                Console.WriteLine(items[i]);
            }

            if (incr >= items.Length)
            {
                for (int i = incr - items.Length; i > 0; i--)
                {
                    Console.WriteLine(items[i - 1]);
                }
            }

        }

        public int Peek()
        {
            if (count == 0)
            {
                throw new Exception("Queue is underflow");
            }

            return items[front];
        }
        #endregion
    }

    public class ReverseQueue
    {
        #region private fileds
        Stack<int> stack = new Stack<int>();
        Queue<int> queue = new Queue<int>();
        #endregion

        #region constructor
        public ReverseQueue()
        {
            queue.Enqueue(10);
            queue.Enqueue(20);
            queue.Enqueue(30);
            queue.Enqueue(40);
            queue.Enqueue(50);
        }
        #endregion

        #region public methods
        public void Reverse()
        {
            while (queue.Count != 0)
            {
                stack.Push(queue.Dequeue());
            }

            while (stack.Count != 0)
            {
                queue.Enqueue(stack.Pop());
            }
        }

        public void Print()
        {
            foreach (int item in queue)
            {
                Console.WriteLine(item);
            }
        }
        #endregion

    }

    public class QueueWithTwoStacks
    {
        #region private fields
        Stack<int> stack1 = new Stack<int>();
        Stack<int> stack2 = new Stack<int>();
        #endregion

        #region public methods
        public void Enqueue(int item)
        {
            stack1.Push(item);
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is underflow");
            }

            MoveStack1ToStack2();

            return stack2.Pop();
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is underflow");
            }

            MoveStack1ToStack2();

            return stack2.Peek();
        }
        #endregion

        #region private methods
        private bool IsEmpty()
        {
            return stack1.Count == 0 && stack2.Count == 0;
        }

        private void MoveStack1ToStack2()
        {
            if (stack2.Count == 0)
            {
                while (stack1.Count != 0)
                {
                    stack2.Push(stack1.Pop());
                }
            }
        }
        #endregion
    }

    public class QueueWithOneStack
    {
        #region private fields
        Stack<int> stack = new Stack<int>();
        #endregion

        #region public methods
        public void Enqueue(int item)
        {
            if (IsEmpty())
            {
                stack.Push(item);
            }
            else
            {
                InsertAtBottom(item);
            }
        }

        public int Dequeue()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is underflow"); 
            }

            return stack.Pop();
        }

        public int Peek()
        {
            if (IsEmpty())
            {
                throw new Exception("Queue is underflow");
            }

            return stack.Peek();
        }
        #endregion

        #region private methods
        private bool IsEmpty()
        {
            return stack.Count == 0;
        }

        private void InsertAtBottom(int item)
        {
            if(IsEmpty())
            {
                stack.Push(item);
            }
            else
            {
                int top = stack.Peek();
                stack.Pop();
                InsertAtBottom(item);
                stack.Push(top);
            }
        }
        #endregion
    }

}