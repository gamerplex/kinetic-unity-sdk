﻿using Solana.Unity.Programs.Clients;
using Solana.Unity.Programs.Utilities;
using System.Diagnostics;

namespace Solana.Unity.Programs.Models.NameService
{
    /// <summary>
    /// Represents a naming record.
    /// </summary>
    [DebuggerDisplay("Type: {Type}, Address: {AccountAddress}")]
    public class NameRecord : RecordBase
    {
        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="header">The record header.</param>
        /// <param name="type">The type of the name record.</param>
        public NameRecord(RecordHeader header, RecordType type) : base(header, type)
        {
        }

        /// <summary>
        /// The storage of this name record.
        /// </summary>
        public byte[] Value { get; set; }

        /// <inheritdoc />
        public override object GetValue() => Value;

        /// <summary>
        /// Deserialization method for a name record account.
        /// </summary>
        /// <param name="input">The raw data.</param>
        /// <returns>The deserialized record.</returns>
        public static NameRecord Deserialize(byte[] input)
        {
            var header = RecordHeader.Deserialize(input);

            var recordType = header.ParentName == NameServiceClient.SolTLD ? RecordType.NameRecord : RecordType.TwitterRecord;

            var res = new NameRecord(header, recordType);

            res.Value = input.Slice(96);

            return res;
        }
    }
}
