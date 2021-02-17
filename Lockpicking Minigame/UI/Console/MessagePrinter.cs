using System;

namespace LockpickingMinigame
{
    public class MessagePrinter
    {
        private const int Tolerance = 2;
        private readonly string[] _messageParts;
        private double[] _numbers;
        private bool _isPrinted;
        
        public MessagePrinter(string message)
        {
            _messageParts = message.Split("[n]");
            _numbers = new double[_messageParts.Length - 1];
        }
        
        //"У игрока [n] отмычек;"
        public void Print(double[] numbers)
        {
            if (numbers.Length != _numbers.Length)
                throw new Exception("Inappropriate numbers quantity!");

            _numbers = numbers;

            if (!_isPrinted)
                PrintMessage();
            else
                UpdateNumbersInMessage();
        }

        private void PrintMessage()
        {
            var message = "";
            for (var i = 0; i < _numbers.Length; i++)
            {
                message += _messageParts[i] + _numbers[i];

                if (i == _numbers.Length - 1)
                    message += _messageParts[i + 1];
            }

            Console.WriteLine(message);
            _isPrinted = true;
        }
        
        private void UpdateNumbersInMessage()
        {
            throw new NotImplementedException();
        }
    }
}