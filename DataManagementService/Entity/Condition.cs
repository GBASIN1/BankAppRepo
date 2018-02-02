using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;


namespace DataManagementService.Entity
{
    /// <summary>
    /// This class represents one 'where clause' in SQL statement.
    /// To represent where clause we need to provide Left Operand, Right Operand, and Condition operator.
    /// If there are mutiple conditions in where cluase then we need to provide Conjunction operator ('and' or 'or').
    /// </summary>
  
    public class Condition
    {
        
        public enum Operator { LessThan, GreaterThan, LessThanOrEqual, GreaterThanOrEqual, Equal }

        public enum Conjunction { And, Or }
   
        public string LeftOperand;
  
        public string RightOperand;
   
        public Operator ConditionOperator;
   
        public Conjunction ConjunctionOperator;
    }
}
