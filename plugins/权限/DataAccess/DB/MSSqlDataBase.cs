using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Data.SqlClient;

using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;

namespace DataAccess
{
    ///// <summary>
    ///// SqlServer�����ݿ������(û��)
    ///// </summary>
    //public class MSSqlDataBase : InterfaceDataBase 
    //{
    //    private SqlConnection _connection;
    //    public MSSqlDataBase(string strConnectioin)
    //    {
    //        _connection = new SqlConnection(strConnectioin);
    //    }
    //    /// <summary>
    //    ///����һ���Ѻ���SqlParameter�����SqlCommand
    //    /// </summary>
    //    /// <paramKey colName="storedProcNameOrSqlString">�洢���������������SQL��ѯ�ַ���</paramKey>
    //    /// <paramKey colName="parameters">Array of IDataParameter objects</paramKey>
    //    /// <paramKey colName="type">�Ǵ洢���̻��ǲ�ѯ�ִ�</paramKey>
    //    /// <returns>����SqlCommand������װ�����</returns>
    //    /// 
    //    private SqlCommand BuildQueryCommand(string storedProcNameOrSqlString, Dictionary<string, object> parameters, CommandType type)
    //    {
    //        SqlCommand command = new SqlCommand(storedProcNameOrSqlString, _connection);
    //        command.CommandType = type;
    //        if (parameters != null && parameters.Count != 0)
    //        {
    //            foreach (KeyValuePair<string, object> kvp in parameters)
    //            {
    //                SqlParameter para = new SqlParameter(kvp.Key, kvp.Value);
    //                command.Parameters.Add(para);
    //            }    
    //        }
    //        return command;
    //    }
 
    //    #region InterfaceDataBase ��Ա
    //    /// <summary>
    //    /// ͨ��sql��䷵��DataTable
    //    /// </summary>
    //    /// <paramKey colName="strSqlDel"></paramKey>
    //    /// <returns></returns>
    //    DataTable InterfaceDataBase.RunSqlQuery(string strSql)
    //    {
    //        SqlDataAdapter adapter = new SqlDataAdapter(strSql, _connection);
    //        DataTable dataTable = new DataTable();
    //        try
    //        {
    //            _connection.Open();
    //            adapter.Fill(dataTable);
    //        }
    //        finally
    //        {
    //            _connection.Close();
    //        }
    //        return dataTable;
    //    }

    //    DataTable InterfaceDataBase.RunSqlQuery(string strSql, Dictionary<string, object> parameters)
    //    {
    //        DataTable dataTable = new DataTable();
    //        try
    //        {
    //            _connection.Open();
    //            SqlDataAdapter sqlDA = new SqlDataAdapter();
    //            sqlDA.SelectCommand = BuildQueryCommand(strSql, parameters, CommandType.Text);
    //            sqlDA.Fill(dataTable);
    //        }
    //        finally
    //        {
    //            _connection.Close();
    //        }
    //        return dataTable;
    //    }

    //    int InterfaceDataBase.RunSqlNoneQuery(string strSql)
    //    {
    //        int result;
    //        try
    //        {
    //            _connection.Open();
    //            SqlCommand command = new SqlCommand(strSql, _connection);
    //            result = command.ExecuteNonQuery();
    //        }
    //        finally
    //        {
    //            _connection.Close();
    //        }
    //        return result;
    //    }

    //    int InterfaceDataBase.RunSqlNoneQuery(string strSql, Dictionary<string, object> parameters)
    //    {
    //        int result;
    //        try
    //        {
    //            _connection.Open();
    //            SqlCommand command = BuildQueryCommand(strSql, parameters, CommandType.Text);
    //            result = command.ExecuteNonQuery(); 
    //        }
    //        finally
    //        {
    //            _connection.Close();
    //        }
    //        return result;
    //    }


    //    int InterfaceDataBase.RunSqlNoneQuery(string strSql, DbTransaction trans)
    //    {
    //        int result;
    //        try
    //        {
    //            SqlTransaction sqlTrans = (SqlTransaction)trans;
    //            SqlCommand command = new SqlCommand(strSql, sqlTrans.Connection);
    //            command.Transaction = sqlTrans;
    //            result = command.ExecuteNonQuery();
    //        }
    //        finally
    //        { 
    //        }
    //        return result;
    //    }

    //    int InterfaceDataBase.RunSqlNoneQuery(string strSql, Dictionary<string, object> parameters, DbTransaction trans)
    //    {
    //        int result;
    //        try
    //        {
      
    //            SqlCommand command = BuildQueryCommand(strSql, parameters, CommandType.Text);
    //            command.Transaction = (SqlTransaction)trans;
    //            command.Connection = ((SqlTransaction)trans).Connection;
    //            result = command.ExecuteNonQuery();
    //        }
    //        finally
    //        {
    //            _connection.Close();
    //        }
    //        return result;
    //    }
    //    #endregion


    //    #region IDisposable ��Ա

    //    void IDisposable.Dispose()
    //    {
    //        //�ͷ��й���Դ
    //        if (_connection != null)
    //        {
    //            _connection.Dispose();
    //        }
    //    }

    //    #endregion


    //    #region InterfaceDataBase ��Ա


    //    DbTransaction InterfaceDataBase.GetTransction()
    //    {
    //        if (_connection != null)
    //        {
    //            if (_connection.State == ConnectionState.Closed)
    //            {
    //                _connection.Open();
    //            }
    //            return (DbTransaction)_connection.BeginTransaction();
    //        }
    //        return null;
    //    }

    //    #endregion

    //    #region InterfaceDataBase ��Ա


    //    DataTable InterfaceDataBase.RunSqlQuery(string strSql, DbTransaction trans)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    DataTable InterfaceDataBase.RunSqlQuery(string strSql, Dictionary<string, object> parameters, DbTransaction trans)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    #endregion
    //}
    ///// <summary>
    ///// Orcale�����ݿ������ (û��)
    ///// </summary>
    //public class OracleDataBase : InterfaceDataBase
    //{
    //    private OracleConnection   _connection;
    //    public OracleDataBase(string strConnectioin)
    //    {
    //        _connection = new OracleConnection(strConnectioin);
    //    }
    //    /// <summary>
    //    ///����һ���Ѻ���OracleCommand�����OracleCommand
    //    /// </summary>
    //    /// <paramKey colName="storedProcNameOrSqlString">�洢���������������SQL��ѯ�ַ���</paramKey>
    //    /// <paramKey colName="parameters">Array of IDataParameter objects</paramKey>
    //    /// <paramKey colName="type">�Ǵ洢���̻��ǲ�ѯ�ִ�</paramKey>
    //    /// <returns>����SqlCommand������װ�����</returns>
    //    /// 
    //    private OracleCommand BuildQueryCommand(string storedProcNameOrSqlString, Dictionary<string, object> parameters, CommandType type)
    //    {
    //        storedProcNameOrSqlString = convertSql(storedProcNameOrSqlString);
    //        System.Data.OracleClient.OracleCommand command = new OracleCommand(storedProcNameOrSqlString,_connection);
    //        command.CommandType = type;

    //        if (parameters != null && parameters.Count != 0)
    //        {
    //            foreach (KeyValuePair<string, object> kvp in parameters)
    //            {
    //                OracleParameter para = new OracleParameter(kvp.Key, kvp.Value);
    //                command.Parameters.Add(para);
    //            }
    //        }
    //        return command;
    //    }

    //    #region InterfaceDataBase ��Ա
    //    /// <summary>
    //    /// ͨ��sql��䷵��DataTable
    //    /// </summary>
    //    /// <paramKey colName="strSqlDel"></paramKey>
    //    /// <returns></returns>
    //    DataTable InterfaceDataBase.RunSqlQuery(string strSql)
    //    {
    //        OracleDataAdapter adapter = new OracleDataAdapter(convertSql(strSql), _connection);
    //        DataTable dataTable = new DataTable();
    //        try
    //        {
    //            if (_connection.State != ConnectionState.Open)
    //            {
    //                _connection.Open();
    //            }
    //            adapter.Fill(dataTable);
    //        }
    //        finally
    //        {
    //           // _connection.Close();
    //        }
    //        return dataTable;
    //    }

    //    DataTable InterfaceDataBase.RunSqlQuery(string strSql, Dictionary<string, object> parameters)
    //    {
    //        DataTable dataTable = new DataTable();
    //        try
    //        {
    //            if (_connection.State != ConnectionState.Open)
    //            {
    //                _connection.Open();
    //            }
    //            OracleDataAdapter adapter = new OracleDataAdapter(convertSql(strSql), _connection);
    //            adapter.SelectCommand = BuildQueryCommand(strSql, parameters, CommandType.Text);
    //            adapter.Fill(dataTable);
    //        }
    //        finally
    //        {
               
    //        }
    //        return dataTable;
    //    }

    //    int InterfaceDataBase.RunSqlNoneQuery(string strSql)
    //    {
    //        int result;
    //        try
    //        {
    //            _connection.Open();
    //            OracleCommand command = new OracleCommand(convertSql(strSql), _connection);
    //            result = command.ExecuteNonQuery();
    //        }
    //        finally
    //        {
    //            _connection.Close();
    //        }
    //        return result;
    //    }

 


    //    int InterfaceDataBase.RunSqlNoneQuery(string strSql, Dictionary<string, object> parameters)
    //    {
    //        int result;
    //        try
    //        {
    //            if (_connection.State != ConnectionState.Open)
    //            {
    //                _connection.Open();
    //            }
    //            OracleCommand command = BuildQueryCommand(convertSql(strSql), parameters, CommandType.Text);
    //            result = command.ExecuteNonQuery();
    //        }
    //        finally
    //        {
    //            //_connection.Close();
    //        }
    //        return result;
    //    }
    //    int InterfaceDataBase.RunSqlNoneQuery(string strSql, DbTransaction trans)
    //    {
    //        int result;
    //        try
    //        {
    //            OracleTransaction oraTrans = (OracleTransaction)trans;
    //            OracleCommand command = new OracleCommand(convertSql(strSql),oraTrans.Connection,oraTrans);
    //            result = command.ExecuteNonQuery();
    //        }
    //        finally
    //        {
 
    //        }
    //        return result;
    //    }

    //    int InterfaceDataBase.RunSqlNoneQuery(string strSql, Dictionary<string, object> parameters, DbTransaction trans)
    //    {
    //        int result;
    //        try
    //        {
    //            OracleTransaction oraTrans = (OracleTransaction)trans;
    //            OracleCommand command = BuildQueryCommand(convertSql(strSql), parameters, CommandType.Text);
    //            command.Transaction = oraTrans;
    //            command.Connection = oraTrans.Connection;
                
    //            result = command.ExecuteNonQuery();
    //        }
    //        finally
    //        {
    //        }
    //        return result;
    //    }
    //    #endregion
    //    private string convertSql(string sql)
    //    {
    //        return sql.Replace("@", ":");
    //    }

    //    #region IDisposable ��Ա

    //    void IDisposable.Dispose()
    //    {
    //        //�ͷ��й���Դ
    //        if (_connection != null)
    //        {
    //            _connection.Dispose();
    //        }
    //    }

    //    #endregion


    //    #region InterfaceDataBase ��Ա


    //    DbTransaction InterfaceDataBase.GetTransction()
    //    {
    //        //throw new NotImplementedException();
    //        if (_connection != null)
    //        {
    //            if (_connection.State == ConnectionState.Closed)
    //            {
    //                _connection.Open();
    //            }
    //            return (DbTransaction)_connection.BeginTransaction();
    //        }
    //        return null;
    //    }

    //    #endregion

    //    #region InterfaceDataBase ��Ա
    //    DataTable InterfaceDataBase.RunSqlQuery(string strSql, DbTransaction trans)
    //    {
    //        OracleTransaction oraTrans = (OracleTransaction)trans;
    //        OracleDataAdapter adapter = new OracleDataAdapter(convertSql(strSql), oraTrans.Connection);
    //        DataTable dataTable = new DataTable();
    //        try
    //        {
    //            adapter.SelectCommand.Connection = oraTrans.Connection;
    //            adapter.SelectCommand.Transaction = oraTrans;
    //            adapter.Fill(dataTable);
    //        }
    //        finally
    //        {
    //            // _connection.Close();
    //        }
    //        return dataTable;
    //    }

    //    DataTable InterfaceDataBase.RunSqlQuery(string strSql, Dictionary<string, object> parameters, DbTransaction trans)
    //    {
    //        DataTable dataTable = new DataTable();
    //        try
    //        {
    //            OracleTransaction oraTrans = (OracleTransaction)trans;
    //            OracleDataAdapter adapter = new OracleDataAdapter(convertSql(strSql), oraTrans.Connection);
    //            adapter.SelectCommand = BuildQueryCommand(strSql, parameters, CommandType.Text);
    //            adapter.SelectCommand.Transaction = oraTrans;
    //            adapter.SelectCommand.Connection = oraTrans.Connection; 
    //            adapter.Fill(dataTable);
    //        }
    //        finally
    //        {

    //        }
    //        return dataTable;
    //    }

    //    #endregion
    //}
    /// <summary>
    /// OleDb�Ĳ�����
    /// </summary>
    public class OleDbDataBase : InterfaceDataBase
    {
        private System.Data.OleDb.OleDbConnection _connection;
        public OleDbDataBase(string strConnectioin)
        {
            _connection = new System.Data.OleDb.OleDbConnection(strConnectioin);
        }
        /// <summary>
        ///����һ���Ѻ���OracleCommand�����OracleCommand
        /// </summary>
        /// <paramKey colName="storedProcNameOrSqlString">�洢���������������SQL��ѯ�ַ���</paramKey>
        /// <paramKey colName="parameters">Array of IDataParameter objects</paramKey>
        /// <paramKey colName="type">�Ǵ洢���̻��ǲ�ѯ�ִ�</paramKey>
        /// <returns>����SqlCommand������װ�����</returns>
        /// 
        private System.Data.OleDb.OleDbCommand BuildQueryCommand(string storedProcNameOrSqlString, Dictionary<string, object> parameters, CommandType type)
        {
            storedProcNameOrSqlString = convertSql(storedProcNameOrSqlString);
            OleDbCommand command = new OleDbCommand();
            command.CommandType = type;
            //command.CommandText = storedProcNameOrSqlString;
            #region ����parameter ,,ת��sql���
            int start = 0;
            bool startNow = false;
            int end = 0;
            string paramKey;
            string strSql = storedProcNameOrSqlString;
           // string strSql2 = storedProcNameOrSqlString;
            for (int i = 0; i < strSql.Length; i++)
            {
                if (strSql[i].Equals('@'))
                {
                    start = i;
                    startNow = true;
                }
                if (startNow)
                {
                    if ( strSql[i].Equals(' ') || strSql[i].Equals('|')
                        || (i == strSql.Length - 1) || strSql[i].Equals(',')
                        ||strSql[i].Equals(')') || strSql[i].Equals('='))
                    {
                        end = i;
                        if (i == strSql.Length - 1 && !strSql[i].Equals(')'))
                        {
                            paramKey = strSql.Substring(start + 1, end - start ).Trim();
                        }
                        else
                        {
                            paramKey = strSql.Substring(start + 1, end - start - 1).Trim();
                        }
                        //����param�� sql����ֵ
                        object value = DBNull.Value;
                        parameters.TryGetValue(paramKey, out value);
                        //OracleParameter para = new OracleParameter(kvp.Key, kvp.Value);
                        OleDbParameter para = new OleDbParameter(paramKey, value);
                        command.Parameters.Add(para);
                        int tmp = storedProcNameOrSqlString.IndexOf("@" + paramKey);
                        if (tmp > -1)
                        {
                            storedProcNameOrSqlString = storedProcNameOrSqlString.Remove(tmp, paramKey.Length + 1);

                            storedProcNameOrSqlString = storedProcNameOrSqlString.Insert(tmp, "?");
                        }
                        startNow = false;
                    }
                }
            }
            #endregion
            command.CommandText = storedProcNameOrSqlString;
            command.Connection = _connection;
            return command;
        }

        #region InterfaceDataBase ��Ա
        /// <summary>
        /// ͨ��sql��䷵��DataTable
        /// </summary>
        /// <paramKey colName="strSqlDel"></paramKey>
        /// <returns></returns>
        DataTable InterfaceDataBase.RunSqlQuery(string strSql)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter(convertSql(strSql), _connection);
            DataTable dataTable = new DataTable();
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                adapter.Fill(dataTable);
            }
            finally
            {
                _connection.Close();
            }
            return dataTable;
        }

        DataTable InterfaceDataBase.RunSqlQuery(string strSql, Dictionary<string, object> parameters)
        {
            DataTable dataTable = new DataTable();
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                OleDbDataAdapter adapter = new OleDbDataAdapter(convertSql(strSql), _connection);
                adapter.SelectCommand = BuildQueryCommand(strSql, parameters, CommandType.Text);
                adapter.Fill(dataTable);
            }
            finally
            {
                _connection.Close();
            }
            return dataTable;
        }

        int InterfaceDataBase.RunSqlNoneQuery(string strSql)
        {
            int result;
            try
            {
                _connection.Open();
                OleDbCommand command = new OleDbCommand(convertSql(strSql), _connection);
                result = command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
            return result;
        }




        int InterfaceDataBase.RunSqlNoneQuery(string strSql, Dictionary<string, object> parameters)
        {
            int result;
            try
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                OleDbCommand command = BuildQueryCommand(convertSql(strSql), parameters, CommandType.Text);
                result = command.ExecuteNonQuery();
            }
            finally
            {
                //_connection.Close();
            }
            return result;
        }
        int InterfaceDataBase.RunSqlNoneQuery(string strSql, DbTransaction trans)
        {
            int result;
            try
            {
                OleDbTransaction oraTrans = (OleDbTransaction)trans;
                OleDbCommand command = new OleDbCommand(convertSql(strSql), oraTrans.Connection, oraTrans);
                result = command.ExecuteNonQuery();
            }
            finally
            {

            }
            return result;
        }

        int InterfaceDataBase.RunSqlNoneQuery(string strSql, Dictionary<string, object> parameters, DbTransaction trans)
        {
            int result;
            try
            {
                OleDbTransaction oraTrans = (OleDbTransaction)trans;
                OleDbCommand command = BuildQueryCommand(convertSql(strSql), parameters, CommandType.Text);
                command.Transaction = oraTrans;
                command.Connection = oraTrans.Connection;
                
                result = command.ExecuteNonQuery();
             
            }
            finally
            {
            }
            return result;
        }
        #endregion
        private string convertSql(string sql)
        {
            //return sql.Replace("@", ":");
            //ȥ������ @id
            return sql;
        }

        #region IDisposable ��Ա

        void IDisposable.Dispose()
        {
            //�ͷ��й���Դ
            if (_connection != null)
            {
                _connection.Dispose();
            }
        }

        #endregion


        #region InterfaceDataBase ��Ա


        DbTransaction InterfaceDataBase.GetTransction()
        {
            //throw new NotImplementedException();
            if (_connection != null)
            {
                if (_connection.State == ConnectionState.Closed)
                {
                    _connection.Open();
                }
                return (DbTransaction)_connection.BeginTransaction();
            }
            return null;
        }

        #endregion

        #region InterfaceDataBase ��Ա
        DataTable InterfaceDataBase.RunSqlQuery(string strSql, DbTransaction trans)
        {
            OleDbTransaction oraTrans = (OleDbTransaction)trans;
            OleDbDataAdapter adapter = new OleDbDataAdapter(convertSql(strSql), oraTrans.Connection);
            DataTable dataTable = new DataTable();
            try
            {
                adapter.SelectCommand.Connection = oraTrans.Connection;
                adapter.SelectCommand.Transaction = oraTrans;
                adapter.Fill(dataTable);
            }
            finally
            {
                //_connection.Close();
            }
            return dataTable;
        }

        DataTable InterfaceDataBase.RunSqlQuery(string strSql, Dictionary<string, object> parameters, DbTransaction trans)
        {
            DataTable dataTable = new DataTable();
            try
            {
                OleDbTransaction oraTrans = (OleDbTransaction)trans;
                OleDbDataAdapter adapter = new OleDbDataAdapter(convertSql(strSql), oraTrans.Connection);
                adapter.SelectCommand = BuildQueryCommand(strSql, parameters, CommandType.Text);
                adapter.SelectCommand.Transaction = oraTrans;
                adapter.SelectCommand.Connection = oraTrans.Connection;
                adapter.Fill(dataTable);
            }
            finally
            {

            }
            return dataTable;
        }

        #endregion
    }
}
 