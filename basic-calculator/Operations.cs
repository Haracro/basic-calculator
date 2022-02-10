using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace basic_calculator
{
    internal class Operations
    {
        private OperationsType op;
        public Operations()
        {
            op = OperationsType.None;
        }

        public enum OperationsType
        {
            None,
            Add,
            Subtract,
            Multiply,
            Divide,
        }

        public OperationsType GetOperation { get { return op; } }

        public void ChangeOperation(string op)
        {
            if (op == null) return;

            switch(op)
            {
                case "+":
                    this.op = OperationsType.Add;
                    break;
                case "-":
                    this.op = OperationsType.Subtract;
                    break;
                case "*":
                    this.op = OperationsType.Multiply;
                    break;
                case "/":
                    this.op = OperationsType.Divide;
                    break;
                default:
                    this.op = OperationsType.None;
                    break;
            }
        }
    }
}
