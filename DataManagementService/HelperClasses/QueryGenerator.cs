using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataManagementService.Entity;

namespace DataManagementService
{
    public static class QueryGenerator
    {

        /// <summary>
        /// Generates the select query from schema and given conditions (where clauses).
        /// </summary>
        /// <param name="tableSchema">The table schema.</param>
        /// <returns></returns>
        internal static string GenerateSelectQuery(TableSchema tableSchema)
        {
            string selectQuery = "";

            string columnNames = " * ";

            if (tableSchema.ColumnNames != null && tableSchema.ColumnNames.Count > 0)
            {
                columnNames = ConcatNames(tableSchema.ColumnNames);
            }

            string whereClause = GenerateWhereClause(tableSchema.Conditions);

            selectQuery = "select " + columnNames + " from " + tableSchema.TableName + " " + whereClause + ";";

            return selectQuery;
        }

        /// <summary>
        /// Generates the where clause. Two conditions in clause and appended with given conjunction operator in previous condition.
        /// </summary>
        /// <param name="conditions">The conditions.</param>
        /// <returns></returns>
        private static string GenerateWhereClause(List<Condition> conditions)
        {
            string whereClause = " where ";

            if (conditions != null && conditions.Count > 0)
            {
                for (int index = 0; index < conditions.Count; index++)
                {
                    Condition condition = conditions[index];

                    if (index == conditions.Count - 1)
                    {
                        whereClause = whereClause + condition.LeftOperand + " " + GetOperator(condition.ConditionOperator) + " '" + condition.RightOperand + "' ";
                    }
                    else
                    {
                        whereClause = whereClause + condition.LeftOperand + " " + GetOperator(condition.ConditionOperator) + " '" + condition.RightOperand + "' " + GetConjunctionOperator(condition.ConjunctionOperator) + " ";
                    }
                }
            }
            else
            {
                whereClause = "";
            }

            return whereClause;
        }

        /// <summary>
        /// Gets the operator.
        /// </summary>
        /// <param name="op">The op.</param>
        /// <returns></returns>
        private static string GetOperator(Condition.Operator op)
        {
            string opString = "";
            switch (op)
            {
                case Condition.Operator.Equal:
                    opString = " = ";
                    break;
                case Condition.Operator.LessThan:
                    opString = " < ";
                    break;
                case Condition.Operator.LessThanOrEqual:
                    opString = " <= ";
                    break;
                case Condition.Operator.GreaterThan:
                    opString = " > ";
                    break;
                case Condition.Operator.GreaterThanOrEqual:
                    opString = " >= ";
                    break;
            }
            return opString;
        }

        /// <summary>
        /// Gets the conjunction operator.
        /// </summary>
        /// <param name="op">The op.</param>
        /// <returns></returns>
        private static string GetConjunctionOperator(Condition.Conjunction op)
        {
            string opString = "";
            switch (op)
            {
                case Condition.Conjunction.And:
                    opString = " and ";
                    break;
                case Condition.Conjunction.Or:
                    opString = " or ";
                    break;
               
            }
            return opString;
        }

        /// <summary>
        /// Generates the update query.
        /// </summary>
        /// <param name="tableSchema">The table schema.</param>
        /// <returns></returns>
        internal static string GenerateUpdateQuery(TableSchema tableSchema)
        {
            string whereClause = GenerateWhereClause(tableSchema.Conditions);

            if (tableSchema.Values.Count == tableSchema.ColumnNames.Count)
            {
                var setValues = tableSchema.ColumnNames.Zip(tableSchema.Values, ConcatWithEqual);

                string updateQuery = "update " + tableSchema.TableName + " set " + ConcatNames(setValues.ToList<string>()) + " " + whereClause + ";";

                return updateQuery;
            }
            else
            {
                throw new Exception("Number values does not match with number of columns");
            }
        }

        /// <summary>
        /// Concats the with equal.
        /// </summary>
        /// <param name="first">The first.</param>
        /// <param name="sec">The sec.</param>
        /// <returns></returns>
        internal static string ConcatWithEqual(string first, string sec)
        {
            return first + "='" + sec + "'";
        }

        /// <summary>
        /// Generates the insert query.
        /// </summary>
        /// <param name="tableSchema">The table schema.</param>
        /// <returns></returns>
        internal static string GenerateInsertQuery(TableSchema tableSchema)
        {
            string concatedColNames = ConcatNames(tableSchema.ColumnNames);

            // adding single apostrophe to the values
            List<string> apostropheAddedValues = new List<string>();

            foreach (string val in tableSchema.Values)
            {
                apostropheAddedValues.Add("'" + val + "'");
            }

            string concatedValues = ConcatNames(apostropheAddedValues);

            if (tableSchema.Values == null || tableSchema.Values.Count == 0
                || tableSchema.Values.Count == tableSchema.ColumnNames.Count)
            {
                string insertQuery = "";
                if(tableSchema.Values == null || tableSchema.Values.Count == 0)
                    insertQuery = "insert into " + tableSchema.TableName + " values (" + concatedValues + ");";
                else
                    insertQuery = "insert into " + tableSchema.TableName + "(" + concatedColNames + ") values (" + concatedValues + ");";

                return insertQuery;
            }
            else
            {
                throw new Exception("Number of values does not match with number of columns");
            }
        }

        /// <summary>
        /// Concats the names with ','.
        /// </summary>
        /// <param name="names">List of strings.</param>
        /// <returns></returns>
        private static string ConcatNames(List<string> names)
        {
            string concatedNames = "";

            for (int index = 0; index < names.Count; index++)
            {
                string currentName = names[index];

                if (index == names.Count - 1)
                {
                    concatedNames = concatedNames + currentName;
                }
                else
                {
                    concatedNames = concatedNames + currentName + ", ";
                }

            }

            return concatedNames;
        }

        /// <summary>
        /// Generates the delete query.
        /// </summary>
        /// <param name="tableSchema">The table schema. This includes table name and condition to select rows.</param>
        /// <returns></returns>
        internal static string GenerateDeleteQuery(TableSchema tableSchema)
        {
            string whereClause = GenerateWhereClause(tableSchema.Conditions);

            string deleteQuery = "delete from " + tableSchema.TableName + " " + whereClause + " ;";

            return deleteQuery;
        }
    }
}