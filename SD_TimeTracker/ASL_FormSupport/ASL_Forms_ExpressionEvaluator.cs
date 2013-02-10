using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using ASL;

namespace ASL.Forms
{
  static public class ExpressionEvaluator
  {
    static public double EvaluateExpression(ControlTag ctag, object dataContent)
    {
      Stack<string> opStack = new Stack<string>();
      Stack<string> valStack = new Stack<string>();
      string[] oprec = new string[] { ";", ")", "(", "+", "-", "*", "/", "^" };
      char[] oprecchar = new char[] { ';', ')', '(', '+', '-', '*', '/', '^' };
      try
      {
        List<string> items = new List<string>();

        {
          string expression = ctag.FieldDef.ComputeSource + ";";
          int k0 = 0;
          int k1;
          while (k0 < expression.Length)
          {
            k1 = expression.IndexOfAny(oprecchar, k0);
            if (k1 < k0) break;
            if (k1 > k0)
            {
              string s = expression.Substring(k0, k1 - k0).Trim();
              if (s != string.Empty) items.Add(s);
            }
            items.Add(expression.Substring(k1, 1));
            k0 = k1 + 1;
          }
        }

        opStack.Push(";");
        int ix = 0;
        while (opStack.Count > 0)
        {
          string item = items[ix++];

          if (item == string.Empty) continue;

          if (item == "(")
          {
            opStack.Push(item);
            continue;
          }

          int precedence = Array.IndexOf(oprec, item);
          if (precedence == -1)
          {
            valStack.Push(item);
          }
          else
          {
            string topOp = opStack.Peek();
            int topPrecedence = Array.IndexOf(oprec, topOp);
            if (precedence > topPrecedence)
            {
              opStack.Push(item);
            }
            else
            {
              if (item == ")" && topOp == "(")
              {
                opStack.Pop();
              }
              else if (item == ";" && topOp == ";")
              {
                return Convert.ToDouble(valStack.Pop());
              }
              else
              {

                //string s = string.Format("({2} {1} {0})", valStack.Pop(), opStack.Pop(), valStack.Pop());
                valStack.Push(EvaluateTerm(dataContent, opStack.Pop(), valStack.Pop(), valStack.Pop()));
                ix--;
              }
            }
          }
        }
        throw new AppEx("Syntax error: " + ctag.FieldDef.ComputeSource);
      }
      catch (Exception exc)
      {
        throw new AppEx(exc, "Error computing value: " + ctag.FieldDef.ComputeSource);
      }
    }

    static private string EvaluateTerm(object dataContent, string op, string operand2, string operand1)
    {
      double v1;
      double v2;
      Type dataType = dataContent.GetType();
      object[] zeroIndex = new object[0];
      {
        if (!double.TryParse(operand1, out v1))
        {
          PropertyInfo propInfo = dataType.GetProperty(
              operand1, BindingFlags.Instance | BindingFlags.Public);
          if (propInfo == null) return "***ERROR-1";
          object op1 = propInfo.GetValue(dataContent, zeroIndex);
          v1 = Convert.ToDouble(op1);
        }
      }
      {
        if (!double.TryParse(operand2, out v2))
        {
          PropertyInfo propInfo = dataType.GetProperty(
              operand2, BindingFlags.Instance | BindingFlags.Public);
          if (propInfo == null) return "***ERROR-2";
          object op2 = propInfo.GetValue(dataContent, zeroIndex);
          v2 = Convert.ToDouble(op2);
        }
      }

      double vx;
      switch (op)
      {
        case "+":
          vx = v1 + v2;
          break;
        case "-":
          vx = v1 - v2;
          break;
        case "*":
          vx = v1 * v2;
          break;
        case "/":
          vx = v1 / v2;
          break;
        case "^":
          vx = Math.Pow(v1, v2);
          break;
        default:
          vx = 0;
          break;
      }
      return vx.ToString();
    }
  }
}
