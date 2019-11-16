using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeGeneration
{
    class CodeGeneration
    {
        public void TriplaAddressCode(string exp) {
            //an instance variable of stack 
            Stack<string> stack = new Stack<string>();
            //declare variables used
            int x = 1;
            string op1=null, op2=null;

            //an instance that converts a given infix notation to post fix
            string postfix = Conversion.InfixToPostfix(exp);

            //loop through the characters present in postfix
            foreach (char c in postfix) {
                //if char is a letter or a digit
                if (char.IsLetterOrDigit(c))
                {
                    //push operand to stack
                    stack.Push(c.ToString());
                }
                //if char is a minus sign
                else if (c == '-')
                {
                    //pop operand from stack
                    op1 = stack.Pop();
                    Console.WriteLine("t"+ x + "="+ c+ op1);
                    //push temp value into stack
                    stack.Push("t" + x);
                    x = x + 1;
                    //if stack is not empty
                    if (stack != null)
                    {
                        //pop chars from stack 
                        op2 = stack.Pop();
                        op1 = stack.Pop();
                        Console.WriteLine("t"+ x + "="+ op1+ "+" + op2);
                        //push temp value back into stack after poping
                        stack.Push("t" + x);
                        x = x + 1;
                    }
                }
                
                //if char is an equals sign
                else if (c == '=')
                {
                    //pop operands from stack into op2 & op1
                    op2 = stack.Pop();
                    op1 = stack.Pop();
                    Console.WriteLine(op1+ c+ op2);
                }
                //if char is an operator
                else
                {
                    //pop operand into op1 
                    op1 = stack.Pop();
                    //if stack is ot empty
                    if (stack != null)
                    {
                        //pop other operand into op2
                        op2 = stack.Pop();
                        Console.WriteLine("t"+ x + "="+ op2+ c+ op1);
                        //push new temp value into stack
                        stack.Push("t" + x);

                        x = x + 1;
                    }
                }
           }
        
        }

        public void QuadrupleCode(string exp)
        {
            //an instance variable of stack 
            Stack<string> stack = new Stack<string>();
            //declare variables used
            int x = 1;
            string op1 = null, op2 = null;
            //an instance that converts a given infix notation to post fix
            string postfix = Conversion.InfixToPostfix(exp);
            //header for quad code
            Console.WriteLine("Op |\t Arg1 |\t Arg2 |\t Result");

            //loop through the characters present in postfix
            foreach (char c in postfix)
            {
                //if char is a letter or a digit
                if (char.IsLetterOrDigit(c))
                {
                    //push operand to stack
                    stack.Push(c.ToString());
                }
                //if char is a minus sign
                else if (c == '-')
                {
                    //pop from stack into op1 and push temp value into stack
                    op1 = stack.Pop();
                    stack.Push("t"+ x );
                    Console.WriteLine("{0} \t {1} \t {2} \t {3}", c , op1, " ", "t"+x);
                    x = x + 1;
                    //if stack is not empty
                    if (stack != null)
                    {
                        //pop into op2 & op1
                        op2 = stack.Pop();
                        op1 = stack.Pop();
                        Console.WriteLine("{0} \t {1} \t {2} \t {3}", "+", op1, op2, "t" + x);
                        //push new temp value into stack
                        stack.Push("t" + x);
                        x = x + 1;
                    }
                }
                //if char is an equals sign
                else if (c == '=')
                {
                    //pop operands from stack into op2 & op1
                    op2 = stack.Pop();
                    op1 = stack.Pop();
                    Console.WriteLine("{0} \t {1} \t {2} \t {3}", c, op2, " ", op1);

                }
                //if char is an operator
                else
                {
                    //pop operands from stack into op2 & op1
                    op1 = stack.Pop();
                    op2 = stack.Pop();
                    Console.WriteLine("{0} \t {1} \t {2} \t {3}", c, op2, op1, "t" + x);
                    //push new temp value into stack
                    stack.Push("t" + x);

                        x = x + 1;
                    
                }
            }

        }

        public void TripleCode(string exp)
        {
            //initialize variables
            Stack<string> stack = new Stack<string>();
            int x = 0;
            string op1 = null, op2 = null;
            //an instance that converts a given infix notation to post fix
            string postfix = Conversion.InfixToPostfix(exp);
            Console.WriteLine("(Op) |\t Arg1 |\t Arg2 ");
            foreach (char c in postfix)
            { //if char is a letter or a digit
                if (char.IsLetterOrDigit(c))
                {
                    //push operand to stack
                    stack.Push(c.ToString());
                }
                else if (c == '-')
                {
                    op1 = stack.Pop();
                    stack.Push("("+x+")");
                    Console.WriteLine("{0} \t {1} \t {2}", c, op1, " ");
                    x = x + 1;
                    if (stack != null)
                    {
                        op2 = stack.Pop();
                        op1 = stack.Pop();
                        Console.WriteLine("{0} \t {1} \t {2}", "+", op1, op2);
                        stack.Push("(" + x + ")");
                        x = x + 1;
                    }
                }
                else if (c == '=')
                {
                    op2 = stack.Pop();
                    op1 = stack.Pop();
                    Console.WriteLine("{0} \t {1} \t {2}", c, op2, op1);

                }
                else
                {
                    op1 = stack.Pop();
                    op2 = stack.Pop();
                    Console.WriteLine("{0} \t {1} \t {2}", c, op2, op1);
                    stack.Push("(" + x + ")");
                    x = x + 1;

                }
            }

        }

        public static void Main()   
        {
            Console.WriteLine("Welcome To Group 22 Code Generator\n");
            Console.WriteLine("Enter a valid expression\n");
            string infix = Console.ReadLine();
            String postfix = Conversion.InfixToPostfix(infix);
            System.Console.WriteLine("\nInFix string :\t" + infix);
            System.Console.WriteLine("PostFix :\t" + postfix);
            CodeGeneration c = new CodeGeneration();
            Console.WriteLine("Three Address Code");
            c.TriplaAddressCode(infix);
            Console.WriteLine("\n\n");
            Console.WriteLine("Quadruple Code");
            c.QuadrupleCode(infix);
            Console.WriteLine("\n\n");
            Console.WriteLine("Triple Code");
            c.TripleCode(infix);

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("E-closure");
            Console.WriteLine();
            Console.WriteLine("Enter state transitions in the form");
            Console.WriteLine("{1:state}   {2:output 1}  {5:output 2}");
            Console.WriteLine("Enter e to denote epsilon and kk to end");
            Console.WriteLine();

            Console.WriteLine("Enter transition symbols: ");

            string x = Console.ReadLine();
            string y = Console.ReadLine();

            string[,] state = new string[10,5];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    Console.WriteLine(i + " " + j + ": ");
                    state[i, j] = Console.ReadLine();
                    if (state[i, j] == "kk")
                    {
                       
                        break;
                    }

                }
                if (state[i, 0] == "kk")
                {
                    state[i, 0] = "";
                    break;
                }

            }
            Console.WriteLine("Confirm state table");
            Console.WriteLine("{0} \t {1} \t {2}", "State" ,x,y);

            
            Console.WriteLine("Prints out state table");
            Console.WriteLine("State Table");

        }

    }
}
