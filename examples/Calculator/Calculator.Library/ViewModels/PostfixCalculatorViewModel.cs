using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Calculator.Library.ViewModels
{
    public class PostfixCalculatorViewModel : ViewModelBase
    {
        public enum CalculatorAction { Add, Subtract, Multiply, Divide, Equals, Clear, Delete, Dot}

        private Calculator.Library.Models.Calculator _Model { get; set; }

        public ICommand NumericButtonPress { get; set; }

        public string AccumulatorText
        {
            get
            {
                return _Model.Accumulator;
            }
            set
            {
                _Model.Accumulator = value;
                OnPropertyChanged("AccumulatorText");
            }
        }

        public PostfixCalculatorViewModel() : base()
        {
            _Model = new Models.Calculator();
            NumericButtonPress = new DelegateCommand(NumericButtonPressed, CanIssueCommand);
        }

        private bool CanIssueCommand(object param)
        {
            return true;
        }

        private void NumericButtonPressed(object param)
        {
            int value = 0;
            if(Int32.TryParse(param.ToString(), out value) == true)
            {
                NumericAction(value);
            }
            
        }

        public void NumericAction(int number)
        {
            AccumulatorText += number.ToString();
        }

        public void OperationAction(CalculatorAction action)
        {
            //This function would need to be fleshed out a bit to get postfix calculation working
        }
    }
}
