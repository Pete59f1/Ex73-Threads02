using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


namespace Ex73_Threads02
{
    class Buffer
    {
        private Queue<Car> bufferData;
        private int capacity;

        private object bufferLock = new object();

        public Buffer(int capacity)
        {
            this.capacity = capacity;
            bufferData = new Queue<Car>();
        }
        public void Put(Car car)
        {
            lock (bufferLock)
            {
                if (IsFull())
                {
                    Monitor.Wait(bufferLock);
                    //throw new System.ArgumentException("Køen er fuld");
                }
                bufferData.Enqueue(car);
                Monitor.Pulse(bufferLock);
            }
        }
        public Car Get()
        {
            lock (bufferLock)
            {
                Car car = null;
                if (IsEmpty())
                {
                    Monitor.Wait(bufferLock);
                    //throw new System.ArgumentException("Køen er tom");
                }
                car = bufferData.Dequeue();
                Monitor.Pulse(bufferLock);
                return car;
            }
        }

        public bool IsEmpty()
        {
            bool isempty;
            lock (bufferLock)
            {
                isempty = bufferData.Count == 0;
            }
            return isempty;
        }

        public bool IsFull()
        {
            bool isfull;
            lock (bufferLock)
            {
                isfull = bufferData.Count == capacity;
            }
            return isfull;
        }
    }
}