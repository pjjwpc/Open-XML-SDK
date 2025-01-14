﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;

namespace DocumentFormat.OpenXml.Packaging
{
    /// <summary>
    /// Represents the Open XML package validation events.
    /// </summary>
    [Serializable]
    [Obsolete(ObsoleteAttributeMessages.ObsoleteV1ValidationFunctionality, false)]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class OpenXmlPackageValidationEventArgs : EventArgs
    {
        [NonSerialized]
        private readonly object _sender;

        private string? _message;

        [NonSerialized]
        private OpenXmlPart? _subPart;

        [NonSerialized]
        private OpenXmlPart? _part;

        internal OpenXmlPackageValidationEventArgs(object sender)
        {
            _sender = sender;
        }

        internal object Sender => _sender;

        /// <summary>
        /// Gets or sets the message string of the event.
        /// </summary>
        public string Message
        {
            get
            {
                if (_message is null && MessageId is not null)
                {
                    return ExceptionMessages.ResourceManager.GetString(MessageId) ?? string.Empty;
                }
                else
                {
                    return _message ?? string.Empty;
                }
            }

            set
            {
                _message = value;
            }
        }

        /// <summary>
        /// Gets the class name of the part.
        /// </summary>
        public string? PartClassName { get; internal set; }

        /// <summary>
        /// Gets the part that caused the event.
        /// </summary>
        public OpenXmlPart? SubPart
        {
            get { return _subPart; }
            internal set { _subPart = value; }
        }

        /// <summary>
        /// Gets the part in which to process the validation.
        /// </summary>
        public OpenXmlPart? Part
        {
            get { return _part; }
            internal set { _part = value; }
        }

        internal string? MessageId { get; set; }

        /// <summary>
        /// Gets or sets the DataPartReferenceRelationship that caused the event.
        /// </summary>
        internal DataPartReferenceRelationship? DataPartReferenceRelationship { get; set; }
    }
}
