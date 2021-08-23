using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MetrikeRefaktoringCodeTuning
{
    public class NumberCollection
    {
        protected List<int> numbers = new List<int>();

        public int returnNumber(int index)
        {
            return numbers.ElementAt(index);
        }

        public virtual void addNumber(int number)
        {
            numbers.Add(number);
        }
    }

    public class PositiveNumbers : NumberCollection
    {
        public override void addNumber(int number)
        {
            if (number > 0)
            {
                numbers.Add(number);
            }
        }
    }

    public class SmallPositiveNumbers : PositiveNumbers
    {
        public override void addNumber(int number)
        {
            if (number > 0 && number < 10)
            {
                numbers.Add(number);
            }
        }
    }

    public class EvenSmallPositiveNumbers : SmallPositiveNumbers
    {
        public override void addNumber(int number)
        {
            if (number > 0 && number < 10 && number % 2 == 0)
            {
                numbers.Add(number);
            }
        }
    }

    public class NumberCollectionRefactored
    {
        protected List<int> numbers = new List<int>();
        string mode;

        public int returnNumber(int index)
        {
            return numbers.ElementAt(index);
        }

        public void changeMode(string newMode)
        {
            mode = newMode;
        }

        public virtual void addNumber(int number)
        {
            if (mode == "Positive" && number > 0 ||
                mode == "Small Positive" && number > 0 && number < 10 ||
                mode == "Even Small Positive" && number > 0 && number < 10 && number % 2 == 0)
            {
                numbers.Add(number);
            }
        }
    }
}
