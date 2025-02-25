
using Newtonsoft.Json;

namespace Solana.Unity.Rpc.Models
{
    /// <summary>
    /// Represents the signature status information.
    /// </summary>
    public class SignatureStatusInfo
    {
        /// <summary>
        /// The slot the transaction was processed in.
        /// </summary>
        public ulong Slot { get; set; }

        /// <summary>
        /// The number of blocks since signature confirmation.
        /// </summary>
        public ulong? Confirmations { get; set; }

        /// <summary>
        /// The error if the transaction failed, null if it succeeded.
        /// </summary>
        [JsonProperty("err")]
        public TransactionError Error { get; set; }

        /// <summary>
        /// The transaction's cluster confirmation status, either "processed", "confirmed" or "finalized".
        /// </summary>
        public string ConfirmationStatus { get; set; }

        /// <summary>
        /// Memo associated with the transaction, null if no memo is present.
        /// </summary>
        public string Memo { get; set; }

        /// <summary>
        /// The transaction signature as base-58 encoded string.
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// Estimated production time as Unix timestamp, null if not available.
        /// </summary>
        public ulong? BlockTime { get; set; }
    }
}