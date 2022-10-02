using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreQuery
{
    /// <summary>
    /// Clase base para repositorios de consultas
    /// </summary>
    public abstract class BaseQueryRepository
    {
        /// <summary>
        /// Cadena de conexión 
        /// </summary>
        protected string _connectionString = string.Empty;

        /// <summary>
        /// Constructor base
        /// </summary>
        /// <param name="connectionString">Cadena de conexión</param>
        public BaseQueryRepository(string connectionString = default)
        {
            _connectionString = string.IsNullOrWhiteSpace(connectionString) ? Environment.GetEnvironmentVariable("DB_CONNECTION") : connectionString;
        }

        /// <summary>
        /// Crea el contexto apra ejecutar una o varias consultas a base de datos y devolver un dato
        /// </summary>
        /// <typeparam name="TResult">Valor de datos devueltos</typeparam>
        /// <param name="func">función delegada que recibe el parámetro de conección a base de datos</param>
        /// <returns>El valor devuelto por la función delegada</returns>
        protected TResult ExecutionContext<TResult>(Func<MySqlConnection, TResult> func)
        {

            using var connection = new MySqlConnection(_connectionString);

            connection.Open();

            return func(connection);

        }


        /// <summary>
        /// Se encarga de obtener la consulta SQL para aplicar una condición sobre un listado de valores. Si el listado es null retorna 0
        /// </summary>
        /// <param name="column">Nombre de la columna</param>
        /// <param name="param">Nombre del parámotr (Incluida la arroba</param>
        /// <param name="list">Listado de valores. debe ser null o vacío en caso de que no queira que se tome en cuenta</param>
        /// <param name="boolOperator">Operador booleano</param>
        /// <param name="defaultValue">Valor por defecto en caso que el listado sea nulo o vacío</param>
        /// <returns> Si list tiene valores, "{boolOperator} {column} IN {param}", Caso contrario "{defaultValue}".</returns>
        protected string GetOptionalEnumerableInSql(string column, string param, IList<int> list, string boolOperator = "AND", string defaultValue = " ")
        {
            return (list is null || list?.Count == 0) ? defaultValue : string.Format("{0} {1} IN {2}", boolOperator, column, param);
        }
    }
}