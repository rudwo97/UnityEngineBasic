﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LinkedList
{
    internal class Node<T>
    {
        public T Value;
        public Node<T> Next;
        public Node<T> Prev;

        public Node(T value)
        {
            Value = value;
        }
    }

    internal class MyLinkedList<T>
    {
        public Node<T> First => _first;
        public Node<T> Last => _last;
        private Node<T> _first, _last, _tmp1, tmp2;

        public int Count
        {
            get
            {
                int count = 0;  
                _tmp1 = _first;
                while (_tmp1 != null)
                {
                    count++;
                    _tmp1 = _tmp1.Next;
                }
                return count;
            }
        }

        // 삽입 알고리즘
        // O(1)
        public void AddFirst(T value)
        {
            _tmp1 = new Node<T>(value);

            // 노드가 현재 하나이상 존재한다면
            if (_first != null )
            {
                _tmp1.Next = _first;
                _first.Prev = _tmp1;
            }
            // 노드가 하나도 없다면
            if (_last == null )
            {
                _last = _tmp1;
            }
            _first = _tmp1;
        }


        public void AddLats (T value)
        {
            _tmp1 = new Node<T>(value);
            if (_last != null )
            {
                _last.Next = _tmp1;
                _tmp1.Prev = _last;
            }
            if (_first == null)
            {
                _first = _tmp1;
            }
            _last = _tmp1;
        }

        public void AddBefore(Node<T> node, T value)
        {
            _tmp1 = new Node<T>(value);

            if (node.Prev != null)
            {
                node.Prev.Next = _tmp1;
                _tmp1.Prev = node.Prev;
            }
            else
            {
                _first = _tmp1;
            }

            node.Prev = _tmp1;
            _tmp1.Next = node;
        }
        public void AddAfter(Node<T> node, T value)
        {
            _tmp1 = new Node<T>(value);
            if (node.Next != null)
            {
                node.Next.Prev = _tmp1;
                _tmp1.Next = node.Next;
            }
            else
            {
                _last = _tmp1;
            }

            node.Next = _tmp1;
            _tmp1.Prev= node;
        }

        public Node<T> Find(T value)
        {
            _tmp1 = _first;
            while (_tmp1 != null)
            {
                if (Comparer<T>.Default.Compare(_tmp1.Value, value) == 0)
                    return _tmp1;

                _tmp1 = _tmp1.Next;
            }

            return null;
        }

        public Node<T> FindLast(T value)
        {
            _tmp1 = _last;
            while (_tmp1 != null)
            {
                if (true)
                {

                }
            }
            return null;
        }
        public bool Remove(T value)
        {
            _tmp1 = Find(value);

            if (_tmp1 == null)
            {
            return false;
            }
            else
            {
                if (_tmp1.Prev != null)
                    _tmp1.Prev.Next = _tmp1.Next;
                if (_tmp1.Next != null)
                    _tmp1.Next.Prev = _tmp1.Prev;

                _tmp1.Next = null; 
                _tmp1.Prev = null;
                _tmp1 = null;
                return true;
            }
        }

        public bool RemoveLast(T value)
        {
            return false;
        }
            
    }
}
