using System;
using System.Runtime.Serialization;

namespace Intelsoft.Niis.Ibd.ReceiveStatusService.Contract.Contracts
{
    /// <summary>
    ///     
    /// </summary>
    [DataContract(Namespace = Globals.EmptyNamespace)]
    public class IdbDataProcessingResponse
    {
        /// <summary>
        /// Gets or sets the idb response identifier.
        /// </summary>
        /// <value>
        /// The idb response identifier.
        /// </value>
        [DataMember(Order = 0)]
        public string IdbResponseId
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the idb response date.
        /// </summary>
        /// <value>
        /// The idb response date.
        /// </value>
        [DataMember(Order = 1)]
        public DateTime? IdbResponseDate
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the idb error code.
        /// </summary>
        /// <value>
        /// The idb error code.
        /// </value>
        [DataMember(Order = 2)]
        public string IdbErrorCode
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the idb data processing text.
        /// </summary>
        /// <value>
        /// The idb data processing text.
        /// </value>
        [DataMember(Order = 3)]
        public string IdbDataProcessingText
        {
            get; set;
        }

        /// <summary>
        /// Gets or sets the idb request identifier.
        /// </summary>
        /// <value>
        /// The idb reqest identifier.
        /// </value>
        [DataMember(Order = 4)]
        public string IdbRequestId
        {
            get; set;
        }
    }
}