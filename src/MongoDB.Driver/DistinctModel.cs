﻿/* Copyright 2010-2014 MongoDB Inc.
*
* Licensed under the Apache License, Version 2.0 (the "License");
* you may not use this file except in compliance with the License.
* You may obtain a copy of the License at
*
* http://www.apache.org/licenses/LICENSE-2.0
*
* Unless required by applicable law or agreed to in writing, software
* distributed under the License is distributed on an "AS IS" BASIS,
* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
* See the License for the specific language governing permissions and
* limitations under the License.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson.Serialization;
using MongoDB.Driver.Core.Misc;

namespace MongoDB.Driver
{
    /// <summary>
    /// Model for the distinct command.
    /// </summary>
    public sealed class DistinctModel<T> : IExplainableModel
    {
        // fields
        private readonly string _fieldName;
        private object _filter;
        private TimeSpan? _maxTime;
        private IBsonSerializer<T> _valueSerializer;

        // constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="DistinctModel{T}"/> class.
        /// </summary>
        /// <param name="fieldName">Name of the field.</param>
        public DistinctModel(string fieldName)
        {
            // technically, I think we can have empty field names...
            _fieldName = Ensure.IsNotNull(fieldName, "fieldName");
        }

        // properties
        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        public string FieldName
        {
            get { return _fieldName; }
        }

        /// <summary>
        /// Gets or sets the filter.
        /// </summary>
        public object Filter
        {
            get { return _filter; }
            set { _filter = value; }
        }

        /// <summary>
        /// Gets or sets the maximum time.
        /// </summary>
        public TimeSpan? MaxTime
        {
            get { return _maxTime; }
            set { _maxTime = value; }
        }

        /// <summary>
        /// Gets or sets the value serializer.
        /// </summary>
        public IBsonSerializer<T> ValueSerializer
        {
            get { return _valueSerializer; }
            set { _valueSerializer = value; }
        }
    }
}