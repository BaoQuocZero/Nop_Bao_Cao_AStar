using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AStar_KTQT2
{
    class HDUT
    {
        // HDUT đã không còn được sử dụng do Cell và các hàm khác đã thay thế nó
        // Nhưng tôi vẫn sẽ không xóa nó để đề phòng

        //public int front;
        //public int rear;
        //public int noItems;
        //public Element[] arr;
        //public static readonly int MAX = 1000;

        //public HDUT()
        //{
        //    this.front = 0;
        //    this.rear = -1;
        //    this.noItems = 0;
        //    this.arr = new Element[MAX];
        //}

        //public void enQueue(Element x)
        //{
        //    if (isFull())
        //    {
        //        Console.WriteLine("Hàng đợi đã đầy!");
        //        return;
        //    }

        //    this.rear = (this.rear + 1) % MAX;
        //    this.arr[this.rear] = x;
        //    this.noItems++;
        //}

        //public Element deQueue()
        //{
        //    if (isEmpty())
        //    {
        //        Console.WriteLine("Hàng đợi rỗng!");
        //        return null;
        //    }
        //    else
        //    {
        //        int minIndex = front;
        //        double minF = arr[front].F;

        //        for (int i = (front + 1) % MAX; i != (rear + 1) % MAX; i = (i + 1) % MAX)
        //        {
        //            if (arr[i].F < minF)
        //            {
        //                minIndex = i;
        //                minF = arr[i].F;
        //            }
        //        }

        //        Element minElement = arr[minIndex];

        //        arr[minIndex] = arr[front];
        //        arr[front] = minElement;

        //        front = (front + 1) % MAX;
        //        noItems--;

        //        return minElement;
        //    }
        //}

        //public void printHangdoi()
        //{
        //    if (isEmpty())
        //    {
        //        Console.WriteLine("Hàng đợi rỗng!");
        //        return;
        //    }

        //    Console.WriteLine("Nội dung của hàng đợi:");
        //    int current = front;
        //    while (current != (rear + 1) % MAX)
        //    {
        //        arr[current].printElmt();
        //        current = (current + 1) % MAX;
        //    }
        //}

        //public bool isEmpty()
        //{
        //    return (this.noItems == 0);
        //}

        //public bool isFull()
        //{
        //    return (this.noItems == MAX);
        //}

        //public bool Contains(Element elmt)
        //{
        //    for (int i = front; i != (rear + 1) % MAX; i = (i + 1) % MAX)
        //    {
        //        if (arr[i] != null && arr[i].Equals(elmt))
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        //public int IndexOf(Element elmt)
        //{
        //    for (int i = front; i != (rear + 1) % MAX; i = (i + 1) % MAX)
        //    {
        //        if (arr[i] != null && arr[i].Equals(elmt))
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}

        //public Element GetElementAt(int index)
        //{
        //    if (index >= front && index <= rear)
        //    {
        //        return arr[index];
        //    }
        //    else
        //    {
        //        throw new IndexOutOfRangeException("Nam ngoai pham vi HDUT");
        //    }
        //}

        //public void Update(Element elmt)
        //{
        //    for (int i = front; i != (rear + 1) % MAX; i = (i + 1) % MAX)
        //    {
        //        if (arr[i] != null && arr[i].Tendinh == elmt.Tendinh)
        //        {
        //            if (arr[i].F > elmt.F)
        //            {
        //                arr[i] = elmt;
        //                break;
        //            }
        //        }
        //    }
        //}
    }
}
