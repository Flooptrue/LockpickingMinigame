using System;
using System.Text;

namespace LockpickingMinigame.UI.ConsoleUI
{
    public class MessagePrinter
    {
        private readonly string[] _messageParts;
        private readonly bool[] _isChanged;
        private readonly double[] _numbers;
        private readonly int[] _numbersPosition;
        private readonly string _numberFormat;
        private readonly int _row;
        private bool _isPrinted;
        
        public MessagePrinter(string message, string numberFormat)
        {
            _messageParts = message.Split("[n]");
            _numbers = new double[_messageParts.Length - 1];
            _isChanged = new bool[_messageParts.Length - 1];
            _numbersPosition = new int[_messageParts.Length - 1];
            _numberFormat = numberFormat;// использовать подобный формат "##;(##);**Zero**";
            _row = Console.CursorTop;
            Console.WriteLine();
        }
        
        public void Print(double[] numbers)
        {
            if (numbers.Length != _numbers.Length)
                throw new Exception("Inappropriate numbers quantity!");

            SaveNumbers(numbers);

            if (!_isPrinted)
                PrintMessage();
            else
                UpdateNumbersInMessage();
        }

        private void SaveNumbers(double[] numbers)
        {
            for (var i = 0; i < numbers.Length; i++)
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (_numbers[i] == numbers[i]) 
                    continue;
                
                _isChanged[i] = true;
                _numbers[i] = numbers[i];
            }
        }

        private void PrintMessage()
        {
            var (left, top) = Console.GetCursorPosition();
            Console.SetCursorPosition(0,_row);
            
            var message = new StringBuilder();
            for (var i = 0; i < _numbers.Length; i++)
            {
                message.Append(_messageParts[i]);
                _numbersPosition[i] = message.Length;
                message.Append(_numbers[i].ToString(_numberFormat));

                if (i == _numbers.Length - 1)
                    message.Append(_messageParts[i + 1]);
            }

            Console.Write(message);
            _isPrinted = true;
            
            Console.SetCursorPosition(left, top);
        }
        
        private void UpdateNumbersInMessage()
        {
            var (left, top) = Console.GetCursorPosition();
            
            for (var i = 0; i < _numbers.Length; i++)
            {
                if (!_isChanged[i])
                    return;
                
                Console.SetCursorPosition(_numbersPosition[i], _row);
                Console.Write(_numbers[i].ToString(_numberFormat));
            }
            
            Console.SetCursorPosition(left, top);
        }
    }
}