﻿using DungLH.Util.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DungLH.Util.CommonLogging;

namespace AAS.DAO.Sql
{
    partial class SqlExecute : EntityBase
    {
        protected const int MAX_IN_CLAUSE_SIZE = 1000;
        protected const string IN_ANCHOR = "{IN_CLAUSE}";       

        public bool Execute(string sql, params object[] parameters)
        {
            bool result = false;
            try
            {
                if (!String.IsNullOrEmpty(sql))
                {
                    using (var ctx = new Base.AppContext())
                    {
                        ctx.Database.ExecuteSqlCommand(sql, parameters);
                        result = true;
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                LogSystem.Error("sql: " + sql + LogUtil.TraceData("parameters:", parameters));
                result = false;
            }
            return result;
        }

        public bool Execute(List<string> sqls)
        {
            bool result = false;
            string sql = "";
            try
            {
                if (sqls != null && sqls.Count > 0)
                {
                    StringBuilder sqlBuilder = new StringBuilder();
                    foreach (string s in sqls)
                    {
                        if (!string.IsNullOrWhiteSpace(s))
                        {
                            sqlBuilder.Append(string.Format("{0};", s));
                        }
                    }

                    string tmp = sqlBuilder.ToString();

                    if (!string.IsNullOrWhiteSpace(tmp))
                    {
                        sql = string.Format("BEGIN {0} END;", tmp);
                        using (var ctx = new Base.AppContext())
                        {
                            ctx.Database.ExecuteSqlCommand(sql);
                            result = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                LogSystem.Error("sql: " + sql);
                result = false;
            }
            return result;
        }
        
        public List<RAW> GetSql<RAW>(string sql, params object[] parameters)
        {
            List<RAW> result = null;
            try
            {
                if (!String.IsNullOrEmpty(sql))
                {
                    using (var ctx = new Base.AppContext())
                    {
                        result = ctx.Database.SqlQuery<RAW>(sql, parameters).ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error(ex);
                LogSystem.Error("sql: " + sql + LogUtil.TraceData("parameters:", parameters));
                result = null;
            }
            return result;
        }

        public RAW GetSqlSingle<RAW>(string sql, params object[] parameters)
        {
            RAW result = default(RAW);
            try
            {
                if (!String.IsNullOrEmpty(sql))
                {
                    using (var ctx = new Base.AppContext())
                    {
                        result = ctx.Database.SqlQuery<RAW>(sql, parameters).FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                LogSystem.Error("sql: " + sql + LogUtil.TraceData("parameters:", parameters));
                LogSystem.Error(ex);
                result = default(RAW);
            }
            return result;
        }

        /// <summary>
        /// Tra ve chuoi string co dang: IN (id1, id2, ...) or IN (id1001, id1002, ...)
        /// Luu y: trong menh de IN ko qua 1000 phan tu
        /// </summary>
        /// <param name="ids"></param>
        /// <returns></returns>
        public string AddInClause(List<long> elements, string query, string property)
        {
            string inClause;
            if (IsNotNullOrEmpty(elements))
            {
                inClause = "(" + property + " IN (";
                int size = elements.Count;
                int i = 0;
                do
                {
                    size--;
                    if (++i == MAX_IN_CLAUSE_SIZE)
                    {
                        inClause += elements[size] + ")";
                        if (size > 0)
                        {
                            inClause += " OR " + property + " IN (";
                        }
                        i = 0;
                    }
                    else
                    {
                        inClause += elements[size] + ",";
                    }
                } while (size > 0);
                inClause = inClause.Substring(0, inClause.Length - 1) + "))";
            }
            else
            {
                inClause = " 1 = 0 ";
            }
            return query.Replace(IN_ANCHOR, inClause);
        }

        /**
         * Bo sung menh de NOT IN trong cau truy van
         */
        public string AddNotInClause(List<long> elements, string query, string property)
        {
            string notInClause;

            if (IsNotNullOrEmpty(elements))
            {
                notInClause = "(" + property + " NOT IN (";
                int size = elements.Count;
                int i = 0;
                do
                {
                    size--;
                    if (++i == MAX_IN_CLAUSE_SIZE)
                    {
                        notInClause = elements[size] + ")";
                        if (size > 0)
                        {
                            notInClause += " AND " + property + " NOT IN (";
                        }
                        i = 0;
                    }
                    else
                    {
                        notInClause += elements[size] + ",";
                    }
                } while (size > 0);
                notInClause = notInClause.Substring(0, notInClause.Length - 1) + "))";
            }
            else
            {
                notInClause = " 1 = 1 ";
            }
            return query.Replace(IN_ANCHOR, notInClause);
        }

    }
}
