﻿namespace Oisys.Service.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    /// <summary>
    /// <see cref="SalesQuote"/> class represents SalesQuote created in the application.
    /// </summary>
    public class SalesQuote : ModelBase
    {
        /// <summary>
        /// Gets or sets property Code.
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Gets or sets property CustomerId.
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets property Date.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets property DeliveryFee.
        /// </summary>
        [Required]
        public decimal DeliveryFee { get; set; }

        /// <summary>
        /// Gets or sets collection of SalesQuoteDetails navigation property.
        /// </summary>
        public ICollection<SalesQuoteDetail> Details { get; set; }

        /// <summary>
        /// Gets or sets Customer navigation property.
        /// </summary>
        public Customer Customer { get; set; }
    }
}
