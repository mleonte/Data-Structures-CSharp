using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DataStructures.Tests
{
    public class LinkedListTest
    {
        public LinkedListTest()
        {
        }

        [Theory]
        [InlineData(1)]
        [InlineData(1, 3, 2)]
        public void AddAndIndex(params int[] values)
        {
            var lst = new LinkedList<int>();
            foreach (var i in values)
            {
                lst.Add(i);
            }

            Assert.Equal(values.Length, lst.Count);
            for (int i = 0; i < values.Length; i++)
            {
                Assert.Equal(values[i], lst[i]);
            }
        }

        [Fact]
        public void CountEmpty()
        {
            var lst = new LinkedList<int>();
            Assert.Empty(lst);
        }

        [Fact]
        public void IndexEmpty()
        {
            var lst = new LinkedList<int>();
            Assert.Throws<IndexOutOfRangeException>(() => lst[0]);
        }

        [Fact]
        public void IndexOutOfRange()
        {
            var lst = new LinkedList<int>(new [] { 1 });
            Assert.Throws<IndexOutOfRangeException>(() => lst[1]);
        }

        [Theory]
        [InlineData(1, 0, 1)]
        [InlineData(3, 1, 1, 3, 2)]
        [InlineData(2, 2, 1, 3, 2)]
        public void IndexOf(int value, int expectedIndex, params int[] values)
        {
            var lst = new LinkedList<int>(values);
            Assert.Equal(expectedIndex, lst.IndexOf(value));
        }

        [Theory]
        [InlineData(5, 1)]
        [InlineData(5, 1, 3, 2)]
        public void IndexOfNotFound(int value, params int[] values)
        {
            var lst = new LinkedList<int>(values);
            Assert.Equal(-1, lst.IndexOf(value));
        }

        [Fact]
        public void IndexOfEmpty()
        {
            var lst = new LinkedList<int>();
            Assert.Equal(-1, lst.IndexOf(1));
        }

        [Theory]
        [InlineData(5, 0, 1)]
        [InlineData(5, 1, 1)]
        [InlineData(5, 0, 1, 3, 2)]
        [InlineData(5, 1, 1, 3, 2)]
        [InlineData(5, 2, 1, 3, 2)]
        [InlineData(5, 3, 1, 3, 2)]
        public void Insert(int value, int index, params int[] values)
        {
            var lst = new LinkedList<int>(values);
            lst.Insert(index, value);

            Assert.Equal(values.Length + 1, lst.Count);
            Assert.Equal(value, lst[index]);
            if (index < values.Length)
                Assert.Equal(values[index], lst[index + 1]);
        }

        [Fact]
        public void InsertEmpty()
        {
            var lst = new LinkedList<int>();
            lst.Insert(0, 1);
            Assert.Collection(lst, x => Assert.Equal(1, x));
        }

        [Fact]
        public void InsertEmptyOutOfRange()
        {
            var lst = new LinkedList<int>();
            Assert.Throws<IndexOutOfRangeException>(() => lst.Insert(1, 1));
        }

        [Fact]
        public void InsertOutOfRange()
        {
            var lst = new LinkedList<int>(new[] { 1, 2, 3 });
            Assert.Throws<IndexOutOfRangeException>(() => lst.Insert(5, 1));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(3, 1, 3, 2)]
        [InlineData(2, 1, 3, 2)]
        public void Remove(int toRemove, params int[] values)
        {
            var lst = new LinkedList<int>(values);
            Assert.True(lst.Remove(toRemove));
            Assert.Equal(values.Count() - 1, lst.Count);

            if (lst.Count != 0)
            {
                int offset = 0;
                for (int i = 0; i < lst.Count; i++)
                {
                    if (values[i + offset] == toRemove)
                        offset++;

                    Assert.Equal(values[i + offset], lst[i]);
                }
            }
        }

        [Fact]
        public void RemoveEmpty()
        {
            var lst = new LinkedList<int>();
            Assert.False(lst.Remove(1));
        }

        [Theory]
        [InlineData(5, 1)]
        [InlineData(5, 1, 3, 2)]
        public void RemoveNotFound(int toRemove, params int[] values)
        {
            var lst = new LinkedList<int>(values);
            Assert.False(lst.Remove(toRemove));
            Assert.Equal(values.Length, lst.Count);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(1, 1, 3, 2)]
        [InlineData(2, 1, 3, 2)]
        public void RemoveAt(int index, params int[] values)
        {
            var lst = new LinkedList<int>(values);
            lst.RemoveAt(index);
            Assert.Equal(values.Count() - 1, lst.Count);

            if (lst.Count != 0)
            {
                int offset = 0;
                for (int i = 0; i < lst.Count; i++)
                {
                    if (i + offset == index)
                        offset++;

                    Assert.Equal(values[i + offset], lst[i]);
                }
            }
        }

        [Fact]
        public void RemoveAtEmpty()
        {
            var lst = new LinkedList<int>();
            Assert.Throws<IndexOutOfRangeException>(() => lst.RemoveAt(1));
        }

        [Theory]
        [InlineData(2, 1)]
        [InlineData(4, 1, 3, 2)]
        public void RemoveAtNotFound(int index, params int[] values)
        {
            var lst = new LinkedList<int>(values);
            Assert.Throws<IndexOutOfRangeException>(() => lst.RemoveAt(index));
            Assert.Equal(values.Length, lst.Count);
        }
    }
}
