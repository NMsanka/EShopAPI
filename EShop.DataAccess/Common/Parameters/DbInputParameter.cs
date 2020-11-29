using System;
using System.Data;

namespace EShop.Data.Common.Parameters
{
    internal class DbInputParameter
    {
        /// <summary>
        /// The name
        /// </summary>
        private string name;
        /// <summary>
        /// The value
        /// </summary>
        private object value;
        /// <summary>
        /// The parameter direction
        /// </summary>
        private ParameterDirection parameterDirection;
        
        /// <summary>
        /// The data type
        /// </summary>
        private DbType dataType;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        internal string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        /// <value>
        /// The value.
        /// </value>
        internal object Value
        {
            get
            {
                return value;
            }
            set
            {
                this.value = value;
            }
        }

        /// <summary>
        /// Gets or sets the parameter direction.
        /// </summary>
        /// <value>
        /// The parameter direction.
        /// </value>
        internal ParameterDirection ParameterDirection
        {
            get
            {
                return parameterDirection;
            }
            set
            {
                parameterDirection = value;
            }
        }

        /// <summary>
        /// Gets or sets the type of the data.
        /// </summary>
        /// <value>
        /// The type of the data.
        /// </value>
        public DbType DataType { get => dataType; set => dataType = value; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbInputParameter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        internal DbInputParameter(string name, object value)
        {
            this.name = name;
            this.value = value ?? (object)DBNull.Value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbInputParameter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="value">The value.</param>
        internal DbInputParameter(string name, DbType dataType, object value)
        {
            this.name = name;
            this.value = value ?? (object)DBNull.Value;
            this.dataType = dataType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbInputParameter"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="dataType">Type of the data.</param>
        /// <param name="value">The value.</param>
        /// <param name="parameterDirection">The parameter direction.</param>
        internal DbInputParameter(string name, DbType dataType, object value, ParameterDirection parameterDirection)
        {
            this.name = name;
            this.value = value ?? (object)DBNull.Value;
            this.dataType = dataType;
            this.parameterDirection = parameterDirection;
        }
    }
}
