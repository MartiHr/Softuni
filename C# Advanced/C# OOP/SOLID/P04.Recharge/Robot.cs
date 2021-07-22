using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge
{
    public class Robot : Worker, IRechargeable
    {
        private int capacity;
        private int currentPower;

        public Robot(string id, int capacity) 
            : base(id)
        {
            this.capacity = capacity;
        }

        public int Capacity
        {
            get { return this.capacity; }
        }

        public int CurrentPower
        {
            get { return currentPower; }
            set { this.currentPower = value; }
        }

        public override void Work(int hours)
        {
            if (hours > CurrentPower)
            {
                hours = CurrentPower;
            }

            base.Work(hours);
            CurrentPower -= hours;
        }

        public void Recharge()
        {
            CurrentPower = Capacity;
        }
    }
}